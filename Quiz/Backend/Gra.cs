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
            UtworzKategoriePytan();
        }
        
        // włąściwość określająca jaka jest aktualna wygrana gracza
        public int AktualnaWygrana { get; set; }


        // właściwość określająca jaka jest aktualna kategoria pytania na którą odpowiada gracz
        public int AktualnaKategoria { get; set; }


        // lista wszystkich pytań dostępnych w naszym Quizie (baza danych)
        // z niej będziemy losować nasze pytania
        public List<Pytanie> BazaPytan { get; set; }


        // lista wszystkich kategorii pytań
        public List<int> Kategorie { get; set; }

        // właściwość oznaczająca indeks aktualnej kategorii
        public int IndeksKategorii { get; set; }


        // metoda tworząca kategorie pytań
        private void UtworzKategoriePytan()
        {
            Kategorie = new List<int>() { 500, 1000, 2000 };
        }


        // metoda uaktualniająca wartości AktualnaWygrana oraz AktualnaKategoria
        public void UaktualnijDaneGry()
        {
            // po prawidłowej odpowiedzi gracz wygrywa tyle ile wynosi kategoria pytania na które odpowiedział
            AktualnaWygrana = AktualnaKategoria;
            // podnosimy o 1 indeks kategorii
            IndeksKategorii++;
            // Aktualna Kategoria jest następną kategorią z listy kategorii
            AktualnaKategoria = Kategorie[IndeksKategorii];
        }

        // metoda która utworzy nam całą bazę dostepnych Pytań na samym początku gry
        // korzystamy w niej z biblioteki Newtonsoft.Json
        // a dokładniej z zawartej w jednej z jej statycznych klas o nazwie JsonConvert, metody o nazwie DeserializeObject
        // potrafi ona przekształcić format json na strukturę obiektów
        // czyli w naszym przypadku na Listę pytań
        private void UtworzBazePytan()
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
            // wybieramy z całej bazy pytań te, których kategoria jest równa aktualnej kategorii pytania
            List<Pytanie> pytaniaZa500PLN = BazaPytan.Where(x => x.Kategoria == AktualnaKategoria).ToList();

            // losujemy liczbę 
            int wylosowanaLiczba = Losowacz.WygenerujLiczbeLosowa(pytaniaZa500PLN.Count);

            // wybieramy wylosowane pytanie z listy pytań aktualnej kategorii
            Pytanie pytanie = pytaniaZa500PLN[wylosowanaLiczba - 1];

            // losujemy liczby z przedziału 1-4
            List<int> liczby = Losowacz.WygenerujListeLiczbLosowych(4, 4);

            // nadajmy wartości właściwści Kolejność
            List<Odpowiedz> odpowiedziWLosowejKolejnosci = pytanie.Odpowiedzi;
            for (int i = 0; i < 4; i++)
            {
                odpowiedziWLosowejKolejnosci[i].Kolejnosc = liczby[i];
            }


            // ustawiamy odpowiedzi pytania w wylosowanej (losowej kolejności) => wg właściwości Kolejność w porządku osnącym (od 1 do 4)
            pytanie.Odpowiedzi = odpowiedziWLosowejKolejnosci.OrderBy(x => x.Kolejnosc).ToList();



            // na końcu zwracamy nasze całe utworzone pytanie
            // ponieważ metoda ma zwracać obiekt klasy Pytanie
            return pytanie;

        }


    }
}
