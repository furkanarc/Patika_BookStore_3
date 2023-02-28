using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.UpdateBook{
    public class UpdateBookCommand{
        public int BookId {get;set;}
        public UpdateBookModel Model {get;set;}
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı.");
            book.GenreId = Model.GenreId;
            book.Title = string.IsNullOrEmpty(Model.Title.Trim()) ? book.Title : Model.Title;
            _dbContext.SaveChanges();
        }
        
    }
    public class UpdateBookModel{
            public string Title {get;set;}
            public int GenreId {get;set;}
        }
}