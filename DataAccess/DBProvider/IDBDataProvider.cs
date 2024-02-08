
namespace DataAccess.DBProvider
{
    public interface IDBDataProvider
    {
        Task<IEnumerable<T>> GetData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}