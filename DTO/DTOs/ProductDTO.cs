﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ImagePath { get; set; } 
        public int CategoryId { get; set; }

    }
}
