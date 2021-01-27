using Assignment.Models;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ReviewsController : ControllerBase
    {
        private readonly AssignmentContext _context;

        public ReviewsController(AssignmentContext context)
        {
            _context = context;
        }

        [HttpPost("WriteReview")]
        public async Task<IActionResult> WriteReview([FromBody] ReviewViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Review review = new Review
                    {
                        CustomerName = model.CustomerName,
                        IsHide = model.IsHide,
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        Rating = model.Rating,
                        Review1 = model.Review1
                    };

                    await _context.Reviews.AddAsync(review);
                    await _context.SaveChangesAsync();

                    return Ok(review);
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost("HideReview")]
        public async Task<IActionResult> HideReview([FromBody] Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Reviews.Remove(review);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
