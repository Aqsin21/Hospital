using Final.Core.Models;
using Final.Core.RepositoryAbstract;
using Final.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.RepositoryConcretes
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}