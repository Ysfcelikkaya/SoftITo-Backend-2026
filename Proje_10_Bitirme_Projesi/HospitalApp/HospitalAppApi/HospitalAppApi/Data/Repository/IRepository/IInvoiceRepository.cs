using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository {
    public interface IInvoiceRepository : IRepository<Invoice> {
        void Update(Invoice obj);
    } 
}