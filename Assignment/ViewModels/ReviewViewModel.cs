using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.ViewModels
{
    public class ReviewViewModel
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string Review1 { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public bool IsHide { get; set; }
    }
}
