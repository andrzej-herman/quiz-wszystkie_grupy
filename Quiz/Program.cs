using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Program
    {
        // zapewne jak się domyślacie ten kod będzie ulegał zmianie w trakcie naszej nauki i pisania Quizu
        // Na razie przedstawia się tak:


        static void Main(string[] args)
        {
            WyswietlTytulQuizu("Andrzej Herman");
            Console.ReadLine();
        }



        // metoda, która wyswietla czołówkę naszego Quizu => żeby był większy bajer :)
        static void WyswietlTytulQuizu(string imie_i_nazwisko_autora)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            W("*************************************************************************");
            W();
            W("                                QUIZ                                     ");
            W($"                       Autor: {imie_i_nazwisko_autora}                  ");
            W();
            W("*************************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // skróciłem sobie, żeby nie musieć ciągle pisać: Console.WriteLine ....
        static void W(string text = null)
        {
            Console.WriteLine(text);
        }


    }
}
