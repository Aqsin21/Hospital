using Final.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Business.Services.Abstarct
{
    public interface IDoctorService
    {
        Task AddDoctor(Doctor doctor);
        void DeleteDoctor(int id);
        void UpdateDoctor(int id, Doctor newDoctor);
        Doctor GetDoctor(Func<Doctor, bool>? predicate = null);
        List<Doctor> GetAllDoctors(Func<Doctor, bool>? predicate = null);
    }
}
