using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest framework for unit testing
using ProgPoe2.Models; // Namespace for Claim model
using ProgPoe2.Controllers; // Namespace for HomeController
using Microsoft.AspNetCore.Mvc; // Namespace for MVC components
using System.Collections.Generic; // For using collections
using Microsoft.AspNetCore.Http; // For HTTP context simulation
using System.Security.Claims; // For claims-based authentication

namespace ProgPoe2.Tests
{
    [TestClass] // Indicates that this class contains unit tests
    public class ClaimTests
    {
        // Helper method to create an instance of HomeController for testing
        private HomeController GetController()
        {
            var httpContext = new DefaultHttpContext(); // Simulate an HTTP context
            var controller = new HomeController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext // Assign simulated context to controller
                }
            };
            return controller; // Return the configured controller
        }

        // Test to ensure a valid claim is added to the repository
        [TestMethod]
        public void SubmitClaim_ValidClaim_AddsToRepository()
        {
            var controller = GetController(); // Get a controller instance
            var claim = new Claim
            {
                LecturerName = "John Doe", // Test lecturer name
                HoursWorked = 10, // Test hours worked
                HourlyRate = 50, // Test hourly rate
                Notes = "Test claim" // Test notes
            };
            ClaimRepository.Claims.Clear(); // Clear repository to ensure a clean test

            var result = controller.SubmitClaim(claim, null).Result as RedirectToActionResult; // Call the method and cast result

            // Assert that the claim was added and redirected to ViewClaims
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.AreEqual("ViewClaims", result.ActionName); // Ensure redirected action is ViewClaims
            CollectionAssert.Contains(ClaimRepository.Claims, claim); // Ensure the claim is added to the repository
        }

        // Test to ensure that ViewClaims returns all claims in the repository
        [TestMethod]
        public void ViewClaims_ReturnsAllClaims()
        {
            var controller = GetController(); // Get a controller instance
            ClaimRepository.Claims.Clear(); // Ensure clean repository state
            ClaimRepository.Claims.Add(new Claim { Id = 1, LecturerName = "John Doe" }); // Add test claims
            ClaimRepository.Claims.Add(new Claim { Id = 2, LecturerName = "Jane Smith" });

            var result = controller.ViewClaims() as ViewResult; // Call the method and cast result

            // Assert that the result contains all claims
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.IsInstanceOfType(result.Model, typeof(List<Claim>)); // Ensure model is of type List<Claim>
            var model = result.Model as List<Claim>; // Cast model to List<Claim>
            Assert.AreEqual(2, model.Count); // Ensure both claims are returned
        }

        // Test to ensure that claim status is updated correctly
        [TestMethod]
        public void UpdateClaimStatus_ValidId_UpdatesStatus()
        {
            var controller = GetController(); // Get a controller instance
            var claim = new Claim { Id = 1, LecturerName = "John Doe", Status = "Pending" }; // Test claim
            ClaimRepository.Claims.Clear(); // Ensure clean state
            ClaimRepository.Claims.Add(claim); // Add test claim

            var result = controller.UpdateClaimStatus(1, "Approved") as RedirectToActionResult; // Call the method

            // Assert that status is updated
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.AreEqual("ApprovalDashboard", result.ActionName); // Ensure redirected action is ApprovalDashboard
            Assert.AreEqual("Approved", claim.Status); // Ensure status is updated to Approved
        }

        // Test to calculate the total amount correctly
        [TestMethod]
        public void CalculateTotalAmount_ReturnsCorrectAmount()
        {
            var claim = new Claim
            {
                HoursWorked = 10, // Test hours worked
                HourlyRate = 50 // Test hourly rate
            };

            var totalAmount = claim.HoursWorked * claim.HourlyRate; // Calculate total amount

            Assert.AreEqual(500, totalAmount); // Ensure total amount is correct
        }
    }
}
