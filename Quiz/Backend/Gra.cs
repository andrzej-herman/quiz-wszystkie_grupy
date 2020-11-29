using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Backend
{
    // klasa reprezentująca główny obiekt w grze => Gra
    // jeszcze nie skończona => Dodamy do niej jeszcze inne potrzebne Nam właściwości
    public class Gra
    {
        // konstruktor klasy (specjalna metoda)
        // nie wszystkie grupy jeszcze wiedzą o co chodzi
        // omówimy to na ćwiczeniach nr 4
        public Gra()
        {
            // w konstruktorze ustawiamy początkowe wartości właściwości
            AktualnaWygrana = 0; // => to nie jest potrzebne, ponieważ i tak początkowa wartość int wynosi 0
            AktualnaKategoria = 500;
        }
        
        // włąściwość określająca jaka jest aktualna wygrana gracza
        public int AktualnaWygrana { get; set; }


        // właściwość określająca jaka jest aktualna kategoria pytania na którą odpowiada gracz
        public int AktualnaKategoria { get; set; }
    }
}
