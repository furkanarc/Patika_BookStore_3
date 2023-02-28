using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommand{
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı.");

            _dbContext.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}