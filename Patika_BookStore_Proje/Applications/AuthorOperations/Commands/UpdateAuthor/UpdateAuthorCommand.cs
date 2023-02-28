using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand{
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model  { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Yazar bulunamadı.");
            if(_dbContext.Authors.Any(x => x.Ad.ToLower() == Model.Ad.ToLower() && x.Soyad.ToLower() == Model.Ad.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("Yazar zaten mevcut.");
            author.Ad = string.IsNullOrEmpty(Model.Ad.Trim()) ? author.Ad : Model.Ad ;
            author.Soyad = string.IsNullOrEmpty(Model.Soyad.Trim()) ? author.Soyad : Model.Soyad ;
            author.DogumTarihi = Model.DogumTarihi;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumTarihi { get; set; }
    }
}