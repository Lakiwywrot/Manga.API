using AutoMapper;
using Manga.DATA.DAL;
using Manga.DATA.Dto;
using Manga.DATA.Entities;
using Manga.SERVICES.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Implementations
{
    public class BookService : IBookServices
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public BookService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BookForDisplay> AddBookAsync(BookForCreation bookForCreation)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Name = bookForCreation.Name,
                DateOfCreation = DateTime.Now
            };

            await dbContext.Books.AddAsync(book);
            if (await dbContext.SaveChangesAsync() <= 0)
            {
                return null;
            }

            var bookForDisplay = mapper.Map<BookForDisplay>(book);
            return bookForDisplay;

        }


        public async Task<BookForDisplay> GetBookAsync(Guid bookId)
        {
            var book = await dbContext.Books.FindAsync(bookId);
            var bookForDisplay = mapper.Map<BookForDisplay>(book);
            return bookForDisplay;
        }

        public async Task<IList<BookForDisplay>> GetBooksAsync()
        {
            var books = await dbContext.Books.ToListAsync();
            var booksForDisplay = mapper.Map<IList<BookForDisplay>>(books);
            return booksForDisplay;

        }
    }
}
