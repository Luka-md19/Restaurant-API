using Microsoft.Identity.Client;
using Resturant.API.Contract;
using Resturant.API.Models.AccountConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.API.Data.Schema
{
    public class RestaurantData
    {
        [Key]

        public int Id { get; set; } 

        public string RestaurantId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }

        public string Cover { get; set; }

        public string BrandCode { get; set; }

        [ForeignKey(nameof(AccountId))]
        public int AccountId { get; set; }
        public AccountConfiguration AccountConfiguration { get; set; }




    }
}
