using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            dbfDBEntities sc = new dbfDBEntities();
            //sc.stuinfoes.Add(new stuinfo() { stuId = "4", stuName = "gk", phnNo = "123" });
            //sc.SaveChanges();
            //Console.WriteLine("Record Added");

            stuinfo stud = sc.stuinfoes.Find("1");
            Console.WriteLine("stuId:" + stud.stuId);
            Console.WriteLine("stuId:" + stud.stuName);
            Console.WriteLine("stuId:" + stud.phnNo);
            Console.WriteLine("record read succesfully");

            //stuinfo stud1 = sc.stuinfoes.Find("1");
            //stud1.stuName = "ganeshk";
            //sc.Entry(stud1).State = EntityState.Modified;
            //sc.SaveChanges();
            //Console.WriteLine("record update succesfully"); 

            ////stuinfo stud2 = sc.stuinfoes.Find("4");
            ////sc.stuinfoes.Remove(stud2);
            ////sc.SaveChanges();
            ////Console.WriteLine("record deleted succesfully");

        }
    }
}
