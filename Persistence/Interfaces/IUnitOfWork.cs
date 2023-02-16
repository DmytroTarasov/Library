namespace Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext Context { get; }
        IBookRepository BookRepository { get; set; }
        Task<Boolean> Complete();
    }
}