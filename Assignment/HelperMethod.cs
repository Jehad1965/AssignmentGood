using Assignment.Models;
using DataRepository.HelperMethods;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Assignment
{
   
    public static class JSONHelper
    {
        #region Public extension methods.  
        /// <summary>  
        /// Extened method of object class, Converts an object to a json string.  
        /// </summary>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public static string ToJSON(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>  
        /// Extened method of object class, Converts an DB context to pagination 
        /// </summary>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
 

        public static Customer GetUser(this System.Security.Claims.ClaimsPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var claims = identity.Claims
                         .Where(x => x.Type == ClaimTypes.Email)
                         .Select(x => x.Value)
                         .FirstOrDefault();
                    using (var ctx = new AssignmentContext())
                    {
                        return ctx.Customers.Where(x => x.EmailAddress == claims).FirstOrDefault();
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        #endregion

        public static Dictionary<string, string[]> JsonErrorGenerator(ModelStateDictionary ModelState)
        {
            var errorList = ModelState.Where(e => e.Value.Errors.Count >= 1).ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                            );
            return errorList;
        }

        public static string GetToken(Customer user)
        {
            var issuer = ConfigurationReader.AppSetting["Jwt:Issuer"];
            string key = ConfigurationReader.AppSetting["Jwt:AudienceSecret"]; //Secret key which will be used later during validation       

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = "";

            if (user != null)
            {
                userRole = "Customer";
            }
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            try
            {
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("email", user.EmailAddress));
                permClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            catch (Exception ex)
            {

            }
            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);



            return jwt_token;
        }
        public static string GetToken(Manager user)
        {
            var issuer = ConfigurationReader.AppSetting["Jwt:Issuer"];
            string key = ConfigurationReader.AppSetting["Jwt:AudienceSecret"]; //Secret key which will be used later during validation       

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = "";

            if (user != null)
            {
                userRole = "Manager";
            }
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            try
            {
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("email", user.ManagerEmail));
                permClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            catch (Exception ex)
            {

            }
            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);



            return jwt_token;
        }
        public static string GetToken(staff user)
        {
            var issuer = ConfigurationReader.AppSetting["Jwt:Issuer"];
            string key = ConfigurationReader.AppSetting["Jwt:AudienceSecret"]; //Secret key which will be used later during validation       

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = "";

            if (user != null)
            {
                userRole = "Staff";
            }
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            try
            {
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("email", user.StaffEmail));
                permClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            catch (Exception ex)
            {

            }
            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);



            return jwt_token;
        }

    }
}
