using System;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Print_array(String[] array_letras)
        {
            foreach (var item in array_letras)
            {
                Console.Write(item);
            }
            Console.Write("\n");
        }
        static String[] Split (String string1)
        {
            String[] array_letras = new String[string1.Length];
            for (var i = 0; i < string1.Length; i++)
            {
                array_letras[i] = string1.Substring(i, 1);
            }
            return array_letras;
        } 
        static void Sort_of_array_string (String[] arrayCiutats)
        {
            for (var i = 0; i < arrayCiutats.Length; i++)
            {
                var min_index = i;
                for (var j = i + 1; j < arrayCiutats.Length; j++)
                {
                    if (arrayCiutats[min_index].CompareTo(arrayCiutats[j]) > 0)
                        min_index = j;
                }
                if (i != min_index)
                {
                    String temp = arrayCiutats[i];
                    arrayCiutats[i] = arrayCiutats[min_index];
                    arrayCiutats[min_index] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            //Fase 1
            String string1 = new String("");
            String string2 = new String("");
            String string3 = new String("");
            String string4 = new String("");
            String string5 = new String("");
            String string6 = "";
            Console.Write("Enter name of city 1: ");
            string1 = Console.ReadLine();
            Console.Write("Enter name of city 2: ");
            string2 = Console.ReadLine();
            Console.Write("Enter name of city 3: ");
            string3 = Console.ReadLine();
            Console.Write("Enter name of city 4: ");
            string4 = Console.ReadLine();
            Console.Write("Enter name of city 5: ");
            string5 = Console.ReadLine();
            Console.Write("Enter name of city 6: ");
            string6 = Console.ReadLine();
            //Fase 2
            String[] arrayCiutats = { string1, string2, string3, string4, string5, string6 };
            Sort_of_array_string(arrayCiutats); //or Array.Sort(arrayCiutats);
            foreach (var item in arrayCiutats) 
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Fase 3
            String[] arrayCiutatsModificades = { string1.Replace('a', '4'), string2.Replace('a', '4'), string3.Replace('a', '4'), string4.Replace('a', '4'), string5.Replace('a', '4'), string6.Replace('a', '4') };
            Sort_of_array_string(arrayCiutatsModificades); //or Array.Sort(arrayCiutatsModificades);
            foreach (var item in arrayCiutatsModificades)
            {               
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Fase 4
            String[] array_letras1 = new String[string1.Length];
            String[] array_letras2 = new String[string2.Length];
            String[] array_letras3 = new String[string3.Length];
            String[] array_letras4 = new String[string4.Length];
            String[] array_letras5 = new String[string5.Length];
            String[] array_letras6 = new String[string6.Length];
            array_letras1 = Split(string1); //or array_letras1 = string1.Split();
            array_letras2 = Split(string2); //or array_letras2 = string2.Split();
            array_letras3 = Split(string3); //or array_letras3 = string3.Split();
            array_letras4 = Split(string4); //or array_letras4 = string4.Split();
            array_letras5 = Split(string5); //or array_letras5 = string5.Split();
            array_letras6 = Split(string6); //or array_letras6 = string6.Split();
            Array.Reverse(array_letras1);
            Array.Reverse(array_letras2);
            Array.Reverse(array_letras3);
            Array.Reverse(array_letras4);
            Array.Reverse(array_letras5);
            Array.Reverse(array_letras6);
            Print_array(array_letras1);
            Print_array(array_letras2);
            Print_array(array_letras3);
            Print_array(array_letras4);
            Print_array(array_letras5);
            Print_array(array_letras6);
        }
    }
}
