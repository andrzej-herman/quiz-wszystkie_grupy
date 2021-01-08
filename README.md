# Projekt aplikacji Quiz

### Ostatnia aktualizacja: 29.11.2020 - godz. 21:20

Kod źródłowy aplikacji Quiz, którą piszemy na ćwiczeniach, aby nauczyć się programować.  
Wasz kod może wyglądać oczywiście inaczej, jeżeli macie swoje własne pomysły. 
To jest mój pomysł na tę aplikację.

#### Po każdych zajęciach będę aktualizował repozytorium.
#### Każdy z Państwa, może sobie przejrzeć kod.

### Drugie zajęcia:
1. Dodałem dwie metody w głównej metodzie Main w pliku Program.cs
2. Utworzyłem klasę Pytanie i nadałem jej pierwsze właściwości.

### Trzecie zajęcia:
1. Dodano metodę WyswietlPytanie w klasie Program.cs
2. Utworzenie instancji klasy Pytanie o nazwie pytanie1 w pliku Program.cs
3. Ewaluacja odpowiedzi Użytkownika za pomocą instrukcji warunkowej if ... else if ... else w klasie Program.cs 
4. Utworzenie klas Pytanie, Odpowiedz, Gra w katalogu Backend
5. Dodanie doatkowych plików Losowacz.cs oraz pytania.json => tym się nie przejmujcie => to jest na później i tego raczej nie będziemy się uczyć na tym semestrze.
 może sobie wykorzystamy po prostu te pliki lub nie. Zobaczymy.
 
 ### Czwarte zajęcia:
1. Dodanie konstruktorów do klas Gra oraz Pytanie.
2. Utworzenie - na samym początku gry nowego (i w naszym przypadku) jedynego egzempalarza klasy Gra.
3. Nadanie jej (za pomocą konstruktora) wartości początkowych oraz utworzenie bazy pytań gry
4. Utworzenie metody WylosujPytanie w klasie Gra. Będzie ona docelowo losowała pytanie z naszej Bazy Pytań. Póki co generuje pytanie o "Einsteina".
5. Zastosowanie pętli for w metodzie WylosujPytanie => dzięki której, dodajemy 4 odpowiedzi do tworzonego pytania
6. Zastosowanie pętl for oraz foreach w metodzie WyswietlPytanie w pliku Program.cs
7. Utworzenie w klasie gra właściwości o nazwie BazaPytań klasy List<Pytanie>
8. Utworzenie metody UtworzBazePytan => tworzącej nam całą kolekcję pytań do gry z pliku pytania.json 
