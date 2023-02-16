using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence.Interfaces;

namespace Application.Books
{
    public class List
    {
        public class Query : IRequest<Result<List<BookDTO<int>>>> {
            public string OrderBy { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<BookDTO<int>>>>
        {
            private readonly IUnitOfWork _uof;
            private readonly IMapper _mapper;
            public Handler(IUnitOfWork uof, IMapper mapper)
            {
                _uof = uof;
                _mapper = mapper;
            }
            public async Task<Result<List<BookDTO<int>>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = await _uof.BookRepository.GetAllBooks(request.OrderBy);
                var booksDTO = _mapper.Map<List<Book>, List<BookDTO<int>>>(books.ToList());

                return Result<List<BookDTO<int>>>.Success(booksDTO);
            }
        } 
    }
}