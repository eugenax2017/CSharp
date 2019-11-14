using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fase 1
            int billete_5 = 0;
            int billete_10 = 0;
            int billete_20 = 0;
            int billete_50 = 0;
            int billete_100 = 0;
            int billete_200 = 0;
            int billete_500 = 0;
            int cost_total = 0;
            String[] platos = new String[5];
            int[] preus = new int[5];
            //Fase 2
            platos[0] = "Salada rusa";
            platos[1] = "Sopa de mariscos";
            platos[2] = "Antrecote";
            platos[3] = "Bistec";
            platos[4] = "Crema catalana";
            preus[0] = 4;
            preus[1] = 6;
            preus[2] = 8;
            preus[3] = 6;
            preus[4] = 3;
            Console.WriteLine("Ara tenim: ");
            for (var i = 0; i < platos.Length; i++)
            {
                Console.WriteLine($"Plato{i+1}: {platos[i]} - {preus[i]} EUR");
            }
            string key = "1";
            List<string> pedido = new List<string>();
            while (key == "1")
            {
                Console.WriteLine("Què vols menjar?");
                pedido.Add(Console.ReadLine().Trim());                
                do
                {
                    Console.WriteLine("Vols mes? 1:Si / 0:No");
                    key = Console.ReadLine().Trim();
                } while (key!="0" && key!="1");
                
            }
            Console.WriteLine();
            bool hay_en_carta;
            foreach (var item in pedido)
            {
                hay_en_carta = false;
                for (int i = 0; i < platos.Length; i++)
                {
                    if (item.Equals(platos[i]))
                    {
                        hay_en_carta = true;
                        cost_total += preus[i];
                        Console.WriteLine($"{item} - {preus[i]} EUR");
                        break;
                    }                  
                }
                if (!hay_en_carta)
                {
                    Console.WriteLine($"Producte {item} que hem demanat no existeix!");
                }                
            }
            Console.WriteLine($"Total cost son: {cost_total} EUR");
            int saldo = cost_total;            
            while (saldo>4) //seria mejor hacer con recurcia? (7 iteracions max)
            {
                int sum;
                if (saldo >= 500 && (sum = (saldo / 500)) >= 1)
                {
                    billete_500 += sum;
                    saldo -= sum * 500;
                }
                if (saldo >= 200 && (sum = (saldo / 200)) >= 1)
                {
                    billete_200 += sum;                    
                    saldo -= sum * 200;
                }
                if (saldo >= 100 && (sum = (saldo / 100)) >= 1)
                {
                    billete_100 += sum;                    
                    saldo -= sum * 100;
                }
                if (saldo >= 50 && (sum = (saldo / 50)) >= 1)
                {
                    billete_50 += sum;                    
                    saldo -= sum * 50;
                }
                if (saldo >= 20 && (sum = (saldo / 20)) >= 1)
                {
                    billete_20 += sum;                    
                    saldo -= sum * 20;
                }
                if (saldo >= 10 && (sum = (saldo / 10)) >= 1)
                {
                    billete_10 += sum;                    
                    saldo -= sum * 10;
                }
                if (saldo >= 5 && (sum = (saldo / 5)) >= 1)
                {
                    billete_5 += sum;                    
                    saldo -= sum * 5;
                }                
            }
            Console.WriteLine($"500 EUR: {billete_500}");
            Console.WriteLine($"200 EUR: {billete_200}");
            Console.WriteLine($"100 EUR: {billete_100}");
            Console.WriteLine($"50 EUR: {billete_50}");
            Console.WriteLine($"20 EUR: {billete_20}");
            Console.WriteLine($"10 EUR: {billete_10}");
            Console.WriteLine($"5 EUR: {billete_5}");
            Console.WriteLine($"Saldo: {saldo} EUR");
        }        
    }
}
