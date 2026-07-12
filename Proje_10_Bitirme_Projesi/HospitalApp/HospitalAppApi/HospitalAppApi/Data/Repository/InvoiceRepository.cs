using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private ApplicationDbContext _db; public InvoiceRepository(ApplicationDbContext db) : base(db) { _db = db; }
        public void Update(Invoice obj) { _db.Invoices.Update(obj); }
    }
}