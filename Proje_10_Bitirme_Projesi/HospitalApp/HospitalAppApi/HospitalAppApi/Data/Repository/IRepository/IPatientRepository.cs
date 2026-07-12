using HospitalAppApi.Models; // Modellerin olduğu namespace

namespace HospitalAppApi.Data.Repository.IRepository
{
    // IRepository<Patient> diyerek temel tüm işlemleri miraz alıyoruz.
    public interface IPatientRepository : IRepository<Patient>
    {
        // İleride buraya sadece Hastalara özel metotlar yazacağız (Örn: TCKN ile hasta getir)
        void Update(Patient obj);
    }
}