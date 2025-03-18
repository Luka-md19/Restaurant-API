using System.ComponentModel.DataAnnotations;

namespace Resturant.API.Data
{
    public class ItemClickCount
    {
        [Key]
        public int ItemID { get; set; }
        public int ClickCount { get; set; }

        public virtual ItemDescription ItemDescription { get; set; }
    }
}
