# Contact list app

- Aplikacja webowa umożliwiająca operacje CRUD na liście kontaktów. 
- Umożliwia logowanie i rejestracje użytkowników.
- Hasła są hashowane, a operacje edycji, usunięcia i dodania nowego kontaktu dostępne są tylko po zalogowaniu.

## Użycie aplikacji
 - Zarejestruj się
 - Możesz przeglądać, dodawać, edytować i usuwać kontakty!
 - Śmiało możesz dodać pierwszy kontakt!

## Technologie

- Backend -> (.Net 8.0) ASP.NET Core web API + SQLServer  
  *Wykorzystano między innymi EntityFramework, FluentValidation, AutoMapper, JWT*

- Frontend -> Angular SPA

## Dokumentacja
 - Dokumentacja API znajduje się pod adresem /swagger/index.html

## Struktura backend (główne komponenty)
- Controllers -> kontrolery API
- DTO -> Obiekty transferu danych
- Migrations -> Migracje bazy danych
- Models -> Modele wykorzystywane w bazie danych
- Services -> Serwisy umożliwiające komunikację kontrolerów z bazą danych

## Jak uruchomić?
### Backend
 - Upewnić się, że zainstalowany jest SQLServer
 - Otworzyć plik .sln
 - W konsoli deweloperskiej VS wpisać polecenie "Update-Database" w celu wykonania migracji. *Wymaga pakietu EFC.Tools*
 - Uruchomić z opcją "https"
 
### Frontend
 - "npm install -g @angular/cli"
 - Wejść w folder projektu, a następnie wpisać komendę "npm install"
 - "ng serve"


### W przypadku problemów
 - Upewnić się, że backend działa na porcie 7011, a frontend na porcie 4200
 - W przypadku problemów z pakietami wpisać "dotnet restore" w konsoli deweloperskiej VisualStudio.
