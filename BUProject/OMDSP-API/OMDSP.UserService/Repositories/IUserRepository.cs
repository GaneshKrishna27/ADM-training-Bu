using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDSP.UserService.Models;

namespace OMDSP.UserService.Repositories
{
    public interface IUserRepository
    {
        List<NgoList> searchNgo();
        void donateMedicine(MedicineList medicinelist);
    }
}
