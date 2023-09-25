using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.API.Data
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public int ItemID { get; set; }
        [ForeignKey(nameof(ItemID))]
        public virtual MenuItem MenuItem { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
