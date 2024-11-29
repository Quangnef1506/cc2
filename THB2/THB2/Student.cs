using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace THB2
{
    internal class Student
    {

        private string id;
        private string name;
        private float score;
        private string faculty;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float Score { get => score; set => score = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Student() { }
        public Student(string id, string name, float score, string faculty)
        {
            this.id = id;
            this.name = name;
            this.score = score;
            this.faculty = faculty;
        }
        public void input()
        {
            Console.WriteLine("Nhap MS: ");
            id = Console.ReadLine();
            Console.WriteLine("Nhap ten: ");
            name = Console.ReadLine();
            Console.WriteLine("Nhap diemTB: ");
            score = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhap khoa: ");
            faculty = Console.ReadLine();


        }
        public void show()
        {
            Console.WriteLine("MSSV:{0}, Ho ten: {1}, Khoa: {2}, DiemTB: {3}", this.id, this.name, this.faculty, this.score);
        }

    }
}
