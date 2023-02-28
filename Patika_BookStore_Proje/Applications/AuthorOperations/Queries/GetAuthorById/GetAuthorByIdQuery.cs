using System;
using System.Linq;
using AutoMapper;
using Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthors;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthorById{
    public class GetAuthorByIdQuery
    {
        public int AuthorId {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorViewModel Handle(){
            var author =  _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");
            
            return _mapper.Map<AuthorViewModel>(author);
        }
    }
}