using System.Collections.Generic;
using Domain.Common;

namespace Domain
{
    public class Product : BaseEntity
    {
        public Product(string name, string description, decimal price, int count, float rating, List<string> photos, int subcategoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Count = count;
            Rating = rating;
            Photos = photos;
            SubcategoryId = subcategoryId;
        }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public float Rating { get; set; }
        public List<string> Photos { get; set; }
        public bool IsDeleted { get; set; }
        public int SubcategoryId { get; set; }
        public ProductSubcategory Subcategory { get; set; }
        
        public void Update(string description, decimal price, int count, float rating, List<string> photos)
        {
            Description = description;
            Price = price;
            Count = count;
            Rating = rating;
            Photos = photos;
        }

        public void ChangeSubcategory(int newSubcategoryId)
        {
            if (newSubcategoryId > 0) 
                SubcategoryId = newSubcategoryId;
        }

        public void Delete() => IsDeleted = true;
    }
}