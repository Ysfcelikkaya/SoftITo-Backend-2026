using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository {
    public interface IMedicalRecordRepository : IRepository<MedicalRecord> {
        void Update(MedicalRecord obj);
    }
}