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
        static void MakeHimFail(ref Student student)
        {
            student.IsPassed=false;
        }
        static void MakeHimFail(Lecturer lecturer)
        {
            lecturer.IsPassed=false;

            lecturer = new Lecturer();
            lecturer.Name="Dummy Varun Naidu";
            lecturer.Id=1000;
            lecturer.IsPassed=true;
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

            MakeHimFail(ref student);
            MakeHimFail(lecturer);

            P(student);
            P("\n");
            P(lecturer);

            //Output

            // $ dotnet run
            // Id              : 1
            // Name            : Deepika Mohan
            // Result          : Failed // Property changed as it's reference is passed


            // Id              : 2 // Id didn't changes as it will create two different lecturer objects pointing to two different locations (In short no ref keyword)
            // Name            : Varun Naidu // Same case with this
            // Result          : Failed // Property changed as it's reference type

        }
    }
}
