using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Backend
{
    // klasa reprezentująca Pytanie w quizie
    public class Pytanie
    {
        // identyfikator pytania (numer pytania => dodatkowa właściwość identyfikująca pytanie)
        public int Id { get; set; }


        // treść pytania
        public string Tresc { get; set; }


        // kategoria pytania wyrażona jako liczba (przedstawia kwotę za jaką jest pytanie)
        // sprawdziłem => w milionerach jest 12 kategorii pytań, od 500 zł do 1 000 000
        public int Kategoria { get; set; }


        // cztery odpowiedzi (wszystkie są klasy Odpowiedz)
        public Odpowiedz Odpowiedz_1 { get; set; }
        public Odpowiedz Odpowiedz_2 { get; set; }
        public Odpowiedz Odpowiedz_3 { get; set; }
        public Odpowiedz Odpowiedz_4 { get; set; }

    }
}
