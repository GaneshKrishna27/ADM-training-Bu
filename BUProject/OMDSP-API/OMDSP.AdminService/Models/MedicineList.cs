using System;
using System.Collections.Generic;

namespace OMDSP.AdminService.Models
{
    public partial class MedicineList
    {
        public string MId { get; set; }
        public string MName { get; set; }
        public DateTime ExpDate { get; set; }
        public string DonorName { get; set; }
        public string DonorCity { get; set; }
        public string DonorAddress { get; set; }
        public string DonorMobile { get; set; }
    }
}
