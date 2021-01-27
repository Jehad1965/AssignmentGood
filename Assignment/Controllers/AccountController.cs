using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AssignmentContext _context;

        public AccountController(AssignmentContext context)
        {
            _context = context;
        }

        [HttpPut("RegisterAsync")]
       
        public async Task<IActionResult> RegisterAsync([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.Customers.AddAsync(customer);
                    await _context.SaveChangesAsync();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("UpdateAsync")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateAsync([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry");
                throw;
            }
        }

        [HttpGet("LogIn")]
        public async Task<IActionResult> LogIn(string emailAddress, string password)
        {
            try
            {
                string json;
                JObject jsonResponse;
                Customer customer = await _context.Customers.Where(x => x.EmailAddress == emailAddress && x.Password == password)
                    .FirstOrDefaultAsync();

                if (customer != null)
                {
                    var token = JSONHelper.GetToken(customer);
                   // JObject userJson = JObject.Parse(customer.ToJSON());
                  //  json = $"{{ status : 200, message: 'Login successfull', isUserExit: true, Data :{{ token: '{token}',role:'Customer' }} }}";
                   // jsonResponse = JObject.Parse(json);
                    return StatusCode(200, token);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Sorry");
                throw;
            }
        }

        [HttpDelete("Delete")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
        }



        [HttpGet("ManagerLogin")]
        public async Task<IActionResult> ManagerLogin(string emailAddress, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manager staff = await _context.Managers.Where(x => x.ManagerEmail == emailAddress && x.ManagerPassword == password)
                        .FirstOrDefaultAsync();

                    string json;
                    JObject jsonResponse;
                    if (staff != null)
                    {
                        var token = JSONHelper.GetToken(staff);
                        JObject userJson = JObject.Parse(staff.ToJSON());
                        json = $"{{ status : 200, message: 'Login successfull', isUserExit: true, Data :{{ token: '{token}',user : {userJson.ToJSON()},role:'Manager' }} }}";
                        jsonResponse = JObject.Parse(json);
                        return StatusCode(200, jsonResponse);
                    }
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //Staff
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("AddStaff")]
        public async Task<IActionResult> AddStaff([FromBody] staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.staff.AddAsync(staff);
                    await _context.SaveChangesAsync();
                }
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("StaffUpdateAsync")]
        public async Task<IActionResult> StaffUpdateAsync([FromBody] staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.staff.Update(staff);
                    await _context.SaveChangesAsync();
                }
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("DeleteStaff")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            staff staff = _context.staff.Where(x => x.Id == id).FirstOrDefault();

            if (staff != null)
            {
                _context.Remove(staff);
                await _context.SaveChangesAsync();

                return Ok(staff);
            }
            return BadRequest();
        }

        [HttpGet("StaffLogin")]
        public async Task<IActionResult> StaffLogin(string emailAddress, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    staff staff = await _context.staff.Where(x => x.StaffEmail == emailAddress && x.Password == password)
                        .FirstOrDefaultAsync();

                    if (staff != null)
                    {
                        if (ModelState.IsValid)
                        {
                            staff staf = await _context.staff.Where(x => x.StaffEmail == emailAddress && x.Password == password)
                                .FirstOrDefaultAsync();

                            string json;
                            JObject jsonResponse;
                            if (staff != null)
                            {
                                var token = JSONHelper.GetToken(staff);
                                JObject userJson = JObject.Parse(staff.ToJSON());
                                json = $"{{ status : 200, message: 'Login successfull', isUserExit: true, Data :{{ token: '{token}',user : {userJson.ToJSON()},role:'Manager' }} }}";
                                jsonResponse = JObject.Parse(json);
                                return StatusCode(200, jsonResponse);
                            }
                        }
                    }
                }
                return BadRequest("omething went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
