﻿

namespace QuickCart.Domain.Models
{
    public class Product :BaseEntity
    {
        public  string Name { get; set; }   

        public string Description { get; set; } 
        public int SubCategoryId { get; set; }  
        public virtual SubCategory SubCategory { get; set; }    
    }
}
