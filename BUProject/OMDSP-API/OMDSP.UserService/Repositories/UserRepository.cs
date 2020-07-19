using OMDSP.UserService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDSP.UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OMDSPDBContext _context;
        public UserRepository(OMDSPDBContext context)
        {
            _context = context;
        }
        public void donateMedicine(MedicineList medicinelist)
        {
            _context.Add(medicinelist);
            _context.SaveChanges();
        }

        public List<NgoList> searchNgo()
        {
            return _context.NgoList.ToList();
        }
    }
}
