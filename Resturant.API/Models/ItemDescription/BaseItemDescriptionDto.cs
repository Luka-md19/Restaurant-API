namespace Resturant.API.Models.ItemDescription
{
    public abstract class BaseItemDescriptionDto 
    {
        public int ItemID { get; set; }
        public string DescriptionText { get; set; }
        public string AllergenInfo { get; set; }
        public string NutritionalInfo { get; set; }
        public string Language { get; set; }
    }
}
