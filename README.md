# Užsiėmimų registracijos sistema

## Turinys

 1. [Sprendžiamo uždavinio aprašymas](#sprendžiamo-uždavinio-aprašymas) 
 2. [Sistemos paskirtis](#sistemos-paskirtis) 
 3.  [Funkciniai reikalavimai](#funkciniai-reikalavimai) 
 4.  [Pasirinktų technologijų aprašymas](#pasirinktų-technologijų-aprašymas) 
 5.  [Sistemos architektūra](#sistemos-architektūra)


## Sprendžiamo uždavinio aprašymas

### *Sistemos paskirtis*

**Projekto tikslas** - palengvinti ir paspartinti informacijos kaupimą, redagavimą ir stebėjimą užsiėmimo organizatoriams, grupių vadovams ir nariams. 

**Veikimo principas** - kuriamą platformą sudaro dvi dalys: internetinė aplikacija, kurią naudosis užsiėmimų organizatoriai, vadovai, nariai, administratorius bei aplikacijų programavimo sąsaja.

**Aprašymas**  - Nariai norėdami naudototis šią sistema turės prisiregistruoti. Registracijos metų suvedus privalomus duomenis bus galima pasirinkti registracijos rolę: Narys ar Organizatorius. Jeigu registruojamas narys nėra suaugęs, tai reikia papildomai  įvesti ir globėjo informaciją.

Jeigu registruojamasi pasirinkus "organizatorius", tada bus leidžiama sukurti užsiėmimą. Kai organizatorius užildo visus reikalingus duomenis susijusius su užsiėmimu išsiunčiamas pranešimas dėl užsiėmimo patvirtinimo administratoriui. Administratorius gavęs pranešimą apie naują užsiėmimą, jį patvirtiną arba atmeta. Jei pranešimas buvo patvirtintas Organizatoriui suteikiama priega prie sistemos. Sistemoje organizatorius gali pridėti detalesne informaciją apie užsiėmimą, tokia kaip, užsiėmimo vieta/as, sukurti skirtingas užsiėmimų grupes ir priskirti jas pasirinktom vietom. Organizatorius gali pakeisti užsiėmimo narių roles į organizatorių ar vadovą, priskirti vadovus atsakingus už pasirinktas užsiėmimų grupes. Matyti visų užsiėmimų sąrašą, kuriuose jis yra organizatorius, matyti pasirinkto užsiėmimo vietų, grupių sąrašą ir tvarkaraščius pasirinktose užsiėmimų vietose ar grupėse.

Narys norintis tapti kokio nors užsiėmimo vadovu ar jau egzistuojančio užsiėmimo organizatoriumi, tai turi būti narys tame užsiėmime ir gauti užklausą iš užsiėmimų organizatoriaus, tada reikia priimti siųsta užklausą dėl rolės pakeitimo užsiėmime, nariui priėmus užklausą pridedama nauja rolė, skirta tam užsiėmimui. Narys norintis tapti naujo užsiėmimo organizatoriumi turi meniu parinktyse paspausti "Tapti organizatoriumi", užpildyti papildomus duomenis apie save ir užsiėmimą, tada išsiųsti užklausa administratoriui, jei patvirtina administratorius, tada sukuriamas užsiėmimas ir tampama to užsiėmimo organizatoriumi. 

Vadovai ir organizatorius gali patvirtindami nario siųstą užklausą, pridėti naujus narius, taip pat galima pridėti informaciją apie narį, jei šis ir nesinaudoja sistema, matyti visų narių sąraša, pašalinti narius, priskirti narius į pasirinktas užsiėmimų grupes, nustatyti abonimento laikotarpį ir mokęsčio dydį pasirinktai grupei. Grupių sąraše pasirinkus ant grupės matyti narių sąrašą, grupėje gali žymėti narių lankomumą bei užmokestį, gali išsiųsti informacinį pranešimą ir matyti pranešimų sąrašą. Vadovai gali matyti savaites tvarkaraštį su jiems priskirtomis užsiėmimų grupėmis. Jeigu vadovauja skirtinguose užsiėmimuose, tai gali matyti bendrą tvarkarašti tarp visų turimų užsiėmimų.

Prisiregistravęs Narys, gali matyti bendrą užsiėmimų sąrašą pasirinktame mieste, sąraše paspaudus ant užsiėmimo matyti jo informaciją. Susisiekti su užsiėmimų vadovu ar organizatoriumi. Išsiųsti prašymą užsiėmimo organizatoriui ar vadovui, dėl pridėjimo. Organizatoriui ar vadovui patvirtinus užklausą narys pridedamas prie užsiėmimo. Taip pat galima išsiųsti prašymą dėl išėjimo iš užsiėmimo. Visi nario lankomu ir seniau lankytų užsiėmimų informacija galima peržiūrėti užsiėmimų sąraše, o paspaudus ant užsiėmimo saraše - detalesnę informaciją, pvz.: ar užmokėta, lankomumą, pastabas. Narys gali matyti savo bendrą visų lankomų užsiėmimų tvarkaraštį,  taip pat paspaudęs ant meniu parinkties "pranešimai", gali matyti gautus pranešimus, užklausas Gali išsiųsti informacinį pranešimą grupės vadovui, dėl neatvykimo ar kitų priežasčių.

Nariai, kurie turi skirtingas roles skirtinguose užsiėmimose, gali jas keisti ir matyti tom rolėm skirta informacija užsiėmime. Pirmiausia prieš keičiant rolę, reikia pasirinkti užsiėmimą, kurio informacija narys nori matyti, parsirinkus užsiėmimą galima keisti rolę ir matyti tos rolės meniu parinktis ir prieinamą informaciją. Administratorius paskyra roles keisti negali.

Visos sistemos vartojimos roles gali peržiūrėti ir redaguoti savo profilio informaciją.

Sistemos administratrius mato visų užsiėmimų sąrašą, gali pridėti ir pašalinti ir redaguoti užsiėmimus, taip pat patvirtinti organizatorių sukurtus užsiėmimus, gali peržiūrėti, redaguoti, pašalinti sistemos vartotojus.  Pasirinkus "Pranešimai" skiltį gali matyti pranešimų istorija ir siųsti pranešimus pasirinktiems užsiėmimamų organizatoriams ar visiems sistemos naudotojams.


### *Funkciniai reikalavimai*

**Neregistruotas vartotojas galės:**

 -  Peržiūrėti užsiėmimų sąrašą pasirinktame mieste
 -  Registruotis prie sistemos

**Registruotas sistemos vartotojas ("Narys") galės:**

 - Prisijungti prie sistemos 
 - Atsijungti nuo sistemos 
 - Matyti užsiėmimų sąrašą pasirinktame mieste
 - Ieskoti užsiėmimo pagal pavadinimą/ar tipą
 -  Paspaudus ant užsiėmimo matyti informaciją
 - Matyti pranešimų istorija
 -  Išsiųsti užklausą užsiėmimo grupės vadovui/organizatoriui/administratoriui, pvz dėl priėmimo/ išejimo iš užsiėmimo
 -  Išsiųsti informacinį pranešimą grupės vadovui dėl neatvykimo ar kitų priežasčių
 -  Matyti savo užsiėmimų tvarkaraštį
 - Matyti užsiėmimų sąrašą
 -  Paspaudus ant užsiėmimo matyti užsiėmimo ir asmeninę informaciją(lankomumą/mokėjimus/pastabas)
 - Matyti savo profilio informaciją
 -  Redaguoti profilio informaciją

**Vadovas galės:**
 - Pasikeisti tarp turimų rolių 
- Jei vadovas priskirtas prie kelių skirtingų užsiėmimų, tai gali pasirinkti, kurio užsiėmimo informacija matyti
 - Matyti priskirtų užsiėmimo grupių sąrašą
 - Matyti grupes informacija
 - Matyti visų užsiėmimo narių sąrašą
 - Pridėti narius į užsiėmimą
 - Pašalinti narius iš užsiėmimo
 -  Pridėti narius į vadovaujamą grupę
 - Pašalinti narius iš grupės
- Matyti vadovaujamų užsiėmimų tvarkaraštį
- Siųsti pranešimą sistemos naudotojams 
- Matyti pranešimų istoriją
- Peržiūrėti paskyros informarciją
- Redaguoti paskyros informaciją

**Organizatorius galės:**
- Sukurti užsiėmimą/us
- Peržiūrėti užsiėmimo informaciją
- Redaguoti užsiėmimo/ų informaciją
- Sukurti užsiėmimo vieta/as
- Peržiūrėti užsiėmimo vietos/ų informaciją
- Redaguoti užsiėmimų vietų informaciją
- Ištrinti užsiėmimų vietas jei joms nėra priskirta grupių
- Sukurti užsiėmimo grupę/es
- Peržiūrėti užsiėmimo grupių informaciją
- Ištrinti užsiėmimo grupę/es
- Redaguoti užsiėmimo grupės/ių informaciją
- Pridėti narius į užsiėmimą
- Šalinti narius iš užsiėmimo
- Pakeisti nario rolę į vadovą arba organizatorių
- Priskirti narį į užsiėmimo grupę
- Priskirti vadovus į užsiėmimo grupes
- Jei sukūręs daugiau nei vieną užsiemimą, tai gali pasirinkti kurio užsiėmimo informacija nori matyti
- Pasikeisti savo role ir matyti tai rolei priklausančią informaciją
- Matyti pasirinkto užsiėmimo grupių sąrašą
- Matyti užsiėmimo vietų sąrašą
- Matyti visų narių sąrašą
- Matyti užsiėmimų tvarkaraštį pagal vietą ar grupę
- Siųsti pranešimą sistemos naudotojams 
- Matyti pranešimų istoriją
- Peržiūrėti paskyros informarciją
- Redaguoti paskyros informaciją

**Administratorius galės:**

- Mato visų užsiėmimų sąrašą
- Patvirtina organizatorių sukurtus užsiėmimus
- Pašalinti užsiėmimą
- Matyti pranešimų istorija
- Siųsti pranešimus
- Matyti sistemos vartotojų sąrašą
- Priregistruoti naują sistemos administratorių
- Pašalinti sistemos vartotojus


## Pasirinktų technologijų aprašymas

### Sistemos sudedamosios dalys:
Kliento pusė (ang. Front-End) – naudojant React.

Serverio pusė (angl. Back-End) – naudojant C# .NET. 

Duomenų bazė – PostgreSQL.

## Sistemos architektūra

1 pav. pavaizduota kuriamos sistemos diegimo diagrama. Sistemos talpinimui yra naudojamas Azure serveris. Kiekviena sistemos dalis yra diegiama tame pačiame serveryje. Internetinė aplikacija yra pasiekiama per HTTP protokolą. Šios sistemos veikimui (pvz., duomenų manipuliavimui su duomenų baze) yra reikalingas OnActs API. kuris vykdo duomenų mainus su duomenų baze - tam naudojama ORM sąsaja.

![1 pav.](img.png?raw=true "1 pav.")


