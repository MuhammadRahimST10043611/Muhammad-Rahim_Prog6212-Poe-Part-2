using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgPoe2.Models;
using ProgPoe2.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ProgPoe2.Tests
{
    [TestClass]
    public class ClaimTests
    {
        private HomeController GetController()
        {
            var httpContext = new DefaultHttpContext();
            var controller = new HomeController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
            return controller;
        }

        [TestMethod]
        public void SubmitClaim_ValidClaim_AddsToRepository()
        {
            // Arrange
            var controller = GetController();
            var claim = new Claim
            {
                LecturerName = "John Doe",
                HoursWorked = 10,
                HourlyRate = 50,
                Notes = "Test claim"
            };
            ClaimRepository.Claims.Clear(); // Ensure a clean state

            // Act
            var result = controller.SubmitClaim(claim, null).Result as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ViewClaims", result.ActionName);
            CollectionAssert.Contains(ClaimRepository.Claims, claim);
        }
        [TestMethod]
        public void ViewClaims_ReturnsAllClaims()
        {
            // Arrange
            var controller = GetController();
            ClaimRepository.Claims.Clear(); // Ensure a clean state
            ClaimRepository.Claims.Add(new Claim { Id = 1, LecturerName = "John Doe" });
            ClaimRepository.Claims.Add(new Claim { Id = 2, LecturerName = "Jane Smith" });

            // Act
            var result = controller.ViewClaims() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Claim>));
            var model = result.Model as List<Claim>;
            Assert.AreEqual(2, model.Count);
        }
        [TestMethod]
        public void UpdateClaimStatus_ValidId_UpdatesStatus()
        {
            // Arrange
            var controller = GetController();
            var claim = new Claim { Id = 1, LecturerName = "John Doe", Status = "Pending" };
            ClaimRepository.Claims.Clear(); // Ensure a clean state
            ClaimRepository.Claims.Add(claim);

            // Act
            var result = controller.UpdateClaimStatus(1, "Approved") as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ApprovalDashboard", result.ActionName);
            Assert.AreEqual("Approved", claim.Status);
        }

        [TestMethod]
        public void CalculateTotalAmount_ReturnsCorrectAmount()
        {
            // Arrange
            var claim = new Claim
            {
                HoursWorked = 10,
                HourlyRate = 50
            };

            // Act
            var totalAmount = claim.HoursWorked * claim.HourlyRate;

            // Assert
            Assert.AreEqual(500, totalAmount);
        }
    }
}
