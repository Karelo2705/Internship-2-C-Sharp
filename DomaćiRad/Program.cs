using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomaćiRad
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var populationCensus = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>()
            {

                {"39834800878",("Ivo Ivić",new DateTime (1997,5,23))},
                {"78644869950",("Ante Matić",new DateTime (1974,5,7))},
                {"77916778827",("Roza Ćupić",new DateTime (2000,4,19))},
                {"09966892222",("Marko Dadić",new DateTime (2002,10,31))},
                {"61120184420",("Ante Aužina",new DateTime (2003,2,8))},





            };
            var newLoop = 0;

            while (newLoop == 0)
            {

                Console.WriteLine("Odaberite akciju:");
                Console.WriteLine("1 - Ispis stanovnistva");
                Console.WriteLine("2 - Ispis stanovnika po OIB-u");
                Console.WriteLine("3 - Ispis OIB-a po unosu imena i prezimena");
                Console.WriteLine("4 - Unos novog stanovnika");
                Console.WriteLine("5 - Brisanje stanovnika po OIB-u");
                Console.WriteLine("6 - Brisanje stanovnika po imenu i prezimenu te datumu rodenja");
                Console.WriteLine("7 - Brisanje svih stanovnika");
                Console.WriteLine("8 - Uredivanje stanovnika");
                Console.WriteLine("9 - Statistika");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                var action = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("1 - Onako kako su spremljeni");
                        Console.WriteLine("2 - Po datumu rođenja ulazno");
                        Console.WriteLine("3 - Po datumu rođenja silazno");
                        Console.WriteLine("Za povratak unesi bilo što osim navedenih brojeva");

                        var newAction = int.Parse(Console.ReadLine());
                        
                        Console.Clear();

                        if (newAction == 1)
                        {
                            foreach (var item in populationCensus)
                            {
                                Console.WriteLine(item);
                            }

                        }
                        else if (newAction == 2)
                        {
                            foreach (var nameSurname in populationCensus.OrderBy(key => key.Value.dateOfBirth))
                            {
                                Console.WriteLine($"{nameSurname.Key} {nameSurname.Value}");
                            }

                        }
                        else if (newAction == 3)
                        {
                            foreach (var nameSurname in populationCensus.OrderBy(key => key.Value.dateOfBirth).Reverse())
                            {
                                Console.WriteLine($"{nameSurname.Key} {nameSurname.Value}");
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Pritisni enter za daljnju radnju:");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                       
                    case 2:
                         var newBool = true;

                        while (newBool)
                        {
                            Console.WriteLine("Unesi željeni OIB: ");
                            var OIBNum = Console.ReadLine();
                            var OIBNumBuilder = new StringBuilder();
                            OIBNumBuilder.Append(OIBNum);


                            if (OIBNumBuilder.Length > 11 || OIBNumBuilder.Length < 11 )
                            {
                                Console.WriteLine("Neispravan unos");
                            }
                            else
                            {
                                Console.WriteLine(populationCensus[OIBNumBuilder.ToString()]);
                                newBool = false;
                            }

                        }
                        Console.WriteLine("Pritisni enter za daljnju radnju:");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        newBool = true;

                        while (newBool)
                        {
                            Console.WriteLine("Unesi Ime i Prezime: ");
                            var nameSurname = Console.ReadLine();
                            Console.WriteLine("Unesi Datum rođenja: ");
                            var newDateTimeC3 = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                            var nameNumBuilder = new StringBuilder();
                            nameNumBuilder.Append(nameSurname);

                            foreach (var item in populationCensus)
                            {
                                if (nameNumBuilder.Length < 1 )
                                {
                                    Console.WriteLine("Neispravan unos");
                                    break;
                                }
                                else
                                {
                                    if (item.Value == (nameSurname,newDateTimeC3))
                                    {
                                        Console.WriteLine(item);
                                        newBool = false;
                                    }
                                }


                            }

                        }
                        Console.WriteLine("Pritisni enter za daljnju radnju:");
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case 4:
                        
                            newBool = true;
                        
                            Console.WriteLine("unesi novi OIB: ");

                            var newOIB = Console.ReadLine();
                            var newOIBBuilder2 = new StringBuilder();
                            newOIBBuilder2.Append(newOIB);
                            
                        while (newBool)
                        {
                            foreach (var item in populationCensus)
                            {
                                if (newOIB == item.Key || newOIBBuilder2.Length != 11)
                                {
                                    Console.WriteLine("neispravan unos, pokušaj ponovno: ");
   
                                    break;
                                }
                                else if(newOIBBuilder2.Length == 11) newBool = false;
                            }  
                            if(newBool)
                            newOIB = Console.ReadLine();
                            newOIBBuilder2.Clear();
                            newOIBBuilder2.Append(newOIB);
                        }
                            Console.WriteLine("unesi novo Ime i Prezime: ");
                            var newNameAndSurname = Console.ReadLine();
                            Console.WriteLine("unesi novi datum(YY/MM/DD)");
                            var newDateTime = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                            populationCensus.Add(newOIB, (newNameAndSurname, newDateTime));
                        Console.Clear();
                         break;

                    case 5:
                        newBool = true;

                        while (newBool)
                        {
                            Console.WriteLine("Unesi OIB osobe koju želiš izbrisati: ");
                            var OIBNum = Console.ReadLine();
                            var OIBNumBuilder = new StringBuilder();
                            OIBNumBuilder.Append(OIBNum);


                            if (OIBNumBuilder.Length !=11)
                            {
                                Console.WriteLine("Neispravan unos");
                            }
                            else
                            {
                                populationCensus.Remove(OIBNum);
                                newBool = false;
                            }

                        }
                        Console.WriteLine("Pritisni enter za daljnju radnju:");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 6:
                        newBool = true;

                        while (newBool)
                        {
                            Console.WriteLine("Unesi Ime i Prezime za brisanje: ");
                            var nameSurname = Console.ReadLine();
                            Console.WriteLine("Unesi Datum rođenja za brisanje: ");
                            var newDateTimeC3 = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                            var nameNumBuilder = new StringBuilder();
                            nameNumBuilder.Append(nameSurname);

                            foreach (var item in populationCensus)
                            {
                                if (nameNumBuilder.Length < 1 || !populationCensus.ContainsValue((nameSurname, newDateTimeC3)))
                                {
                                    Console.WriteLine("Neispravan unos");
                                    break;
                                }
                                else
                                {
                                    if (item.Value == (nameSurname, newDateTimeC3))
                                    {
                                       populationCensus.Remove(item.Key);
                                        newBool = false;
                                    }
                                }


                            }

                        }
                        Console.WriteLine("Pritisni enter za daljnju radnju:");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 7:

                        foreach(var item in populationCensus)
                        {
                            populationCensus.Remove(item.Key);
                        }
                        Console.WriteLine("Pritisni enter za daljnju radnju:");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 8:
                        
                        Console.WriteLine("1 - Uredi OIB stanovnika");
                        Console.WriteLine("2 - Uredi ime i prezime stanovnika");
                        Console.WriteLine("3 - Uredi datum rođenja");
                        var newSwitch = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (newSwitch)
                        {
                            case 1:
                                newBool = true;

                                while (newBool)
                                {
                                    Console.WriteLine("Unesi željeni OIB: ");
                                    var OIBNum = Console.ReadLine();
                                    var OIBNumBuilder = new StringBuilder();
                                    OIBNumBuilder.Append(OIBNum);
                                    var replacementOIB = "";
                                    Console.Clear();

                                    if (OIBNumBuilder.Length !=11)
                                    {
                                        Console.WriteLine("Neispravan unos");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Unesi zamjenski OIB: ");
                                        replacementOIB = Console.ReadLine();
                                        var saveValue = populationCensus[OIBNum];
                                        populationCensus.Remove(OIBNum);
                                        populationCensus.Add(replacementOIB,saveValue);
                                        newBool = false;
                                    }

                                }
                                Console.WriteLine("Pritisni enter za daljnju radnju:");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 2:
                                newBool = true;

                                while (newBool)
                                {
                                    Console.WriteLine("Unesi željeni OIB: ");
                                    var OIBNum = Console.ReadLine();
                                    var OIBNumBuilder = new StringBuilder();
                                    OIBNumBuilder.Append(OIBNum);
                                    var replacementName = "";
                                    Console.Clear();

                                    if(OIBNumBuilder.Length != 11)
                                    {
                                        Console.WriteLine("Neispravan unos");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Unesi zamjensko Ime: ");
                                        replacementName = Console.ReadLine();
                                        var saveValue = populationCensus[OIBNum];
                                        populationCensus[OIBNum] = (replacementName, saveValue.dateOfBirth);
                                        newBool = false;
                                    }


                                }
                                Console.WriteLine("Pritisni enter za daljnju radnju:");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 3:
                                newBool = true;

                                while (newBool)
                                {
                                    Console.WriteLine("Unesi željeni OIB: ");
                                    var OIBNum = Console.ReadLine();
                                    var OIBNumBuilder = new StringBuilder();
                                    OIBNumBuilder.Append(OIBNum);
                                    Console.Clear();

                                    if (OIBNumBuilder.Length != 11)
                                    {
                                        Console.WriteLine("Neispravan unos");
                                    }
                                    else
                                    {
                                        var saveValue = populationCensus[OIBNum];
                                        Console.WriteLine("Unesi zamjenski datum (YY/MM/DD): ");
                                        var replacementDate = new DateTime(int.Parse(Console.ReadLine()),int.Parse(Console.ReadLine()),int.Parse (Console.ReadLine()));
                                        populationCensus[OIBNum] = (saveValue.nameAndSurname, replacementDate);
                                        newBool = false;
                                    }


                                }
                                Console.WriteLine("Pritisni enter za daljnju radnju:");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;

                    case 9:
                        Console.WriteLine("1 - Postotak nezaposlenih (od 0 do 23 godine i od 65 do 100 godine) i postotak zaposlenih (od 23 do 65 godine)");
                        Console.WriteLine("2 - Ispis najčešćeg imena i koliko ga stanovnika ima");
                        Console.WriteLine("3 - Ispis najčešćeg prezimena i koliko ga stanovnika ima");
                        Console.WriteLine("4 - Ispis datum na koji je rođen najveći broj ljudi i koji je to datum");
                        Console.WriteLine("5 - Ispis broja ljudi rođenih u svakom od godišnjih doba (poredat godišnja doba s obzirom na broj ljudi rođenih u istim)");
                        Console.WriteLine("6 - Ispis najmlađeg stanovnika");
                        Console.WriteLine("7 - Ispis najstarijeg stanovnika");
                        Console.WriteLine("8 - Prosječan broj godina (na 2 decimale)");
                        var newSwitchV2 =int.Parse(Console.ReadLine());

                        switch (newSwitchV2)
                        {
                            case 1:
                                var dvaTri = new DateTime(1998, 1, 1);
                                var nula = DateTime.Now;
                                var šestPet = new DateTime(1956, 1, 1);
                                var sto = new DateTime(1921, 1, 1);
                                var j = 0;
                                var i = 0;
                                var z = 0;
                                float postotakZaposlenih = 0;
                                float postotakNezaposlenih = 0;
                                foreach(var item in populationCensus)
                                {
                                    j++;
                                    if ((item.Value.dateOfBirth > dvaTri && item.Value.dateOfBirth <nula) || (item.Value.dateOfBirth <šestPet && item.Value.dateOfBirth >sto) )
                                    {
                                        i++;

                                    }
                                    else if(item.Value.dateOfBirth > šestPet && item.Value.dateOfBirth < dvaTri)
                                    {
                                        z++;
                                    }
                                }
                                postotakNezaposlenih = (float)i / j * 100;
                                postotakZaposlenih = (float)z / j * 100;
                                Console.WriteLine($"Postotak zaposlenih je {postotakZaposlenih}%, a postotak nezaposlenih je {postotakNezaposlenih}%");
                                Console.WriteLine("Pritisni enter za daljnju radnju:");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 2:
                                var newPopulationCensus = populationCensus;
                                i=0;
                                foreach(var item in populationCensus)
                                {
                                    var saveValue = populationCensus[item.Key];
                                  foreach(var item2 in newPopulationCensus)
                                    {
                                        var saveValue2 = newPopulationCensus[item2.Key];
                                        if(saveValue.nameAndSurname == saveValue2.nameAndSurname)
                                        {
                                            i++;
                                        }
                                    }

                                }
                                break;

                            case 5:


                            case 6:
                                var printed = "";
                                foreach (var nameSurname in populationCensus.OrderBy(key => key.Value.dateOfBirth))
                                {
                    
                                   printed = $"{nameSurname.Key} {nameSurname.Value}";
                                }
                                Console.WriteLine(printed);
                                Console.WriteLine("Pritisni enter za daljnju radnju:");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 7:
                                var printed2 = "";
                                foreach (var nameSurname in populationCensus.OrderBy(key => key.Value.dateOfBirth).Reverse())
                                {

                                    printed2 = $"{nameSurname.Key} {nameSurname.Value}";
                                }
                                Console.WriteLine(printed2);
                                Console.WriteLine("Pritisni enter za daljnju radnju:");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;

                    case 0:
                        newLoop = 1;
                        break;
                    default: Console.WriteLine("neispravan unos");
                        break;
                }
                }
            }
        public enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn

        }
        }
    }


