# Mobix2

Login podaci za testiranje: <br />

Admin: <br />
email: admin@mobix.com <br />
lozinka: Test123. <br />

Korisnik: <br />
email: korisnik@mobix.com  <br />
lozinka: Test123. <br />

Backend:  <br />
CartController <br />
AdminController (CRUD za proizvode) <br />
AuthenticationController  <br />
SearchController (za pretraživanje proizvoda) <br />
PorukeZaAdminaController (namijenjen za SignalR integraciju) <br />
Dodjela JSON web tokena prilikom logiranja <br />
 <br />
Frontend: <br />
Redizajn izgleda aplikacije (pojedini html dijelovi i css su iskorišteni iz MVC projekta ali sam izmijenila izgled aplikacije uz pravljenje sopstvenih css klasa pa je iz toga razloga korišten i tailwind uz moje css klase) <br />
Index, About, Cart, Catalog, Contact - cjelokupne komponente <br />
Povezivanje CRUD APIja iz backenda sa prethodno navedenim frontend komponentama  <br />
Login, Registracija, Logout  <br />

Dodatne funkcionalnosti:

SignalR integracija koja radi na način omogućavanja korisnicima (logiranim ili ne) da ispune kontakt formu preko koje mogu kontaktirati admina ukoliko imaju neko pitanje ili komentar. Admin na svome admin panelu dobija te poruke u real-time i ikona koverte sa brojem primljenih poruka se povećava u trenutku kada korisnik ispuni i pošalje kontakt formu bez potrebe refreshovanja stranice te je poslanu poruku odmah moguće vidjeti u primljenim porukama  od strane admina <br />
Upload i prikaz slike za dodavanje, getanje i izmjenu proizvoda <br />
Microsoft Identity autentifikacija <br />
Paging liste proizvoda <br />
Slanje konfirmacijskog emaila u kojem se nalazi link za aktiviranje profila nakon registracije. (korišten Outlook kao Email servis) <br />
