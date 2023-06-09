namespace DataAccess.DbAccess
{
   public interface ISqlDataAccess
    {
        Task<int> InsertReturnRowsAffected<U>(string sqlQuery, U parameters, string connectionId = "Default");
        Task InsertSingleRow<U>(string sqlQuery, U parameters, string connectionId = "Default");
        Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<T>> MultipleRows<T, U>(string sqlQuery, U parameters, string connectionId = "Default");
        Task SaveData<T>(string storedprocedure, T parameters, string connectionId = "Default");
        Task<T> SingleValue<T, U>(string sqlQuery, U parameters, string connectionId = "Default");
    }
}