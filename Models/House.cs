namespace sharpList.Models
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class House
    {
        
        public int id { get; set; }
        public int? bedrooms { get; set; }
        public double? bathrooms { get; set; }
        public int? floors { get; set; }

    }
}