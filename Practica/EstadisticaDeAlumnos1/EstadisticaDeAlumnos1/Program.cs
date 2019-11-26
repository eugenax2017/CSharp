using System;
using System.Collections.Generic;
using System.Linq;

namespace EstadisticaDeAlumnos1
{
    class Program
    {
        static List<double> Marks { get; set; }

         static void ShowMainMenu()
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("Opciones: 1 - Entrar datos");
            Console.WriteLine("Opciones: 2 - Estadistica");
            Console.WriteLine("Opciones: q - Salir");            
        }

        static void ShowMenuForDatos()
        {
            Console.WriteLine("Menu para entrar datos:");
            Console.WriteLine("Opciones: 1 - Add datos");
            Console.WriteLine("Opciones: 2 - Delete datos");
            Console.WriteLine("Opciones: 3 - Ver notas");
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
            Marks = new List<double>();
            Console.WriteLine("Bienvenidos al programa de gestión de clase!");
            ShowMainMenu(); //dentro del bukle?
            string key = "";
            string Texto = "";
            //const string empty = "No hay notas!";
            while (true)
            {
                key = Console.ReadLine();
                if (key == "q") break;
                if (key == "1")
                {
                    Console.Clear();
                    ShowMenuForDatos();
                    while (true)
                    {
                        key = Console.ReadLine();
                        if (key == "q")
                        {
                            Console.Clear();
                            ShowMainMenu();
                            break;
                        } 
                        if (key == "1")
                        {
                            while (true)
                            {
                                Console.WriteLine($"Entra nota {Marks.Count + 1} / q - exit");
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
                                    Marks.Add(nota);
                                }
                                else
                                {
                                    Console.WriteLine($"valor introducidio [{notaText}] no válido");
                                }
                            }                            
                        }
                        if (key == "2")
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
                                    Marks.RemoveAll(x => x == nota);
                                }
                                else
                                {
                                    Console.WriteLine($"Valor introducidio [{notaText}] no válido");
                                }
                            }
                        }
                        if (key == "3")
                        {
                            Texto = $"Notas: {string.Join(" ", Marks)}";
                            PrintConChangeColor(Texto);                            
                            ShowMenuForDatos();
                        }
                        
                    }                    
                }
                if (key == "2")
                {
                    Console.Clear();
                    if (Marks.Count == 0)
                        PrintConChangeColor("Atencion! La lista esta empty!");
                    ShowMenuForEstadistica();
                    while (true)
                    {
                        Texto ="";
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
                }
            }
        }
    }
}
