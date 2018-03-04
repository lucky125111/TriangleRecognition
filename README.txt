Solucja składa sie z dwóch projektów:
GUI - aplikacja okienkowa w WinForms
ImageProcessing - biblioteki gdzie jest algorytm do wykrywania trójkątów.

Aby odpalić projek należy przywrócić paczki NuGetowe, można to zrobić albo w Visual Studio albo poprzez skrypt build.bat (UWAGA aby skrypt działał należy dodać nuget.exe oraz msbuild.exe do zmiennej PATH użytkownika).

Sposób wykrywania kształtów:
1. Obraz jest progowany względem koloru dla którego szukamy kształtów
2. Nastepnie wyznaczany jest kontur znalezionych kształtów
3. Dla każdego konturu znajdujemy wielokąt aproksymujący ten kontur
4. Jeżeli wielokąt ma 3 wierzchołki to jest trójkątem, trójkąty dodajemy do listy wynikowej
5. Z listy wynikowej bierzemy odpowiednią ilość największych trójkątów

Do projektu dołączone są jeszcze dwa obrazy testowe na których sprawdzałem działania algorytmu
