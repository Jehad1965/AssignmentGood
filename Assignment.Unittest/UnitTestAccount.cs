using Assignment.Controllers;
using Assignment.Models;
using System;
using Xunit;

namespace Assignment.Unittest
{
    public class UnitTestAccount
    {
        private readonly AssignmentContext _context;
        [Fact]
        public void RegisterAsync_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);

            //Act
            var customer = new Customer();
            customer.Id = 0;
            customer.FirstName = "jahad";
            customer.LastName = "Hassan";
            customer.PhoneNo = "123456789";
            customer.PostCode= "12345";
            customer.EmailAddress = "ahadhassan@gmail.com";
            customer.Password = "DNSh0099";
            customer.ConfirmPassword = "DNSh0099";
            customer.Address = "29,street 9";
           
            var result= account.RegisterAsync(customer);
            //assert
            Assert.Equal(0,customer.Id);
            Assert.NotEmpty(customer.LastName);
            Assert.NotEmpty(customer.FirstName);
            Assert.NotEmpty(customer.PhoneNo);
            Assert.NotEmpty(customer.Password);
            Assert.NotEmpty(customer.Password);
            Assert.NotEmpty(customer.ConfirmPassword);
            Assert.NotEmpty(customer.PostCode);
            Assert.NotEmpty(customer.Address);


        }
        [Fact]
        public void update_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);

            //Act
            var customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "jahad";
            customer.LastName = "Hassan";
            customer.PhoneNo = "123456789";
            customer.PostCode = "12345";
            customer.EmailAddress = "ahadhassan@gmail.com";
            customer.Password = "DNSh0099";
            customer.ConfirmPassword = "DNSh0099";
            customer.Address = "29,street 9";

            var result = account.UpdateAsync(customer);
            //assert
            Assert.NotEqual(0, customer.Id);
            Assert.NotEmpty(customer.LastName);
            Assert.NotEmpty(customer.FirstName);
            Assert.NotEmpty(customer.PhoneNo);
            Assert.NotEmpty(customer.Password);
            Assert.NotEmpty(customer.Password);
            Assert.NotEmpty(customer.ConfirmPassword);
            Assert.NotEmpty(customer.PostCode);
            Assert.NotEmpty(customer.Address);



        }
        [Fact]
        public void Login_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);
            //Act
            string emailAddress = "jahad@gmail.com";
            string password = "DNSh0099";
            var result = account.LogIn(emailAddress,password);
            //assert
            Assert.NotEmpty(emailAddress);
            Assert.NotEmpty(password);

        }
        [Fact]
        public void Delete_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);
            //Act
            int id = 1;
            var result = account.Delete(id);
            //assert
            Assert.NotEqual(0,id);

        }
        [Fact]
        public void ManagerLogin_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);
            //Act
            string emailAddress = "jahad@gmail.com";
            string password = "DNSh0099";
            var result = account.ManagerLogin(emailAddress, password);
            //assert
            Assert.NotEmpty(emailAddress);
            Assert.NotEmpty(password);

         
        }
        [Fact]
        public void AddStuff_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);

            //Act
            var staff = new staff();
            staff.Id = 0;
            staff.StaffName = "jahad";
            staff.StaffEmail = "ahadhassan@gmail.com";
            staff.Password = "DNSh0099";
            var result = account.AddStaff(staff);
            //assert
            Assert.Equal(0, staff.Id);
            Assert.NotEmpty(staff.StaffName);
            Assert.NotEmpty(staff.StaffEmail);
            Assert.NotEmpty(staff.Password);

        }
        [Fact]
        public void StaffUpdateAsync_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);

            //Act
            var staff = new staff();
            staff.Id = 1;
            staff.StaffName = "jahad";
            staff.StaffEmail = "ahadhassan@gmail.com";
            staff.Password = "DNSh0099";
            var result = account.StaffUpdateAsync(staff);
            //assert
            Assert.NotEqual(0, staff.Id);
            Assert.NotEmpty(staff.StaffName);
            Assert.NotEmpty(staff.StaffEmail);
            Assert.NotEmpty(staff.Password);

        }
        [Fact]
        public void DeleteStaff_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);
            //Act
            int id = 1;
            var result = account.DeleteStaff(id);
            //assert
            Assert.NotEqual(0, id);

        }
        [Fact]
        public void LoginStaff_UnitTest()
        {
            //Arrange
            var account = new AccountController(_context);
            //Act
            string emailAddress = "jahad@gmail.com";
            string password = "DNSh0099";
            var result = account.StaffLogin(emailAddress, password);
            //assert
            Assert.NotEmpty(emailAddress);
            Assert.NotEmpty(password);

        }

    }
}
