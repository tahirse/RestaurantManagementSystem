﻿

using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Core.Entities
{
    public class MenuItem : BaseEntity
    {
       
        public string Name { get; set; }  
        
        public decimal Price { get; set; }  
       
        public string Category { get; set; }

        public OrderItem OrderItem { get; set; } 
    }
}
