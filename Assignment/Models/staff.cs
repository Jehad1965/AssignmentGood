using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class staff
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public string Password { get; set; }
    }
}
