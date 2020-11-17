using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Pytanie
    {
        // zapewne jak się domyślacie ten kod będzie ulegał zmianie w trakcie naszej nauki i pisania Quizu
        // Na razie przedstawia się tak:


        // treść pytania
        public string Tresc { get; set; }

        // kategoria pytania wyrażona jako liczba (przedstawia kwotę za jaką jest pytanie)
        // sprawdziłem => w milionerach jest 12 kategorii pytań, od 500 zł do 1 000 000
        public int Kategoria { get; set; }

        // Cztery odpowiedzi
        public string Odpowiedz_1 { get; set; }
        public string Odpowiedz_2 { get; set; }
        public string Odpowiedz_3 { get; set; }
        public string Odpowiedz_4 { get; set; }
    }
}
