using System;
using System.Runtime.Serialization;
            
namespace minefield.ECommerce.Products
{
    [DataContract (Name = "ProductDto")]
    public class ProductDto
    {
        [DataMember (Name = "Name")]
        public string Name { get; set; }

        [DataMember (Name = "Price")]
        public decimal Price { get; set; }
    }
}
