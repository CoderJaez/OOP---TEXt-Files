using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//

namespace OOP_PRINCIPLES
{


    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("1: Add student \n2: Display students\n3:Exit");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        DisplayStudent();
                        break;
                    case "3":
                        flag = false;
                        break;

                }
            }
            Console.ReadKey();

        }


    
        private static void AddStudent()
        {
            string name;
            string address;

            Console.Write("Enter student name: ");
            name = Console.ReadLine();
            Console.Write("Enter student address: ");
            address = Console.ReadLine();

            //Get all the list first

            var studentList = new List<Student>();

            //ReadLine
            using (StreamReader rd = new StreamReader("student1.txt"))//FileNoTFound
            {
                var line = rd.ReadLine();

                while (line != null)
                {

                    string[] student = line.Split(',');
                    studentList.Add(new Student
                    {
                        Name = student[0],
                        Address = student[1]
                    });

                    line = rd.ReadLine();
                }
            }

            studentList.Add(new Student { Name = name, Address = address });

            using (StreamWriter wr = new StreamWriter("student1.txt"))
            {
                foreach(var student in studentList)
                {
                    wr.WriteLine($"{student.Name}, ${student.Address}"); 
                }
            }
        }


        private static void DisplayStudent()
        {
            var studentList = new List<Student>();

            //ReadLine
            using (StreamReader rd = new StreamReader("student1.txt"))//FileNoTFound
            {
                var line = rd.ReadLine();

                while (line != null)
                {

                    string[] student = line.Split(',');
                    studentList.Add(new Student
                    {
                        Name = student[0],
                        Address = student[1]
                    });

                    line = rd.ReadLine();
                }

                foreach (Student student in studentList)
                {
                    Console.WriteLine(string.Format("Student name: {0} Address:{1}", student.Name, student.Address));

                }
            }
        }
        public class Student
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }
    }
}
