using DataAccess.Data.Interfaces;
using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class DownloadData : IDownloadData
{
    private readonly ISqlDataAccess _dataAccess;
    public DownloadData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<int> GetDownloadsByUser(int? id)
    {
        string sql = @"SELECT COUNT(*) FROM dbo.[Downloads] WHERE UserID = @id; ";
        return await _dataAccess.SingleValue<int, dynamic>(sql, new { id = id });
    }


    public async Task<int> InsertDownloadData(DownloadsModel downloadModel)
    {
        string sql = @"If exists(SELECT * FROM dbo.[User] where UserId = @userid ) 
	                   BEGIN
	                     if exists(SELECT * FROM dbo.[Book] where Book_Id = @bookid)
	                     Begin
	                       Insert into dbo.[Downloads] (Download_Date,UserID,BookID)
	                       values(@download_date,@userid,@bookid)
	                     End
	                   END";

        return await _dataAccess.InsertReturnRowsAffected(sql, new { download_date = downloadModel.Download_Time,
                                                     userid = downloadModel.UserID,
                                                     bookid = downloadModel.BookID});

    }
}
