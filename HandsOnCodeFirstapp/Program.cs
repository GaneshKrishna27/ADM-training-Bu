using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnCodeFirstapp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            stuContext sc = new stuContext();
            sc.stu.Add(new Stuinfo() { /*stuId = "1",*/ stuName = "gk" });
            sc.SaveChanges();
            Console.WriteLine("Record Added");

            Stuinfo stud = sc.stu.Find(1);
            Console.WriteLine("stuId:" + stud.stuId);
            Console.WriteLine("stuId:" + stud.stuName);
            Console.WriteLine("stuId:" + stud.phnNo);
            Console.WriteLine("record read succesfully");

            Stuinfo stud1 = sc.stu.Find(1);
            stud1.stuName = "ganesh";
            sc.Entry(stud1).State = EntityState.Modified;
            sc.SaveChanges();
            Console.WriteLine("record update succesfully");

            Stuinfo stud2 = sc.stu.Find(1);
            sc.stu.Remove(stud2);
            sc.SaveChanges();
            Console.WriteLine("record deleted succesfully");
        }
    }
    class Stuinfo
    {
        [Key]
        public int stuId { set; get; }
        public string stuName { set; get; }
        public string phnNo { set; get; }
    }
    class stuContext : DbContext
    {
        public DbSet<Stuinfo> stu { get; set; }
    }

}
