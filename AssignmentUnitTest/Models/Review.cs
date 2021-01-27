using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Review
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string Review1 { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public bool IsHide { get; set; }
        public int Id { get; set; }
    }
}
