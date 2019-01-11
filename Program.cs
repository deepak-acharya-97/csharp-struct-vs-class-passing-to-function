using System;

namespace play_with_struct_vs_class_passing_to_function
{
    class Program
    {
        public static void P(dynamic msg) => Console.WriteLine(msg);
        struct Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsPassed { get; set; }

            public override string ToString()
            {
                var result=this.IsPassed ? "Passed":"Failed";
                return $"Id              : {this.Id}\nName            : {this.Name}\nResult          : {result}";
            }

        }
        class Lecturer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsPassed { get; set; }

            public override string ToString()
            {
                var result=this.IsPassed ? "Passed":"Failed";
                return $"Id              : {this.Id}\nName            : {this.Name}\nResult          : {result}";
            }
        }
        static void MakeHimFail(Student student)
        {
            student.IsPassed=false;
        }
        static void MakeHimFail(Lecturer lecturer)
        {
            lecturer.IsPassed=false;
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Id=1;
            student.Name="Deepika Mohan";
            student.IsPassed=true;

            Lecturer lecturer = new Lecturer();
            lecturer.Id=2;
            lecturer.Name="Varun Naidu";
            lecturer.IsPassed=true;

            MakeHimFail(student);
            MakeHimFail(lecturer);

            P(student);
            P("\n");
            P(lecturer);

            //Output

            // $ dotnet run
            // Id              : 1
            // Name            : Deepika Mohan
            // Result          : Passed // Property didn't changed as it's value type


            // Id              : 2
            // Name            : Varun Naidu
            // Result          : Failed // Property changed as it's reference type

        }
    }
}
