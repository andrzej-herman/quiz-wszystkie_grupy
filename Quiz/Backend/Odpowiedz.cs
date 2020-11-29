using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Backend
{

    // klasa reprezentująca jedną z czterch możliwych odpowiedzi pytania
    public class Odpowiedz
    {
        // identyfikator odpowiedzi (numer 1-4)
        public int Id { get; set; }

        // Treść odpowiedzi
        public string Tresc { get; set; }
        
        // zmienna typu bool, oznaczająca czy ta odpowiedź jest prawidłowa
        public bool CzyPrawidlowa { get; set; }

        // kolejność => będziemy losować za każdym razem kolejność wyświetlania odpowiedzi, aby Użytkownik nie zorientował się, 
        // że za każdym razem odpowiedź pierwsza jest prawidłowa => Na razie jej nie wykorzystujemy
        public int Kolejnosc { get; set; }
    }
}
