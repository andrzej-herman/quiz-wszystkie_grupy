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

            // zmienna, która jest warunkiem "trwania pętli for"
            // musimy ją początkowo ustawić na true, aby pętla wykonała się przynajmniej raz
            // musimy przecież wyświetlić chociaż pierwsze pytanie
            bool uzytkownikOdpowiadaPrawidlowo = true;


            while (uzytkownikOdpowiadaPrawidlowo)
            {
                // Losujemy pytanie => wywołujemy metodę na obiekcie gra (metodę Wylosuj pytanie)
                // docelowo będzie ona losowała pytanie z bazy pytań
                // na razie generuje Nam "Einsteina"
                Pytanie pytanie = gra.WylosujPytanie();

                // wyświetlamy pytanie1 => Czyli wywołujemy naszą metodę WyswietlPytanie przekazując do niej jako argument pytanie1
                // bo ten egzemplarz chcemy wyświetlić
                WyswietlPytanie(pytanie);


                // sprawdzamy co wpisał Użytkownik i zapisujemy to co wpisał w zmiennej o nazwie  odpowiedzUzytkownika (typu string)
                string odpowiedzUzytkownika = Console.ReadLine();


                // zamieniamy odpowiedzUzytkownika na zmienną typu int
                int odpowiedzUzytkownikaJakoLiczba = int.Parse(odpowiedzUzytkownika);

                // sprawdzamy czy istnieje na liście odpowiedzi pytania które jednocześnie jest prawidłowe i jego kolejność
                // jest równa numerowi który podał Użytkownik
                Odpowiedz odpowiedz = pytanie.Odpowiedzi.FirstOrDefault(x => x.CzyPrawidlowa && x.Kolejnosc == odpowiedzUzytkownikaJakoLiczba);


                // ewaulujemy odpowiedź Użytkownika
                // innymi słowy => rozpatrujemy co mamy zrobić dalej po udzieleniu odpowiedzi przez Użytkownika
                // w zależności od tego czy jego odpowiedź jest prawidłowa czy nie
                // jeżeli zmienna "odpowiedz" jest różna od null wówczas odpowiedź jest prawidłowa
                if (odpowiedz != null)
                {
                    // odpowiedź prawidłowa
                    // najpierw musimy sprawdzić czy nie było to ostatnie pytanie
                    if (gra.AktualnaKategoria == 2000)
                    {
                        Console.WriteLine();
                        Console.Clear();
                        WP("Brawo, to prawidłowa ospowiedź !!!");
                        WP($"Wygrałeś/aś {gra.AktualnaKategoria} PLN");
                        WP("To było ostatnie pytanie. Jesteś Mistrzem !!!");
                        // komenda break powoduje bezwarunkowe wyjście z pętli
                        break;
                    }

                    // po udzieleniu poprawnej odpowiedzi uaktualniamy wartości zmiennych AktualnaWygrana oraz AktualnaKategoria
                    gra.UaktualnijDaneGry();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    WP("Brawo, to prawidłowa ospowiedź !!!");
                    WP($"Wygrałeś/aś {gra.AktualnaWygrana} PLN");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    // odpowiedź nieprawidłowa
                    // musimy przerwać działanie pętli while, więc trzeba zmienić warunek jej wykonania na false
                    uzytkownikOdpowiadaPrawidlowo = false;
                    // Informujamy o przegranej
                    Console.ForegroundColor = ConsoleColor.Red;
                    WP("Niestety, przegrałeś, to nie jest dobra odpowiedź. To koniec gry");
                    Console.ForegroundColor = ConsoleColor.White;
                }
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

            // wersja z pętlą for
            // jako indeks elementu listy wstawiamy licznik pętli => i
            Console.WriteLine();
            //for (int i = 0; i < pytanie.Odpowiedzi.Count; i++)
            //{
            //    W($"{pytanie.Odpowiedzi[i].Id}. {pytanie.Odpowiedzi[i].Tresc}");
            //}



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
