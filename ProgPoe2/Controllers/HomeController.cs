using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using ProgPoe2.Models;
using System.Diagnostics;

namespace ProgPoe2.Controllers
{
    public class HomeController : Controller
    {
        // Azure storage connection string and file share name
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=cldvst10043611;AccountKey=A1DGT56hmblnV8FX6ISHlF9HU9v/o8z6thDkC+Sr/NCqJxdyk1A8xZykTdH16+LGacXmi+4vBKHa+ASt2pl1HA==;EndpointSuffix=core.windows.net";
        private readonly string shareName = "uploadedfiles";

        // Action method for home page
        public IActionResult Index()
        {
            return View();
        }

        // Action method for submitting a new claim
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // Action method for viewing claims
        public IActionResult ViewClaims()
        {
            return View(ClaimRepository.Claims);
        }

        // Action method for approval dashboard, shows pending claims
        public IActionResult ApprovalDashboard()
        {
            var pendingClaims = ClaimRepository.Claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        // Handles claim submission, including file validation and uploading
        [HttpPost]
        public async Task<IActionResult> SubmitClaim(Claim claim, IFormFile file)
        {
            claim.Id = ClaimRepository.Claims.Count + 1; // Assigns a unique ID to the claim

            if (file != null && file.Length > 0)
            {
                // Checks if file size is within 5MB limit
                if (file.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("file", "File size must be less than 5MB.");
                    return View(claim);
                }

                // Validates file extension
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("file", "Only PDF, Word, and Excel documents are allowed.");
                    return View(claim);
                }

                // Uploads file to Azure Files
                claim.SupportingDocumentName = await UploadFileToAzure(file);
            }

            // Adds the claim to the repository
            ClaimRepository.Claims.Add(claim);
            return RedirectToAction("ViewClaims");
        }

        // Helper method for uploading a file to Azure Files
        private async Task<string> UploadFileToAzure(IFormFile file)
        {
            try
            {
                var shareClient = new ShareClient(connectionString, shareName); // Azure File Share client
                var directoryClient = shareClient.GetRootDirectoryClient(); // Accesses root directory
                var fileName = Path.GetFileName(file.FileName); // Gets the file name
                var fileClient = directoryClient.GetFileClient(fileName); // File client for Azure upload

                // Uploads file to Azure
                await using (var stream = file.OpenReadStream())
                {
                    await fileClient.CreateAsync(stream.Length);
                    await fileClient.UploadAsync(stream);
                }

                return fileName; // Returns the uploaded file's name
            }
            catch (Exception ex)
            {
                // Logs any errors that occur during file upload
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return null;
            }
        }

        // Updates the status of a claim (Approve/Reject)
        [HttpPost]
        public IActionResult UpdateClaimStatus(int claimId, string status)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == claimId); // Finds the claim by ID
            if (claim != null)
            {
                claim.Status = status; // Updates claim status
            }
            return RedirectToAction(nameof(ApprovalDashboard));
        }

        // Action method for error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Action method for editing an existing claim
        public IActionResult EditClaim(int id)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == id); // Finds the claim by ID
            if (claim == null)
            {
                return NotFound(); // Returns 404 if claim not found
            }
            return View(claim);
        }

        // Handles claim editing, including file validation and upload if new file is provided
        [HttpPost]
        public async Task<IActionResult> EditClaim(int id, Claim updatedClaim, IFormFile file)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == id); // Finds the claim by ID
            if (claim == null)
            {
                return NotFound(); // Returns 404 if claim not found
            }

            // Updates claim details
            claim.LecturerName = updatedClaim.LecturerName;
            claim.HoursWorked = updatedClaim.HoursWorked;
            claim.HourlyRate = updatedClaim.HourlyRate;
            claim.Notes = updatedClaim.Notes;
            claim.Status = updatedClaim.Status;

            if (file != null && file.Length > 0)
            {
                // Validates file size
                if (file.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("file", "File size must be less than 5MB.");
                    return View(claim);
                }

                // Validates file extension
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("file", "Only PDF, Word, and Excel documents are allowed.");
                    return View(claim);
                }

                // Uploads file to Azure
                claim.SupportingDocumentName = await UploadFileToAzure(file);
            }

            return RedirectToAction("ViewClaims");
        }

        // Removes a claim from the repository
        [HttpPost]
        public IActionResult RemoveClaim(int id)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == id); // Finds the claim by ID
            if (claim != null)
            {
                ClaimRepository.Claims.Remove(claim); // Removes the claim
            }
            return RedirectToAction("ViewClaims");
        }
    }
}
