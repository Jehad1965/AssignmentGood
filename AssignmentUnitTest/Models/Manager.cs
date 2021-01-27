using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerPassword { get; set; }
    }
}
