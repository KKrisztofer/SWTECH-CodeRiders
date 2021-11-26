CREATE TABLE Jogosultsagok
(
  id INT NOT NULL,
  elnevezes VARCHAR(30) NOT NULL,
  rendelesKezeles BOOLEAN NOT NULL,
  alapanyagKezeles BOOLEAN NOT NULL,
  termekKezeles BOOLEAN NOT NULL,
  menuKezeles BOOLEAN NOT NULL,
  raktarKezeles BOOLEAN NOT NULL,
  vendegKezeles BOOLEAN NOT NULL,
  felhasznaloKezeles BOOLEAN NOT NULL,
  jogosultsagKezeles BOOLEAN NOT NULL,
  rendelesSzallitas BOOLEAN NOT NULL,
  naploMegtekintes BOOLEAN NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE Kategoriak
(
  id INT NOT NULL,
  elnevezes VARCHAR(20) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE Alapanyagok
(
  id INT NOT NULL,
  elnevezes VARCHAR(20) NOT NULL,
  mertekegyseg VARCHAR(2) NOT NULL,
  rogzitesDatum DATE NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE Termekek
(
  id INT NOT NULL,
  elnevezes VARCHAR(30) NOT NULL,
  tipus BOOLEAN NOT NULL,
  ar INT NOT NULL,
  rogzitesDatum DATE NOT NULL,
  kategoria INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (kategoria) REFERENCES Kategoriak(id)
);

CREATE TABLE AlapanyagTartalmazas
(
  mennyiseg INT NOT NULL,
  alapanyagID INT NOT NULL,
  termekID INT NOT NULL,
  FOREIGN KEY (alapanyagID) REFERENCES Alapanyagok(id),
  FOREIGN KEY (termekID) REFERENCES Termekek(id)
);

CREATE TABLE Menuk
(
  id INT NOT NULL,
  elnevezes VARCHAR(30) NOT NULL,
  ar INT NOT NULL,
  rogzitesDatum DATE NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE TermekTartalmazas
(
  mennyiseg INT NOT NULL,
  termekID INT NOT NULL,
  menuID INT NOT NULL,
  FOREIGN KEY (termekID) REFERENCES Termekek(id),
  FOREIGN KEY (menuID) REFERENCES Menuk(id)
);

CREATE TABLE AlapanyagRaktar
(
  mennyiseg INT NOT NULL,
  utolsoBovites DATE NOT NULL,
  minimum INT,
  alapanyagID INT NOT NULL,
  FOREIGN KEY (alapanyagID) REFERENCES Alapanyagok(id)
);

CREATE TABLE TermekRaktar
(
  mennyiseg INT NOT NULL,
  utolsoBovites DATE NOT NULL,
  minimum INT,
  termekID INT NOT NULL,
  FOREIGN KEY (termekID) REFERENCES Termekek(id)
);

CREATE TABLE Varosok
(
  irSzam VARCHAR(4) NOT NULL,
  varos VARCHAR(40) NOT NULL,
  PRIMARY KEY (irSzam)
);

CREATE TABLE Felhasznalok
(
  id INT NOT NULL,
  nev VARCHAR(30) NOT NULL,
  email VARCHAR(30) NOT NULL,
  jelszo VARCHAR(300) NOT NULL,
  rogzitesDatum DATE NOT NULL,
  jogosultsag INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (jogosultsag) REFERENCES Jogosultsagok(id)
);

CREATE TABLE Vendegek
(
  id INT NOT NULL,
  nev VARCHAR(30) NOT NULL,
  telefon VARCHAR(11) NOT NULL,
  cim VARCHAR(40) NOT NULL,
  rogzitesDatum DATE NOT NULL,
  email VARCHAR(30) NOT NULL,
  irSzam VARCHAR(4) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (irSzam) REFERENCES Varosok(irSzam)
);

CREATE TABLE Rendelesek
(
  id INT NOT NULL,
  datum DATE NOT NULL,
  osszeg INT NOT NULL,
  tipus BOOLEAN NOT NULL,
  aktiv BOOLEAN NOT NULL,
  vendeg INT,
  kiszolgalo INT,
  PRIMARY KEY (id),
  FOREIGN KEY (vendeg) REFERENCES Vendegek(id),
  FOREIGN KEY (kiszolgalo) REFERENCES Felhasznalok(id)
);

CREATE TABLE RendeltTermekek
(
  mennyiseg INT NOT NULL,
  rendelesID INT NOT NULL,
  termekID INT NOT NULL,
  FOREIGN KEY (rendelesID) REFERENCES Rendelesek(id),
  FOREIGN KEY (termekID) REFERENCES Termekek(id)
);

CREATE TABLE RendeltMenuk
(
  mennyiseg INT NOT NULL,
  rendelesID INT NOT NULL,
  menuID INT NOT NULL,
  FOREIGN KEY (rendelesID) REFERENCES Rendelesek(id),
  FOREIGN KEY (menuID) REFERENCES Menuk(id)
);

CREATE TABLE Szallitas
(
  kezbesitveDatum DATE NOT NULL,
  rendelesID INT NOT NULL,
  futarID INT NOT NULL,
  FOREIGN KEY (rendelesID) REFERENCES Rendelesek(id),
  FOREIGN KEY (futarID) REFERENCES Felhasznalok(id)
);

CREATE TABLE TermekKeszites
(
  termekID INT NOT NULL,
  rendelesID INT NOT NULL,
  szakacs INT NOT NULL,
  FOREIGN KEY (termekID) REFERENCES Termekek(id),
  FOREIGN KEY (rendelesID) REFERENCES Rendelesek(id),
  FOREIGN KEY (szakacs) REFERENCES Felhasznalok(id)
);