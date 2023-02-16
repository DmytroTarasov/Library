using Persistence.Interfaces;

namespace Persistence.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext Context { get; }
        public IBookRepository BookRepository { get; set; }
        public UnitOfWork(DataContext context, IBookRepository bookRepository)
        {
            Context = context;
            BookRepository = bookRepository;
        }
        public async Task<Boolean> Complete()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}