using Assignment.Controllers;
using Assignment.Models;
using Assignment.ViewModels;
using System;
using Xunit;

namespace Assignment.Unittest
{
    public class UnitTestReview
    {
        private readonly AssignmentContext _context;
        [Fact]
        public void WriteReview_UnitTest()
        {
            //Arrange
            var reviews = new ReviewsController(_context);

            //Act
            var review = new ReviewViewModel();
            review.IsHide = false;
            review.ProductId = 1;
            review.ProductName = "Mango";
            review.Rating = 5;
            review.Review1= "Goodone";
            review.CustomerName = "ahadhassan";
           
            var result= reviews.WriteReview(review);
            //assert
            Assert.False(review.IsHide);
            Assert.NotEmpty(review.ProductName);
            Assert.NotEmpty(review.ProductName);
            Assert.NotEqual(0,review.Rating);
            Assert.NotEmpty(review.Review1);
          


        }
        [Fact]
        public void HideReview_UnitTest()
        {
            //Arrange
            var reviews = new ReviewsController(_context);

            //Act
            var review = new Review();
            review.IsHide = true;

            //assert
            Assert.True(review.IsHide);
            



        }
       

    }
}
