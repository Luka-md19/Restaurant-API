﻿using AutoMapper;
using Resturant.API.Data;
using Resturant.API.Models.ItemDescription;
using Resturant.API.Models.MenuCategory;
using Resturant.API.Models.MenuItem;
using Resturant.API.Models.Review;
using Resturant.API.Models.SpecialOffer;

namespace Resturant.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<MenuCategory, CreateMenuCategoryDto>().ReverseMap();
            CreateMap<MenuCategory, GetMenuCategoryDto>().ReverseMap();
            CreateMap<MenuCategory, MenuCategoryDto>().ReverseMap();
            

            CreateMap<MenuItem, CreateMenuItemsDto>().ReverseMap();
            CreateMap<MenuItem, GetMenuItemsDto>().ReverseMap();
            CreateMap<MenuItem, MenuItemDto>().ReverseMap();


            CreateMap<Review,CreateReviewDto>().ReverseMap();
            CreateMap<Review,GetReviewDto>().ReverseMap();
            CreateMap<Review,ReviewDto>().ReverseMap();

            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, SpecialOfferDto>().ReverseMap();


            CreateMap<ItemDescription, CreateItemDescriptionDto>().ReverseMap();
            CreateMap<ItemDescription, GetItemDescriptionDto>().ReverseMap();
            CreateMap<ItemDescription, ItemDescriptionDto>().ReverseMap();

        }
    }
}
