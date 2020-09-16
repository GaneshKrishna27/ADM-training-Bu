using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnCodeFirstApproach
{
    public class Stuinfo    
    {
        
        public string stuId { set; get; }
        public string stuName { set; get; }
        public string phnNo { set; get; }
    }
    public class stuContext:DbContext
    {
        public DbSet<Stuinfo> stu { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            stuContext sc = new stuContext();
            sc.stu.Add(new Stuinfo() { stuId="1", stuName = "gk", phnNo = "123" });
            sc.SaveChanges();
            Console.WriteLine("Record Added");

            //Stuinfo stud = sc.stu.Find(1);
            //Console.WriteLine("stuId:" + stud.stuId);
            //Console.WriteLine("stuId:" + stud.stuName);
            //Console.WriteLine("stuId:" + stud.phnNo);
            //Console.WriteLine("record read succesfully");

            //Stuinfo stud1 = sc.stu.Find(1);
            //stud1.stuName = "ganesh";
            //sc.Entry(stud1).State = EntityState.Modified;
            //sc.SaveChanges();
            //Console.WriteLine("record update succesfully");

            //Stuinfo stud2 = sc.stu.Find(1);
            //sc.stu.Remove(stud2);
            //sc.SaveChanges();
            //Console.WriteLine("record deleted succesfully");
        }
    }
}
//using (var context=new stuContext())
//{
//    var stu1 = new Stuinfo 
//    { 
//    stuId = Console.ReadLine(),
//    stuName=Console.ReadLine(),
//    phnNo=Console.ReadLine()
//    };
//    context.stu.Add(stu1);
//    context.SaveChanges();
//    Console.WriteLine("Record Added");
//}