using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fase 1
            char[] array_de_caracteres = { 'E', 'V', 'G', 'E', 'N', 'I', 'I', 'A', 'K', 'S', 'I', 'M', 'E', 'N', 'K', 'O' };
            for (int i=0; i< array_de_caracteres.Length; i++)
            {
                Console.Write(array_de_caracteres[i] + "\t");
            }
            Console.WriteLine();
            //Fase 2
            //List<char> list_de_caracteres = new List<char> { '7', ',', 'G', 'E', 'N', 'I', 'I', 'A', 'K', 'S', 'I', 'M', 'E', 'N', 'K', 'O' };
            List<char> list_de_caracteres = new List<char>(array_de_caracteres);
            foreach (char letra in list_de_caracteres)
            {
                if (char.IsLetter(letra))
                {
                    switch (char.ToLower(letra))
                    {
                        case 'a':
                        case 'e':
                        case 'o':
                        case 'i':    
                        case 'u':
                            Console.WriteLine($"{letra} is VOCAL");
                            break;
                        default:
                            Console.WriteLine($"{letra} is CONSONTANT");
                            break;
                    }
                }
                else if (char.IsDigit(letra))
                {
                    Console.WriteLine(letra + " - Els noms de persones no contenen números!");
                }
                else
                {
                    Console.WriteLine($"{letra} no es ni letra ni numero!");
                }
            }
            Console.WriteLine();
            //Fase 3
            List<char> list_de_caracteres_nombre = new List<char> {'E', 'V', 'G', 'E', 'N', 'I', 'I' };
            Dictionary<char, int> letras = new Dictionary<char, int>();
            for (int i = 0; i < list_de_caracteres_nombre.Count; i++)
            {
                char letra = list_de_caracteres_nombre[i];
                bool hayLetraYa = false;
                foreach (char item in letras.Keys)
                {
                    if (letra == item)
                        hayLetraYa = true;
                }
                if (hayLetraYa)
                    continue;
                int countOfLetra = 1;
                for (int j = i + 1 ; j < list_de_caracteres_nombre.Count; j++)
                {
                    if (letra == list_de_caracteres_nombre[j])
                        countOfLetra++;
                }
                letras.Add(letra, countOfLetra);
            }
            foreach (KeyValuePair<char, int> kvp in letras)
            {
                Console.WriteLine("Letra = {0}, Count = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine();
            //Fase 4
            List<char> list_de_caracteres_cognom = new List<char> { 'A', 'K', 'S', 'I', 'M', 'E', 'N', 'K', 'O' };
            List<char> list_final = new List<char>();
            foreach (var letra in list_de_caracteres_nombre)
            {
                list_final.Add(letra);
            }
            list_final.Add(' ');
            foreach (var letra in list_de_caracteres_cognom)
            {
                list_final.Add(letra);
            }
            foreach (var letra in list_final)
            {
                Console.Write(letra);
            }
            Console.WriteLine();
        }
    }
}
