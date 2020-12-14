using Newtonsoft.Json;
using Quiz.Backend.Extra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Backend
{
    // klasa reprezentująca główny obiekt w grze => Gra
    public class Gra
    {
        // konstruktor klasy (specjalna metoda)
        // jest wywoływany w momencie tworzenia nowego egzemplarza danej klasy
        // w momencie użycia słówka "new"
        // możemy do niego "włożyć" kod, który chcemy aby się wykonał w momencie utworzenia nowej instancji klasy
        // w naszym przypadku ustawiamy wartość aktualnej kategorii pytania na 500
        // oraz budujemy całą bazę pytań gry, wywołując metodę UtworzBazePytan()
        public Gra()
        {
            // w konstruktorze ustawiamy początkowe wartości właściwości
            AktualnaWygrana = 0; // => to nie jest potrzebne, ponieważ i tak początkowa wartość int wynosi 0
            AktualnaKategoria = 500;
            UtworzBazePytan();
        }
        
        // włąściwość określająca jaka jest aktualna wygrana gracza
        public int AktualnaWygrana { get; set; }


        // właściwość określająca jaka jest aktualna kategoria pytania na którą odpowiada gracz
        public int AktualnaKategoria { get; set; }


        // lista wszystkich pytań dostępnych w naszym Quizie (baza danych)
        // z niej będziemy losować nasze pytania
        public List<Pytanie> BazaPytan { get; set; }



        // metoda która utworzy nam całą bazę dostepnych Pytań na samym początku gry
        // korzystamy w niej z biblioteki Newtonsoft.Json
        // a dokładniej z zawartej w jednej z jej statycznych klas o nazwie JsonConvert, metody o nazwie DeserializeObject
        // potrafi ona przekształcić format json na strukturę obiektów
        // czyli w naszym przypadku na Listę pytań
        void UtworzBazePytan()
        {
            // ustalamy ścieżkę do pliku pytania.json
            string sciezkaDoPlikuZPytaniami = $"{Directory.GetCurrentDirectory()}\\pytania.json";
            
            // czytamy (program czyta) zawartość pliku pytania.json i zapisuje cały tekst pliku w zmiennej tekstPliku
            string tekstPliku = File.ReadAllText(sciezkaDoPlikuZPytaniami);

            // zamieniamy tekst pliku na listę pytań (List<Pytanie>)
            BazaPytan = JsonConvert.DeserializeObject<List<Pytanie>>(tekstPliku);
        }


        // Narazie nie losujemy pytania, lecz generujemy jedno pytanie (o Einseina)
        // Na zajęciach nr 5 już naprawdę wylosujemy pytanie z naszej przygotowanie Bazy pytań (z listy List<Pytanie>)
        public Pytanie WylosujPytanie()
        {
            Pytanie pytanie = new Pytanie
            {
                Id = 1,
                Kategoria = 500,
                Tresc = "Jak miał na imię Einstein?"
            };

            // za pomocą pętli for wywołanej 4 razy generujemy wszystkie 4 odpowiedzi naszego pytania
            for (int i = 0; i < 4; i++)
            {
                // za każdym "obrotem" naszej pętli tworzymy zupełnie nowy egzemplarz klasy Odpowiedz
                Odpowiedz odpowiedz = new Odpowiedz
                {
                    // mumer odpowiedzi => chcemy żeby był z zakresu 1-4
                    // tak więc możemy wykorzystać licznik pętli i
                    // ponieważ on na starcie jest równy 0 to musimy go "podnieść" o 1
                    // dzieki temu (z każdym "obrotem" pętli uzyskamy inny numer => od 1 do 4)
                    Id = i + 1
                };

                // żeby każda odpowiedz miała inną treść musimy uzależnić ją od licznika pętli
                if (i == 0)
                {
                    odpowiedz.Tresc = "Albert";
                    // przyjeliśmy sobie założenie, że (narazie) zawsze pierwsza odpowiedź jest prawidłowa
                    // a ta jes pierwsza, ponieważ jest to pierwszy "obrót" pętli => licznik równa się 0
                    odpowiedz.CzyPrawidlowa = true;
                }
                else if (i == 1) odpowiedz.Tresc = "Aaron";
                else if (i == 2) odpowiedz.Tresc = "Andrew";
                else odpowiedz.Tresc = "Anthony";

                // przy każdym obrocie pętli musimy dodać utworzoną odpowiedź do listy odpowiedzi pytania
                // wykorzystujemy jedną z metod klasy List o nazwie Add
                // dodaje ona element do listy
                pytanie.Odpowiedzi.Add(odpowiedz);
            }


            // na końcu zwracamy nasze całe utworzone pytanie
            // ponieważ metoda ma zwracać obiekt klasy Pytanie
            return pytanie;

        }


    }
}
