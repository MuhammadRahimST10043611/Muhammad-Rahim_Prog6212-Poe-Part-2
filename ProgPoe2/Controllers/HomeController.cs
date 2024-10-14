using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using ProgPoe2.Models;
using System.Diagnostics;

namespace ProgPoe2.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=cldvst10043611;AccountKey=A1DGT56hmblnV8FX6ISHlF9HU9v/o8z6thDkC+Sr/NCqJxdyk1A8xZykTdH16+LGacXmi+4vBKHa+ASt2pl1HA==;EndpointSuffix=core.windows.net";
        private readonly string shareName = "uploadedfiles";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitClaim()
        {
            return View();
        }

        public IActionResult ViewClaims()
        {
            return View(ClaimRepository.Claims);
        }

        public IActionResult ApprovalDashboard()
        {
            var pendingClaims = ClaimRepository.Claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitClaim(Claim claim, IFormFile file)
        {
            claim.Id = ClaimRepository.Claims.Count + 1;

            if (file != null && file.Length > 0)
            {
                if (file.Length > 5 * 1024 * 1024) // 5MB limit
                {
                    ModelState.AddModelError("file", "File size must be less than 5MB.");
                    return View(claim);
                }

                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("file", "Only PDF, Word, and Excel documents are allowed.");
                    return View(claim);
                }

                claim.SupportingDocumentName = await UploadFileToAzure(file);
            }

            ClaimRepository.Claims.Add(claim);
            return RedirectToAction("ViewClaims");
        }

        private async Task<string> UploadFileToAzure(IFormFile file)
        {
            try
            {
                var shareClient = new ShareClient(connectionString, shareName);
                var directoryClient = shareClient.GetRootDirectoryClient();
                var fileName = Path.GetFileName(file.FileName);
                var fileClient = directoryClient.GetFileClient(fileName);

                await using (var stream = file.OpenReadStream())
                {
                    await fileClient.CreateAsync(stream.Length);
                    await fileClient.UploadAsync(stream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        public IActionResult UpdateClaimStatus(int claimId, string status)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == claimId);
            if (claim != null)
            {
                claim.Status = status;
            }
            return RedirectToAction(nameof(ApprovalDashboard));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EditClaim(int id)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        [HttpPost]
        public async Task<IActionResult> EditClaim(int id, Claim updatedClaim, IFormFile file)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.LecturerName = updatedClaim.LecturerName;
            claim.HoursWorked = updatedClaim.HoursWorked;
            claim.HourlyRate = updatedClaim.HourlyRate;
            claim.Notes = updatedClaim.Notes;
            claim.Status = updatedClaim.Status;

            if (file != null && file.Length > 0)
            {
                if (file.Length > 5 * 1024 * 1024) // 5MB limit
                {
                    ModelState.AddModelError("file", "File size must be less than 5MB.");
                    return View(claim);
                }

                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("file", "Only PDF, Word, and Excel documents are allowed.");
                    return View(claim);
                }

                claim.SupportingDocumentName = await UploadFileToAzure(file);
            }

            return RedirectToAction("ViewClaims");
        }

        [HttpPost]
        public IActionResult RemoveClaim(int id)
        {
            var claim = ClaimRepository.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                ClaimRepository.Claims.Remove(claim);
            }
            return RedirectToAction("ViewClaims");
        }
    }
}
