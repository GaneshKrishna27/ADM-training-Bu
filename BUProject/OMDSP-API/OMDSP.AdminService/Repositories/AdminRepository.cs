using OMDSP.AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDSP.AdminService.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly OMDSPDBContext _context;
        public AdminRepository(OMDSPDBContext context)
        {
            _context = context;
        }

        public void deleteNgo(string NgoId)
        {
            NgoList n = _context.NgoList.Find(NgoId);
            _context.Remove(n);
            _context.SaveChanges();
        }

        public NgoList GetNgoId(string NgoId)
        {
            return _context.NgoList.Find(NgoId);
        }

        public List<MedicineList> medicineList()
        {
            return _context.MedicineList.ToList();
        }

        public void ngoRegistration(NgoList ngolist)
        {
            _context.Add(ngolist);
            _context.SaveChanges();
        }

        public void updateNgo(NgoList ngolist)
        {
            _context.NgoList.Update(ngolist);
            _context.SaveChanges();
        }

        public List<Registration> userList()
        {
            return _context.Registration.ToList();
        }
    }
}
