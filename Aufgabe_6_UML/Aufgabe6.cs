class Person
{
    string Name;
    int Alter;

}

class Teilnehmer:Person
{
    int Matrikelnummer;
}

class Dozent:Person
{
    int Raumnummer;
    Sprechstunde sp;
    
}

class Sprechstunde
{
    int Raumnummer;
    string Wochentag;
    int Uhrzeit;
}

class Kurs
{
    Dozent dz;
    Teilnehmer tz;
}