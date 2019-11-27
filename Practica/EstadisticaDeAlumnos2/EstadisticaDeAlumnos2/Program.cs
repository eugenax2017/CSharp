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

        static Dictionary<Student, List<double>> Marks { get; set; }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
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
            Console.WriteLine("Menu para gestionar alumnos:");
            Console.WriteLine("Opciones: 1 - Add alumno");
            Console.WriteLine("Opciones: 2 - Delete o edit del alumno");
            Console.WriteLine("Opciones: 3 - Ver alumnos");
            Console.WriteLine("Opciones: q - Salir");
        }
        static void ShowMenuForNotas()
        {
            Console.WriteLine("Menu para entrar datos:");
            Console.WriteLine("Opciones: 1 - Add datos");
            Console.WriteLine("Opciones: 2 - Delete datos");
            Console.WriteLine("Opciones: 3 - Ver notas");
            Console.WriteLine("Opciones: 4 - Ver subjetos");
            Console.WriteLine("Opciones: q - Salir");
        }
        static void ShowMenuForEstadistica()
        {
            Console.WriteLine("Menu de estadistica:");
            Console.WriteLine("Opciones: 1 - Promedio");
            Console.WriteLine("Opciones: 2 - Nota minima");
            Console.WriteLine("Opciones: 3 - Nota maxima");
            Console.WriteLine("Opciones: 4 - Ver notas");
            Console.WriteLine("Opciones: q - Salir");
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
            Console.WriteLine("Bienvenidos al programa de gestión de clase!");
            ShowMainMenu(); 
            char key; //global?
            string Texto = ""; //global?
            
            while (true)
            {
                key = Console.ReadKey().KeyChar;
                if (key == 'q') break;
                if (key == '1')
                {
                    Console.Clear();
                    ShowMenuForAlumnos();
                    while (true)
                    {
                        key = Console.ReadKey().KeyChar;
                        if (key == 'q')
                        {
                            Console.Clear();
                            ShowMainMenu();
                            break;
                        }
                        if (key == '1')
                        {
                            while (true)
                            {
                                ClearCurrentConsoleLine();
                                Console.WriteLine($"Entra alumno <dni*nombre*nota> {Students.Count + 1} / q - exit");
                                string notaText = Console.ReadLine();
                                if (notaText == "q")
                                {
                                    Console.Clear();
                                    ShowMenuForAlumnos();
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
                        /*if (key == '2')
                        {
                            while (true)
                            {
                                Console.WriteLine($"Entra nota para eliminar / q - exit");
                                string notaText = Console.ReadLine();
                                if (notaText == "q")
                                {
                                    Console.Clear();
                                    ShowMenuForDatos();
                                    break;
                                }
                                double nota;
                                if (double.TryParse(notaText.Replace(".", ","), out nota))
                                {
                                    //var search_result = Marks.Where(x => x == nota);
                                    //Marks.RemoveAll(x => x == nota);
                                }
                                else
                                {
                                    Console.WriteLine($"Valor introducidio [{notaText}] no válido");
                                }
                            }
                        }*/
                        if (key == '3')
                        {
                            foreach (var s in Students)
                            {
                                Texto = $"{s.Dni} {s.Name} Notas: {string.Join(" ", s.Marks)}";
                                ClearCurrentConsoleLine();
                                PrintConChangeColor(Texto);
                            }
                            ShowMenuForAlumnos();
                        }

                    }
                }
                /*if (key == "2")
                {
                    Console.Clear();
                    if (Marks.Count == 0)
                        PrintConChangeColor("Atencion! La lista esta empty!");
                    ShowMenuForEstadistica();
                    while (true)
                    {
                        Texto = "";
                        key = Console.ReadLine();
                        if (key == "q")
                        {
                            Console.Clear();
                            ShowMainMenu();
                            break;
                        }
                        //if (Marks.Count > 0) {}
                        if (key == "1")
                            Texto = $"Promedio is {(Marks.Count == 0 ? 0 : Marks.Sum() / Marks.Count)}";

                        if (key == "2")
                            Texto = $"Nota minima: {(Marks.Count == 0 ? 0 : Marks.Min(x => x))}";

                        if (key == "3")
                            Texto = $"Nota maxima: {(Marks.Count == 0 ? 0 : Marks.Max(x => x))}";

                        if (key == "4")
                            Texto = $"Notas: {string.Join(" ", Marks)}";

                        if (!string.IsNullOrEmpty(Texto))
                            PrintConChangeColor(Texto);
                        else
                            PrintConChangeColor("No hay notas!");

                        ShowMenuForEstadistica();
                    }
                }*/
            
            }

        }
    }
}
