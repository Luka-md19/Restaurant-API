using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.API.Data
{
    public class MenuCategory
    {
        [Key]
        public int CategoryID { get; set; }

        
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int DisplayOrder { get; set; }

        // Relationships
        public virtual IList<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
