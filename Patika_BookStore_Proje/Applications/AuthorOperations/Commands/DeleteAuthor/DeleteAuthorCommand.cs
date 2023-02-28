using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_AuthorStore_Proje.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var authorBooks = _dbContext.Books.FirstOrDefault(x => x.AuthorId == AuthorId);
            if(author is null) 
                throw new InvalidOperationException("Silinecek Yazar bulunamadı.");
            if(authorBooks is not null)
                throw new InvalidOperationException("Kayıtlı kitapları olan yazar " + author.Ad + " " + author.Soyad + " silinemez");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}