using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class DownloadsModel
{
    public int Download_Id { get; set; }
    public DateTime Download_Time { get; set; }

    public int UserID { get; set; }
    public int BookID { get; set; }
}
