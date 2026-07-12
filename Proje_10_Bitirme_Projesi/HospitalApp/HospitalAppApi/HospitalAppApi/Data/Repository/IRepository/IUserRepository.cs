using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User obj);
    }
}