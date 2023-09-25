using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.API.Data
{
    public class ItemDescription
    {
        [Key]
        public int ItemID { get; set; }

        public string DescriptionText { get; set; }
        public string AllergenInfo { get; set; }
        public string NutritionalInfo { get; set; }
        public string Language { get; set; }

        // Relationships
        [ForeignKey("ItemID")]
        public virtual MenuItem MenuItem { get; set; }
    }
}
