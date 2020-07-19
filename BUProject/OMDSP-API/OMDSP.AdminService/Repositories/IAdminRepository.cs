using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDSP.AdminService.Models;

namespace OMDSP.AdminService.Repositories
{
    public interface IAdminRepository
    {
        void ngoRegistration(NgoList ngolist);
        List<Registration> userList();
        List<MedicineList> medicineList();
        public void deleteNgo(string NgoId);
        void updateNgo(NgoList ngolist);
        NgoList GetNgoId(string NgoId);
    }
}
