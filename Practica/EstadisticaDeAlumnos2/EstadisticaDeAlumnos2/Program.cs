using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstadisticaDeAlumnos2
{
    class Program
    {
        static List<Student> Students { get; set; }

        static List<Exam> Exams { get; set; }

        static List<Subject> Subjects { get; set; }

        //static Dictionary<Student, List<double>> Marks { get; set; }
        static List<double> Marks { get; set; }
        private static char key;
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void AddAlumno()
        {
            while (true)
            {                
                Console.WriteLine($"Entra alumno <dni*nombre*nota> {Students.Count + 1} / q - exit");
                string notaText = Console.ReadLine();
                if (notaText == "q")
                {
                    Console.Clear();
                    break;
                }
                char[] c1 = { '*' };
                string[] info = notaText.Split(c1);
                if (info.Length < 3)
                {
                    Console.WriteLine("Entered data is incorrect. Try again!");
                    continue;
                }
                var result = Students.Where(x => x.Dni == info[0]);
                double nota;
                if (double.TryParse(info[2].Replace(".", ","), out nota))
                {
                    if (result.Count() == 0)
                    {
                        Student NewStudent = new Student() { Dni = info[0], Name = info[1] };
                        NewStudent.Marks = new List<double>();
                        NewStudent.Marks.Add(nota);
                        Students.Add(NewStudent);
                    }
                    else if (result.Count() == 1)
                    {
                        Console.WriteLine($"Este alumno existe ya!");
                        foreach (var item in result) //or result.First() or result.ElementAt(0)
                            item.Marks.Add(nota);
                    }
                    else Console.WriteLine("Error! Dos alumnos tienen el mismo DNI!");
                }
                else
                {
                    Console.WriteLine($"valor introducidio [{notaText}] no válido");
                    Console.WriteLine("Entered data is incorrect. Try again!");
                    continue;
                }
            }
        }
        static void PrintNotas()
        {
            //ClearCurrentConsoleLine();
            foreach (var e in Exams)
            {
                string Texto = $"Student: {e.Student.Dni} {e.Student.Name} Exam: {e.Subject.Name} Nota: {e.Nota}";                
                PrintConChangeColor(Texto);
            }
        }
        static void PrintSujetos()
        {
            var i = 0;            
            foreach (var s in Subjects)
            {
                string Texto = $"Subject {i} = {s.Name}";                
                PrintConChangeColor(Texto);
                i++;
            }
        }
        static void PrintAlumnos()
        {
            foreach (var s in Students)
            {
                string Texto = $"{s.Dni} {s.Name} Notas: {string.Join(" ", s.Marks)}";
                //ClearCurrentConsoleLine();
                PrintConChangeColor(Texto);
            }
        }
        static void EditAlumno()
        {
            while (true)
            {
                Console.WriteLine("Menu edit students:");
                Console.WriteLine("Opciones: 1 - Incorrecto Nombre");
                if (Exams.Count == 0)
                {
                    Console.WriteLine("Opciones: 2 - Incorrecto dni");
                    Console.WriteLine("Opciones: 3 - Delete alumno");
                }               
                Console.WriteLine("Opciones: 4 - Ver alumnos");
                Console.WriteLine("Opciones: q - Salir");               
                key = Console.ReadKey().KeyChar;
                ClearCurrentConsoleLine();
                if (key == 'q')
                {
                    Console.Clear();
                    break;
                }
                if (key == '1')
                {
                    Console.WriteLine($"Entra nombre del alumno");
                    string nombre = Console.ReadLine();
                    var result = Students.Where(x => x.Name == nombre);
                    if (result.Count() > 0)
                    {
                        foreach (var item in result)
                        {
                            bool excess = false;
                            while (!excess)
                            {
                                Console.WriteLine($"Redactamos alumno: {item.Name}, {item.Dni}");
                                Console.WriteLine($"Entra nuevo dni del alumno / q - exit");                                
                                string dni = Console.ReadLine();
                                if (dni == "q") break;
                                if (string.IsNullOrWhiteSpace(dni) && Students.Where(x => x.Dni == dni).Count() > 0)
                                {
                                    Console.WriteLine("Dni es incorrecto, porque es empty o lo hay ya en la lista!");
                                    continue;
                                }
                                item.Dni = dni;
                                excess = true;
                            }                            
                        }                            
                    }
                }
                if (Exams.Count == 0)
                {
                    if (key == '2')
                    {
                        Console.WriteLine($"Entra dni del alumno");
                        string dni = Console.ReadLine();
                        var result = Students.Where(x => x.Dni == dni);
                        if (result.Count() > 0)
                        {
                            foreach (var item in result)
                            {
                                bool excess = false;
                                while (!excess)
                                {
                                    Console.WriteLine($"Redactamos alumno: {item.Name}, {item.Dni}");
                                    Console.WriteLine($"Entra nuevo nombre del alumno / q - exit");
                                    string nombre = Console.ReadLine();
                                    if (nombre == "q") break;
                                    if (string.IsNullOrWhiteSpace(dni))
                                    {
                                        Console.WriteLine("Nombre es incorrecto, porque es empty!");
                                        continue;
                                    }
                                    item.Name = nombre;
                                    excess = true;
                                }
                            }
                        }
                    }
                    if (key == '3')
                    {
                        Console.WriteLine($"Entra dni del alumno");
                        string dni = Console.ReadLine();
                        var result = Students.Where(x => x.Dni == dni);
                        if (result.Count() > 1 || result.Count() == 0)
                        {
                            Console.WriteLine("Error! Dos alumnos tienen el mismo DNI o no hay el alumno!");
                            continue;
                        }
                        Students.Remove(result.First());
                    }
                }                
                if (key == '4')
                {
                    PrintAlumnos();
                }                                   
            }
        }
        static void AddNotes()
        {
            while (true)
            {
                //ClearCurrentConsoleLine();
                Console.WriteLine("Entra notas <subjeto*dni*nota> / q - exit");
                string notaText = Console.ReadLine();
                if (notaText == "q")
                {
                    Console.Clear();
                    break;
                }
                char[] c1 = { '*' };
                string[] info = notaText.Split(c1);
                if (info.Length < 3)
                {
                    Console.WriteLine("Entered data is incorrect. Try again!");
                    continue;
                }
                var result = Students.Where(x => x.Dni == info[1]);
                if (result.Count() == 0)
                {
                    Console.WriteLine("Error! Este alumno no existe!");
                    continue;
                }
                Subject subject;
                //WriteInSubjects();
                var res_subjeto = Subjects.Where(x => x.Name == info[0]);
                if (res_subjeto.Count() == 0)
                {
                    subject = new Subject() { Name = info[0] };
                    Subjects.Add(subject);
                }
                else
                    subject = res_subjeto.First();
                double nota;
                if (double.TryParse(info[2].Replace(".", ","), out nota))
                {
                    //WriteInExams(student, subject, nota);
                    //EditExams(student, subject, nota);
                    var res_exam = Exams.Where(x => x.Student == result.First() && x.Subject == subject);
                    if (res_exam.Count() > 0)
                    {
                        Exam exam_exist = res_exam.First();
                        exam_exist.Nota = nota;
                    }                        
                    else
                    {
                        Exam exam = new Exam() { Student = result.First(), Subject = subject, Nota = nota };
                        Exams.Add(exam);
                    }
                    
                }
                else
                {
                    Console.WriteLine($"valor introducidio [{notaText}] no válido");
                    Console.WriteLine("Entered data is incorrect. Try again!");
                    continue;
                }                
            }
        }
        static void EditNotes()
        {
            while (true)
            {
                //ClearCurrentConsoleLine();
                Console.WriteLine($"Entra alumno y examen para redactar <dni*subjeto> / q - exit");
                string examen = Console.ReadLine();
                if (examen == "q")
                    break;
                char[] c1 = { '*' };
                string[] info = examen.Split(c1);
                if (info.Length < 2)
                {
                    Console.WriteLine("Entered data is incorrect. Try again!");
                    continue;
                }
                var res_exam = Exams.Where(x => x.Student.Dni == info[0] && x.Subject.Name == info[1]);
                if (res_exam.Count() > 0)
                {
                    Exam exam = res_exam.First();
                    Console.WriteLine($"Redactando: Student = {exam.Student.Dni}, {exam.Student.Name} Subject = {exam.Subject.Name} Nota = {exam.Nota}");
                    Console.WriteLine("Enter 'd' para - eleminar or nueva nota");
                    string notaText = Console.ReadLine();
                    if (notaText == "d")
                    {
                        Exams.Remove(exam);
                    }
                    else
                    {
                        double nota;
                        if (double.TryParse(notaText.Replace(".", ","), out nota))
                        {
                            exam.Nota = nota;
                        }
                        else
                        {
                            Console.WriteLine($"valor introducidio [{notaText}] no válido");
                            Console.WriteLine("Entered data is incorrect. Try again!");
                            continue;
                        }
                    }
                }
            }
        }
        static void ShowMainMenu()
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("Opciones: 1 - Gestionar alumnos");
            Console.WriteLine("Opciones: 2 - Añadir notas de alumnos");
            Console.WriteLine("Opciones: 3 - Estadistica");
            Console.WriteLine("Opciones: q - Salir");
        }
        static void ShowMenuForAlumnos()
        {
            while (true)
            {
                Console.WriteLine("Menu para gestionar alumnos:");
                Console.WriteLine("Opciones: 1 - Add alumno");
                Console.WriteLine("Opciones: 2 - Delete o edit del alumno");
                Console.WriteLine("Opciones: 3 - Ver alumnos");
                Console.WriteLine("Opciones: q - Salir");
                key = Console.ReadKey().KeyChar;
                ClearCurrentConsoleLine();
                if (key == 'q')
                {
                    Console.Clear();                   
                    break;
                }
                if (key == '1')
                {
                    AddAlumno();
                }

                if (key == '2')
                {
                    EditAlumno();
                }
                if (key == '3')
                {
                    PrintAlumnos();                    
                }                
            }
        }
        static void ShowMenuForNotas()
        {
            while (true)
            {
                Console.WriteLine("Menu para entrar datos:");
                Console.WriteLine("Opciones: 1 - Add datos");
                Console.WriteLine("Opciones: 2 - Delete o edit datos");
                Console.WriteLine("Opciones: 3 - Ver notas");
                Console.WriteLine("Opciones: 4 - Ver subjetos");
                Console.WriteLine("Opciones: q - Salir");
                key = Console.ReadKey().KeyChar;
                ClearCurrentConsoleLine();
                if (key == 'q')
                {
                    Console.Clear();
                    break;
                }
                if (key == '1')
                {
                    AddNotes();
                }
                if (key == '2')
                {
                    EditNotes();
                }
                if (key == '3')
                {
                    PrintNotas();
                }
                if (key == '4')
                {
                    PrintSujetos();
                }
            }  
        }
        static void ShowMenuForEstadistica()
        {            
            while (true)
            {
                Console.WriteLine("Menu de estadistica:");
                Console.WriteLine("Opciones: 1 - Promedio");
                Console.WriteLine("Opciones: 2 - Nota minima");
                Console.WriteLine("Opciones: 3 - Nota maxima");
                Console.WriteLine("Opciones: 4 - Ver notas");
                Console.WriteLine("Opciones: q - Salir");
                string Texto = "";
                key = Console.ReadKey().KeyChar;
                ClearCurrentConsoleLine();
                if (key == 'q')
                {
                    Console.Clear();                    
                    break;
                }                
                if (key == '1')
                    Texto = $"Promedio is {(Marks.Count == 0 ? 0 : Marks.Sum() / Marks.Count)}";

                if (key == '2')
                    Texto = $"Nota minima: {(Marks.Count == 0 ? 0 : Marks.Min(x => x))}";

                if (key == '3')
                    Texto = $"Nota maxima: {(Marks.Count == 0 ? 0 : Marks.Max(x => x))}";

                if (key == '4')
                    Texto = $"Notas: {string.Join(" ", Marks)}";

                if (!string.IsNullOrEmpty(Texto))
                    PrintConChangeColor(Texto);
                else
                    PrintConChangeColor("No hay notas!");                
            }            
        }
        static void PrintConChangeColor(string Texto)
        {
            //Console.Clear();
            ConsoleColor colorB = Console.BackgroundColor;
            ConsoleColor colorF = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Texto);
            Console.BackgroundColor = colorB;
            Console.ForegroundColor = colorF;
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //Marks = new List<double>(); CTRL-K+F - formating code
            Students = new List<Student>();
            Subjects = new List<Subject>();
            Exams = new List<Exam>();
            Console.WriteLine("Bienvenidos al programa de gestión de clase!");            
            //string Texto = ""; //global?            
            while (true)
            {
                Console.Clear();
                ShowMainMenu();
                key = Console.ReadKey().KeyChar;
                ClearCurrentConsoleLine();
                if (key == 'q') break;
                if (key == '1')
                {
                    Console.Clear();
                    ShowMenuForAlumnos();
                    
                }
                if (key == '2')
                {
                    Console.Clear();
                    ShowMenuForNotas();
                }
                if (key == '3')
                {
                    Marks = Exams.Select(x => x.Nota).ToList();
                    Console.Clear();
                    if (Marks.Count == 0)
                        PrintConChangeColor("Atencion! La lista esta empty!");
                    ShowMenuForEstadistica();                    
                }                
            }

        }
    }
}
