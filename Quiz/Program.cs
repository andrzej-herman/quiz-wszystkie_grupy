using Quiz.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // tworzenie gry
            // utworzenie instancji klasy Gra
            Gra gra = new Gra();

            // utworzenie egzemplarza klasy Pytanie o nazwie pytanie1 
            Pytanie pytanie1 = new Pytanie();
            pytanie1.Id = 1;
            pytanie1.Kategoria = 500;
            pytanie1.Tresc = "Jak miał na imię Einstein?";
            pytanie1.Odpowiedz_1 = new Odpowiedz();
            pytanie1.Odpowiedz_1.Id = 1;
            pytanie1.Odpowiedz_1.Tresc = "Albert";
            pytanie1.Odpowiedz_1.CzyPrawidlowa = true;
            pytanie1.Odpowiedz_2 = new Odpowiedz();
            pytanie1.Odpowiedz_2.Id = 2;
            pytanie1.Odpowiedz_2.Tresc = "Aaron";
            pytanie1.Odpowiedz_3 = new Odpowiedz();
            pytanie1.Odpowiedz_3.Id = 3;
            pytanie1.Odpowiedz_3.Tresc = "Andrew";
            pytanie1.Odpowiedz_4 = new Odpowiedz();
            pytanie1.Odpowiedz_4.Id = 4;
            pytanie1.Odpowiedz_4.Tresc = "Anthony";



            // wyświetlamy pytanie1 => Czyli wywołujemy naszą metodę WyswietlPytanie przekazując do niej jako argument pytanie1
            // bo ten egzemplarz chcemy wyświetlić
            WyswietlPytanie(pytanie1);


            // sprawdzamy co wpisał Użytkownik i zapisujemy to co wpisał w zmiennej o nazwie  odpowiedzUzytkownika (typu string)
            string odpowiedzUzytkownika = Console.ReadLine();


            // ewaulujemy odpowiedź Użytkownika
            // innymi słowy => rozpatrujemy co mamy zrobić dalej po udzieleniu odpowiedzi przez Użytkownika
            // w zależności od tego czy jego odpowiedź jest prawidłowa czy nie
            if (odpowiedzUzytkownika == "1")
            {
                // kod się wykona, jeżeli Użytkownik wpisał "1" => w naszym przypadku to prawidłowa odpowiedź
                // ponieważ ustawiliśmy Odpowiedz_1 jako prawidłową
                Console.ForegroundColor = ConsoleColor.Green;
                WP("Brawo, to prawidłowa ospowiedź !!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (odpowiedzUzytkownika == "2" || odpowiedzUzytkownika == "3" || odpowiedzUzytkownika == "4")
            {
                // kod się wykona, jeżeli Użytkownik wpisał "2" lub "3" lub "4" 
                // oznacza to że wybrał inną odpowiedź niż "1" => czyli wybrał odpowiedź nieprawidłową
                Console.ForegroundColor = ConsoleColor.Red;
                WP("Niestety, przegrałeś, to nie jest dobra odpowiedź.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                // kod się wykona, jeżeli Użytkownik wpisał cokolwiek innego niż "1" i "2" i "3" i "4" 
                // oznacza to że nie postąpił zgodnie z instrukcją. Być może wybrał inny klawisz przez pomyłkę
                // dajemy mu szansę ponownie.
                // Wyświtlamy zatem komunikat i jeszcze raz wyświetlamy pytanie oraz czakamy na odpowiedź
                WP("Wcisnąłeś nieprawidłowy przycisk. Spróbuj jeszcze raz");
                WyswietlPytanie(pytanie1);
                odpowiedzUzytkownika = Console.ReadLine();
            }


            // żeby nam się okienko nie zamykało
            Console.ReadLine();
        }


        // metoda wyświetlająca pytanie w konsoli
        // wyświetla pytanie przekazne jej jako argument (egzemplarz obiektu Pytanie)
        // pamiętajmy => gdy ją wywołujemy przekazujemy do niej egzemplarz (instancję) Pytania
        static void WyswietlPytanie(Pytanie pytanie)
        {
            WP($"Pytanie za {pytanie.Kategoria} PLN");
            WP(pytanie.Tresc);
            WP($"{pytanie.Odpowiedz_1.Id}. {pytanie.Odpowiedz_1.Tresc}");
            W($"{pytanie.Odpowiedz_2.Id}. {pytanie.Odpowiedz_2.Tresc}");
            W($"{pytanie.Odpowiedz_3.Id}. {pytanie.Odpowiedz_3.Tresc}");
            W($"{pytanie.Odpowiedz_4.Id}. {pytanie.Odpowiedz_4.Tresc}");
            WP("Proszę wcisnąć 1, 2, 3 lub 4");
        }



        // metoda upraszczająca => żeby ciągle nie pisać Console.WriteLine()
        // wyswietla tekst przekazany jako argument.
        static void W(string tekst)
        {
            Console.WriteLine(tekst);
        }


        // metoda upraszczająca => żeby ciągle nie pisać Console.WriteLine()
        // wyswietla tekst przekazany jako argument poprzedzony jedną pista linią.
        static void WP(string tekst)
        {
            Console.WriteLine();
            Console.WriteLine(tekst);
        }


    }
}
