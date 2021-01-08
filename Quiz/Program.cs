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

            // Losujemy pytanie => wywołujemy metodę na obiekcie gra (metodę Wylosuj pytanie)
            // docelowo będzie ona losowała pytanie z bazy pytań
            // na razie generuje Nam "Einsteina"
            Pytanie pytanie = gra.WylosujPytanie();



            // wyświetlamy pytanie1 => Czyli wywołujemy naszą metodę WyswietlPytanie przekazując do niej jako argument pytanie1
            // bo ten egzemplarz chcemy wyświetlić
            WyswietlPytanie(pytanie);


            // sprawdzamy co wpisał Użytkownik i zapisujemy to co wpisał w zmiennej o nazwie  odpowiedzUzytkownika (typu string)
            string odpowiedzUzytkownika = Console.ReadLine();



            // zmiana po wprowadzeniu losowosci odpowiedzi
            int numerPrawidlowejOdpowiedzi = pytanie.Odpowiedzi.First(x => x.CzyPrawidlowa).Kolejnosc;



            // ewaulujemy odpowiedź Użytkownika
            // innymi słowy => rozpatrujemy co mamy zrobić dalej po udzieleniu odpowiedzi przez Użytkownika
            // w zależności od tego czy jego odpowiedź jest prawidłowa czy nie
            if (odpowiedzUzytkownika == $"{numerPrawidlowejOdpowiedzi}")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WP("Brawo, to prawidłowa ospowiedź !!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else 
            {
                // oznacza to że wybrał inną odpowiedź niż "1" => czyli wybrał odpowiedź nieprawidłową
                Console.ForegroundColor = ConsoleColor.Red;
                WP("Niestety, przegrałeś, to nie jest dobra odpowiedź.");
                Console.ForegroundColor = ConsoleColor.White;
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

            // odpowiedzi wyświetlamy za pomocą pętli
            // dlatego też musieliśmy zamienić cztery osobne Odpowiedzi z klasy pytanie
            // na jedną listę z odpowiedziami


            // wersja z pętlą for
            // jako indeks elementu listy wstawiamy licznik pętli => i
            Console.WriteLine();
            //for (int i = 0; i < pytanie.Odpowiedzi.Count; i++)
            //{
            //    W($"{pytanie.Odpowiedzi[i].Id}. {pytanie.Odpowiedzi[i].Tresc}");
            //}

            //Console.WriteLine("Wersja z pętlą foreach");

            // wersja z pętlą foreach
            // pętlą specjalnie dedykowana dla list
            // dużo łatwiejsza w zastosowaniu w przypadku list
            // nie ma w niej licznika i indeksów elementów
            // po prostu pętla wykonuje się tyle razy ile jest elementów w liście

            foreach (Odpowiedz odpowiedz in pytanie.Odpowiedzi)
            {
                W($"{odpowiedz.Kolejnosc}. {odpowiedz.Tresc}");
            }

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
