using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {

            Mediator mediator = new Mediator();
            
            Teacher ugur = new Teacher(mediator);
            ugur.Name = "Uğur";

            mediator.Teacher = ugur;

            Student mehmet = new Student(mediator);
            mehmet.Name = "Mehmet";
            Student zeynep = new Student(mediator);
            zeynep.Name = "Zeynep";

            mediator.Students = new List<Student> { mehmet,zeynep };

            ugur.SendNewImageURl("slide1.jpg");

            ugur.RecieveQuestion("is it true?",mehmet);

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator):base(mediator)
        {
                
        }
        public string Name { get; set; }
        public void RecieveQuestion(string quest, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0} {1}",student.Name,quest);
        }

        public void SendNewImageURl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image: {0}",url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student received answer {0}",answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string quest,Student student)
        {
            Teacher.RecieveQuestion(quest,student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
