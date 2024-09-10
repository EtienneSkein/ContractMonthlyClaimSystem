using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ContractMonthlyClaimSystem.Models;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ClaimsController : Controller
    {
        // Temporary static list of claims (simulating data storage for demo purposes)
        private static List<ClaimSubmission> claims = new List<ClaimSubmission>
        {
            new ClaimSubmission { ClaimDate = DateTime.Now.AddDays(-2), HoursWorked = 8, SupportingDocument = "Document1.pdf" },
            new ClaimSubmission { ClaimDate = DateTime.Now.AddDays(-1), HoursWorked = 6, SupportingDocument = "Document2.pdf" }
        };

        // GET: Claims/Submit
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        // POST: Claims/Submit
        [HttpPost]
        public IActionResult Submit(ClaimSubmission model)
        {
            if (ModelState.IsValid)
            {
                // For now, we're just adding the claim to the static list (this should save to the database at a later stage)
                claims.Add(model);
                return RedirectToAction("Success"); // Redirect to a success page
            }

            return View(model); // Return to form if validation fails
        }

        // Success page (shown after submitting a claim)
        public IActionResult Success()
        {
            return View();
        }

        // GET: Claims/ManageClaims (for Coordinators/Managers to manage submitted claims)
        [HttpGet]
        public IActionResult ManageClaims()
        {
            return View(claims); // Pass the list of claims to the view
        }

        // POST: Approve a specific claim (for demonstration purposes)
        [HttpPost]
        public IActionResult Approve(int id)
        {
            // Logic to approve a claim 
            // For demo, we're simply redirecting back to the ManageClaims view
            return RedirectToAction("ManageClaims");
        }

        // POST: Reject a specific claim (for demonstration purposes)
        [HttpPost]
        public IActionResult Reject(int id)
        {
            // Logic to reject a claim (Logic will be added later in the project)
            // For demo, we're simply redirecting back to the ManageClaims view
            return RedirectToAction("ManageClaims");
        }
    }
}
