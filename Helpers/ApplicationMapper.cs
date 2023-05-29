﻿using AutoMapper;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
