using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Laiterekisteri
{
    // Yleinen laiteluokka, yliluokka tietokoneille, tableteille ja puhelimille
    [Serializable]
    class Device
    {
        // Luodaan kenttä (field) name, esitellään (define) ja annetaan arvo (set initial value)
        string name = "Uusi laite";

        // Luodaan kenttää vastaava ominaisuus (property) Name ja sille asetusmetodi set ja lukumetodi get. 
        // Ne voi kirjoittaa joko yhdelle tai useammalle riville.
        public string Name { get { return name; } set { name = value; } }

        string purchaseDate = "1.1.1900";
        public string PurchaseDate { get { return purchaseDate; } set { purchaseDate = value; } }

        // Huomaa doublen jälkiliite d (suffix)
        double price = 0.0d;
        public double Price { get { return price; } set { price = value; } }

        int warranty = 12;
        public int Warranty { get { return warranty; } set { warranty = value; } }

        string processorType = "N/A";
        public string ProcessorType { get {  return processorType; } set {  processorType = value; } }

        int amountRAM = 0;
        public int AmountRam { get { return amountRAM; } set {  amountRAM = value; } }

        int storageCapacity = 0;
        public int StorageCapacity { get {  return storageCapacity; } set {  storageCapacity = value; } }

        // Konstruktori eli olionmuodostin (constructor) ilman argumentteja
        public Device() {}

        // Konstruktori nimi-argumentilla
        public Device(string name) 
        { this.name = name; }

        public Device(string Name, string purchaseDate, double price, int warranty)
        {
            this.Name = Name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
        }

        // Konstruktori kaikilla argumenteilla
        public Device(string Name, string purchaseDate, double price, int warranty, string processorType, int amountRam, int storageCapacity)
        {
            this.Name = Name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
            this.processorType = processorType;
            this.amountRAM = amountRam;
            this.storageCapacity = storageCapacity;
        }

        // MUUT METODIT

        // Yliluokan metodit

        public void ShowPurchaseInfo()
        {
            // Luetaan laitteen ostotiedot sen kentistä, huom! this
            Console.WriteLine();
            Console.WriteLine("Laitteen hankintatiedot");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Laitteen nimi: " + this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hankinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Laitteen tekniset tiedot");
            Console.WriteLine("------------------------");
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Presessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRam);
            Console.WriteLine("Levytila: " + StorageCapacity);
        }

        public void CalculateWarrantyEndingDate()
        {
            // Muutetaan päivämäärä merkkijono päivämäärä-kellonaika-muotoon
            DateTime startDate = DateTime.ParseExact(this.PurchaseDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture);

            // Lisätään takuun kesto
            DateTime endDate = startDate.AddMonths(this.Warranty);

            // Muunnetaan päivämäärä ISO-standardin mukaiseen muotoon
            endDate = endDate.Date;

            string isoDate = endDate.ToString("yyyy-MM-dd");

            Console.WriteLine("Takuu päättyy: " + isoDate);
        }

    }

    // Tietokondeiden luokka, perii ominaisuuksia ja metodeja laiteluokasta Device
    [Serializable]
    class Computer : Device
    {
        // Konstruktorit
        public Computer() : base()
            { }

        public Computer(string name) : base(name)
            { }

        // muut metodit seuraavaksi
    }

    // Tablettien luokka, perii laiteluokan
    [Serializable]
    class Tablet : Device 
    {
        // Kentät ja ominaisuudet
        string operatingSystem;
        public string OperatingSystem { get { return operatingSystem; } set { operatingSystem = value; } }
        
        bool stylusEnabled = false;
        public bool StylusEnabled { get { return stylusEnabled; } set { stylusEnabled = value; } }
        
        // Konstruktorit

        public Tablet() : base() { }

        public Tablet(string name) : base(name) { }

        // Tablet-luokan erikoismetodit
        public void TabletInfo() 
        {
            Console.WriteLine();
            Console.WriteLine("Tabletin erityistiedot");
            Console.WriteLine("----------------------");
            Console.WriteLine("Käyttöjärjestelmä: " +  OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }
    }


    // Pääohjelman luokka, josta tulee Program.exe
    internal class Program
    {
        // Ohjelman käynnistävä metodi
        static void Main(string[] args)
        {

            // Määritellään binääridatan muodostaja serialisointia varten
            IFormatter formatter = new BinaryFormatter();

            // Määritellään file stream tiedokoneiden tietojen tallenusta varten
            Stream writeStream = new FileStream("ComputerData.dat",
                FileMode.Create, FileAccess.Write);

            // Luodaan vektorit ja laskurit niiden alkioille
            Computer[] computers = new Computer[10];
            Tablet[] tablets = new Tablet[10];
            int numberOfComputers = 0;
            int numberOfTables = 0;

            // Vaihtoehtoisesti luodaan pinot laitteille
            Stack<Computer> computerStack = new Stack<Computer>();

            // Ikuinen silmukka pääohjelman käynnissä pitämiseen
            while (true) 
            {
                Console.WriteLine("Minkä laitteen tietot tallenetaan?");
                Console.Write("1 tietokone, 2 tabletti ");
                string type = Console.ReadLine();

                // Luodaan Switch-Case-rakenne vaihtoehdoille

                switch (type) 
                {
                    case "1":

                        // Kysytään käyttäjiltä tietokoneen tiedot ja luodaan uusi tietokoneolio
                        Console.Write("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer(computerName);
                        Console.Write("Ostopäivä muodossa vvvv-kk-pp: ");
                        computer.PurchaseDate = Console.ReadLine();
                        Console.Write("Hankintahinta: ");
                        string price = Console.ReadLine();
                        try
                        {
                            computer.Price = double.Parse(price);
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine("Virheellinen hintatieto, käytä desimaalipilkkua (,) " + ex.Message);
                            break;
                        }

                        Console.Write("Takuun kesto kuukausina: ");
                        string warranty = Console.ReadLine();
                        try
                        {
                            computer.Warranty = int.Parse(warranty);
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine("Virheellinen takuutieto, vain kuukausien määrä kokonaislukuna " + ex.Message);
                            break;
                        }

                        Console.Write("Prosessorin tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Keskusmuistin määrä (GB): ");
                        string amountRam = Console.ReadLine();
                        try
                        {
                            computer.AmountRam = int.Parse(amountRam);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen muistin määrä, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        Console.Write("Tallennuskapasiteetti (GB): ");
                        string storageCapacity = Console.ReadLine();
                        try
                        {
                            computer.StorageCapacity = int.Parse(storageCapacity);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu" + ex.Message);
                            break;
                        }
                    

                        // Näytetään olion tiedot metodien avulla
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();
                        try
                        {
                            computer.CalculateWarrantyEndingDate();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ostopäivä virheellinen " + ex.Message);
                            break;
                        }

                        // Lisätään tietokone vektoriin
                        computers[numberOfComputers] = computer;
                        Console.WriteLine("Vektorin indeksi on nyt " + numberOfComputers);
                        numberOfComputers++;
                        Console.WriteLine("Nyt syötettiin " + numberOfComputers + ". kone");

                        // Vaithoehtoisesti lisätään tietokone pinoon
                        computerStack.Push(computer);

                        break;

                    case "2":
                        Console.Write("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
                        break;


                    default:
                        Console.WriteLine("Virheellinen valinta, anna pelkkä numero");
                        break;

                }

                // Ohjelman sulkeminen: poistutaan ikuisesta silmukasta
                Console.WriteLine("Haluatko jatkaa K/e");
                string continueAnswer = Console.ReadLine();
                continueAnswer = continueAnswer.Trim();
                continueAnswer = continueAnswer.ToLower();
                if (continueAnswer == "e")
                {
                    // Vektorissa on se määrä alkioita, jotka sille on alustavasti annettu
                    Console.WriteLine("Tietokonevektorissa on " + computers.Length + " alkiota");
                    Console.WriteLine("Pinossa on nyt " + computerStack.Count + " tietokonetta");

                    // Tallenetaan koneiden tiedot tiedostoon serialisoimalla
                    formatter.Serialize(writeStream, computers);
                    writeStream.Close();

                    // Määritellään file stream tietokoneiden tietojen lukemista varten
                    // Stream readStream = new FileStream("ComputerData.dat",
                        // FileMode.Open, FileAccess.Read);

                    break;
                }
            }
           

            // Pidetään ikkuna auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}