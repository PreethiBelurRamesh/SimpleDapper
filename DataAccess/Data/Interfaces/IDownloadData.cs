using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IDownloadData
    {
        Task<int> GetDownloadsByUser(int? id);
        Task<int> InsertDownloadData(DownloadsModel downloadModel);
    }
}