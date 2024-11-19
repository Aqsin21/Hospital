using Final.Business.Exceptions;
using Final.Business.Extensions;
using Final.Business.Services.Abstarct;
using Final.Core.Models;
using Final.Core.RepositoryAbstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FileNotFoundException = Final.Business.Exceptions.FileNotFoundException;

namespace Final.Business.Services.Concretes
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IWebHostEnvironment _env;
        public DoctorService(IDoctorRepository doctorRepository, IWebHostEnvironment env)
        {
            _doctorRepository = doctorRepository;
            _env = env;
        }
        public async Task AddDoctor(Doctor doctor)
        {
            if (doctor.ImageFile == null)
                throw new FileNotFoundException("File bos ola bilmez!");

            doctor.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/doctors", doctor.ImageFile);
            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.CommitAsync();
        }

        public void DeleteDoctor(int id)
        {
            var existDoctor = _doctorRepository.Get(x => x.Id == id);
            if (existDoctor == null)
                throw new EntityNotFoundException("Hekim tapilmadi!");
            Helper.DeleteFile(_env.WebRootPath, @"uploads\doctors", existDoctor.ImageUrl);

            _doctorRepository.Delete(existDoctor);
            _doctorRepository.Commit();
        }

        public List<Doctor> GetAllDoctors(Func<Doctor, bool>? predicate = null)
        {
            return _doctorRepository.GetAll(predicate);
        }

        public Doctor GetDoctor(Func<Doctor, bool>? predicate = null)
        {
            return _doctorRepository.Get(predicate);
        }

        public void UpdateDoctor(int id, Doctor newDoctor)
        {
            var oldDoctor = _doctorRepository.Get(x => x.Id == id);

            if (oldDoctor == null)
                throw new EntityNotFoundException("Hekim tapilmadi!");

            if (newDoctor.ImageFile != null)
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\doctors", oldDoctor.ImageUrl);
                oldDoctor.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\doctors", newDoctor.ImageFile);
            }
            oldDoctor.Description = newDoctor.Description;
            oldDoctor.Experience = newDoctor.Experience;
            oldDoctor.FullName = newDoctor.FullName;


            _doctorRepository.Commit();
        }
    }
}