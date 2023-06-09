using DataAccess.Data.Interfaces;
using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class BookData : IBookData
{
    private readonly ISqlDataAccess _dataAccess;

    public BookData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public async Task<IEnumerable<BookModel>> GetBooksDownloadedByUser(int id)
    {
        string sql = @"SELECT Book_Id,Book_Name 
                       FROM dbo.[Downloads] d
                       JOIN dbo.[Book] b
                       ON d.BookID = b.Book_Id
                       WHERE UserID = @userid;";


        return await _dataAccess.MultipleRows<BookModel, dynamic>(sql, new { userid = id });
    }

    public async Task InsertNewBook(BookModel book)
    {
        string sql = @"INSERT INTO dbo.[Book] (Book_Name) values (@bookname)";

        await _dataAccess.InsertSingleRow<dynamic>(sql, new { bookname = book.Book_Name });
    }

}
