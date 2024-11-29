using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THB2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===Menu===");
                Console.WriteLine("1. Them SV");
                Console.WriteLine("2. Hien thi danh sach SV");
                Console.WriteLine("3.Hien thi danh sach Sv thuoc khoa CNTT");
                Console.WriteLine("4.Hien thi sinh vien có diemTb lon hon 5");
                Console.WriteLine("5.Hien thi  sinh vien có diemTb tang dan ");
                Console.WriteLine("6.Hien thi  sinh vien có diemTb  lon hon 5 va thuoc CNTT  ");
                Console.WriteLine("7.Hien thi  sinh vien co diemTb cao nhat  va thuoc CNTT  ");
                Console.WriteLine("8.Hien thi danh sach diem Theo xep hang");
                Console.WriteLine("0. Thoat");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        DisplayStudent(students);
                        break;
                    case "3":
                        DisplayStudentGradesFromCNTT(students);
                        break;
                    case "4":
                        DisplayStudentsWithScoreAbove5(students);
                        break;
                    case "5":
                        DisplayStudentsByAscendingScore(students);
                        break;
                    case "6":
                        DisplayStudentsWithScoreAbove5andfromCNTT(students);
                        break;

                    case "7":
                        DisplayStudentsWithScoreAbove5andfromCNTT(students);
                        break;

                    case "8":
                        DisplayStudentGrades(students);
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Ket thuc chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Tuy chon khong hop le!");
                        break;
                }
            }
            Console.WriteLine();

        }

        private static void DisplayStudent(List<Student> students)
        {
            Console.WriteLine("===Danh sach SV===");
            foreach (Student sd in students)
            {
                sd.show();
            }
        }

        private static void AddStudent(List<Student> students)
        {
            Console.WriteLine("===Them SV)");
            Student sd = new Student();
            sd.input();
            students.Add(sd);
            Console.WriteLine("Them thanh cong!");
        }
        private static void DisplayStudentsWithScoreAbove5(List<Student> students)
        {
            Console.WriteLine("===Danh sách sinh viên có điểm trung bình >= 5 v===");
            var filteredStudents = students.Where(s => s.Score >= 5).ToList();

            if (filteredStudents.Count > 0)
            {
                foreach (var student in filteredStudents)
                {
                    student.show(); 
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào có điểm trung bình >= 5.");
            }
        }
        private static void DisplayStudentsWithScoreAbove5andfromCNTT(List<Student> students)
        {

            Console.WriteLine("===Danh sách sinh viên có điểm trung bình >= 5 v===");
            var filteredStudents = students.Where(s => s.Score >= 5 &&  s.Faculty=="CNTT" ).ToList();

            if (filteredStudents.Count > 0 )
            {
                 foreach (var student in filteredStudents)
                {
                    student.show();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào có điểm trung bình >= 5 va thuoc khoa CNTT");
            }

        }
        private static void DisplayStudentsByAscendingScore(List<Student> students)
        {
            Console.WriteLine("===Danh sách sinh viên theo điểm trung bình tăng dần===");
            var sortedStudents = students.OrderBy(s => s.Score).ToList(); // Sắp xếp danh sách theo điểm trung bình tăng dần

            if (sortedStudents.Count > 0)
            {
                foreach (var student in sortedStudents)
                {
                    student.show(); // Giả định phương thức `show` in thông tin sinh viên
                }
            }
            else
            {
                Console.WriteLine("Danh sách sinh viên trống.");
            }
        }

        private static void DisplayStudentGrades(List<Student> students)
        {
            Console.WriteLine("===Xếp loại sinh viên===");

            int gioi = 0, kha = 0, trungBinh = 0, yeu = 0;

            foreach (Student sd in students)
            {
                if (sd.Score >= 8)
                    gioi++;
                else if (sd.Score >= 6.5)
                    kha++;
                else if (sd.Score >= 5)
                    trungBinh++;
                else
                    yeu++;
            }

            Console.WriteLine($"Số lượng sinh viên xếp loại Giỏi: {gioi}");
            Console.WriteLine($"Số lượng sinh viên xếp loại Khá: {kha}");
            Console.WriteLine($"Số lượng sinh viên xếp loại Trung Bình: {trungBinh}");
            Console.WriteLine($"Số lượng sinh viên xếp loại Yếu: {yeu}");
        }
        private static void DisplayStudentGradesFromCNTT(List<Student> students)
        {
            Console.WriteLine("===Xếp loại sinh viên thuộc khoa CNTT===");

            // Lọc danh sách sinh viên thuộc khoa CNTT
            var cnttStudents = students.Where(s => s.Faculty == "CNTT").ToList();

            if (cnttStudents.Count > 0)
            {
                int gioi = 0, kha = 0, trungBinh = 0, yeu = 0;

                foreach (var student in cnttStudents)
                {
                    if (student.Score >= 8)
                        gioi++;
                    else if (student.Score >= 6.5)
                        kha++;
                    else if (student.Score >= 5)
                        trungBinh++;
                    else
                        yeu++;
                }

                Console.WriteLine($"Số lượng sinh viên xếp loại Giỏi (CNTT): {gioi}");
                Console.WriteLine($"Số lượng sinh viên xếp loại Khá (CNTT): {kha}");
                Console.WriteLine($"Số lượng sinh viên xếp loại Trung Bình (CNTT): {trungBinh}");
                Console.WriteLine($"Số lượng sinh viên xếp loại Yếu (CNTT): {yeu}");
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa CNTT.");
            }
        }
        private static void DisplayTopStudentFromCNTT(List<Student> students)
        {
            Console.WriteLine("===Sinh viên có điểm trung bình cao nhất thuộc khoa CNTT===");

            var cnttStudents = students.Where(s => s.Faculty == "CNTT").ToList();

            if (cnttStudents.Count > 0)
            {
                var topStudent = cnttStudents.OrderByDescending(s => s.Score).FirstOrDefault();

             
                Console.WriteLine("Thông tin sinh viên có điểm cao nhất:");
                topStudent.show(); 
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa CNTT.");
            }
        }


    }
}
