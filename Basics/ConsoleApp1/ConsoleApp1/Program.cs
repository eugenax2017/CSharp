using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fase 1
            string nom = "Evgenii";
            string cognom1 = "Aksimenko";
            string cognom2 = "Nikolaevich";
            int dia = 16;
            int mes = 9;
            int any = 1980;
            Console.WriteLine($"{cognom1} {cognom2}, {nom}");
            Console.WriteLine("{0}/{1}/{2}", dia, mes, any);
            Console.WriteLine();
            //Fase 2
            int any_inici = 1948;
            int[] any_traspas = new[] {1948, 1952, 1956, 1960, 1964, 1968, 1972, 1976, 1980};            
            Console.WriteLine("Count of leap years: " + any_traspas.Length);
            Console.WriteLine();
            //Fase 3
            const string frase_true = "This year is leap: ";
            const string frase_false = "This year isn´t leap: ";
            bool print_frase_true = false;
            for (int i=0; i<any_traspas.Length; i++)
            {
                Console.WriteLine("Leap year is: " + any_traspas[i]);
            }
            for (int i=any_inici; i<=any; i++)
            {
                for (int j=0; j<any_traspas.Length; j++)
                {
                    if (i == any_traspas[j])
                    {
                        print_frase_true = true;
                        break;
                    } 
                    else
                        print_frase_true = false;
                }
                if (print_frase_true) 
                    Console.WriteLine(frase_true + i);
                else
                    Console.WriteLine(frase_false + i);
            }
            Console.WriteLine();
            //Fase 4
            string fullName = $"{nom} {cognom2} {cognom1}";
            string dataDeNacio = dia + "/" + mes + "/" + any;
            bool meu_Any_trespas = false;
            for (int i=0; i<any_traspas.Length; i++) 
            {
                if (any_traspas[i] == any) 
                {
                    meu_Any_trespas = true;
                    break;
                }
            }
            Console.WriteLine("El meu nom és " + fullName);
            Console.WriteLine("Vaig néixer el " + dataDeNacio);
            if (meu_Any_trespas)
                Console.WriteLine("El meu any de naixement és de traspàs");
            else
                Console.WriteLine("El meu any de naixement no és de traspàs");
            Console.ReadKey();
        }        
    }
}
