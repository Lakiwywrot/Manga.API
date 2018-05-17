using AutoMapper;
using Manga.DATA.DAL;
using Manga.DATA.Dto;
using Manga.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manga.API
{
    public class MappingProfil : Profile
    {
        public MappingProfil()
        {
            CreateMap<Book, BookForDisplay>();
            CreateMap<BookForCreation, Book>();
        }
    }
}
