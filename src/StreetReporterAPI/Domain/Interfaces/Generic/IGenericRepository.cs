namespace StreetReporterAPI.Domain.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetAll();

    }
}
