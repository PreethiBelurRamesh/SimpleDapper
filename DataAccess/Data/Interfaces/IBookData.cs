using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IBookData
    {
        Task<IEnumerable<BookModel>> GetBooksDownloadedByUser(int id);
        Task InsertNewBook(BookModel book);
    }
}