# Mobix2

#Backend: 
#CartController
AdminController (CRUD za proizvode)
AuthenticationController 
SearchController (za pretraživanje proizvoda)
PorukeZaAdminaController (namijenjen za SignalR integraciju)
Dodjela JSON web tokena prilikom logiranja
Frontend:
Redizajn izgleda aplikacije (pojedini html dijelovi i css su iskorišteni iz MVC projekta ali sam izmijenila izgled aplikacije uz pravljenje sopstvenih css klasa pa je iz toga razloga korišten i tailwind uz moje css klase)
Index, About, Cart, Catalog, Contact - cjelokupne komponente
Povezivanje CRUD APIja iz backenda sa prethodno navedenim frontend komponentama 
Login, Registracija, Logout 
Dodatne funkcionalnosti koje sam implementirala su:

SignalR integracija koja radi na način omogućavanja korisnicima (logiranim ili ne) da ispune kontakt formu preko koje mogu kontaktirati admina ukoliko imaju neko pitanje ili komentar. Admin na svome admin panelu dobija te poruke u real-time i ikona koverte sa brojem primljenih poruka se povećava u trenutku kada korisnik ispuni i pošalje kontakt formu bez potrebe refreshovanja stranice te je poslanu poruku odmah moguće vidjeti u primljenim porukama  od strane admina
Upload i prikaz slike za dodavanje, getanje i izmjenu proizvoda
Microsoft Identity autentifikacija
Paging liste proizvoda
Slanje konfirmacijskog emaila u kojem se nalazi link za aktiviranje profila nakon registracije. (korišten Outlook kao Email servis)
