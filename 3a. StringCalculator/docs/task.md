# Kata String Calculator

## Zasady
Kierowca (osoba przy klawiaturze) pisze test (który nie przechodzi).
Pilot sprawdza czytelnoœæ, sensownoœæ, korzystanie z dobrych praktyk. 
Osoby zamieniaj¹ siê rolami.
Kierowca pisze implementacje testów nieprzechodz¹cych i nastêpne testy
…. I tak dalej ?


## Wymagania:
1. Utwórz klasê StringCalculator z jedn¹ metod¹ int Add(string numbers)
- Metoda mo¿e przyjmowaæ 0, 1 lub 2 numery i zwraca ich sumê (dla pustego ³añcucha zwróci 0) np.: “” lub “1” lub “1,2”
- Rozpocznij z najprostszym przypadkiem – pusty ³añcuch. Nastêpnie zaimplementuj dla jednego I dwóch numerów
- Pamiêtaj aby u¿ywaæ najprostszych rozwi¹zañ w taki sposób by pisaæ testy o których wczeœniej nie myœla³eœ
- Pamiêtaj o refaktoringu po ka¿dym przechodz¹cym teœcie

2. Metoda Add mo¿e przyjmowaæ nieokreœlon¹ iloœæ numerów np.”1,2,3,4,5,6”

3. Metoda Add mo¿e przyjmowaæ znaki koñca linii pomiêdzy numerami (zamiast przecinków).
- Poni¿szy ³añcuch jest poprawny:  “1\n2,3”  (wynik - 6)
- Poni¿szy ³añcuch nie jest poprawny:  “1,\n” 

4. Wsparcie dla ró¿nego rodzaju znaków podzia³u
- ¯eby zmieniæ znak podzia³u, pocz¹tek linii musi siê zaczynaæ : “//[delimiter]\n[numbers…]” 
np.:  “//;\n1;2” powinno zwróciæ 3 i ustawiæ znak podzia³u na ‘;’ .
- Pierwsza linia jest opcjonalna 

5. Je¿eli numer jest licz¹ ujemn¹ to powinien byæ rzucony wyj¹tek o treœci “Liczny ujemny niedozwolone”. 
Opis powinien zawieraæ liczbê która spowodowa³a b³¹d. Je¿eli by³o wiêcej liczb ujemnych to wszystkie powinny siê znaleŸæ w opisie

6. Liczby wiêksze ni¿  1000 powinny byæ ignorowane np.: 2 + 1001  = 2

7.	Znaki podzia³u mog¹ byæ dowolnej d³ugoœci ale zgodne z formatem :  “//[delimiter]\n” np.: np.: “//[***]\n1***2***3” powinien zwróciæ 6

8.	Dodaj wiele znaków podzia³u zgodnie z formatem :  “//[delim1][delim2]\n” 
np.: “//[*][%]\n1*2%3” powinien zwróciæ 6.

9.	Upewnij siê ¿e mo¿na podaæ wiele znaków podzia³u ka¿dy d³u¿szy ni¿ jeden znak


