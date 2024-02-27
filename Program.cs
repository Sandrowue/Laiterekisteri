using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laiterekisteri
{
    // Yleinen laiteluokka, yliluokka tietokoneille, tableteille ja puhelimille
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

    }

    // Tietokondeiden luokka, perii ominaisuuksia ja metodeja laiteluokasta Device
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
                        Console.Write("Ostopäivä: ");
                        computer.PurchaseDate = Console.ReadLine();
                        Console.Write("Hankintahinta: ");
                        computer.Price = double.Parse(Console.ReadLine());
                        Console.Write("Takuun kesto kuukausina: ");
                        computer.Warranty = int.Parse(Console.ReadLine());
                        Console.Write("Prosessorin tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Keskusmuistin määrä (GB): ");
                        computer.AmountRam = int.Parse(Console.ReadLine());
                        Console.Write("Tallennuskapasiteetti (GB): ");
                        computer.StorageCapacity = int.Parse(Console.ReadLine());

                        // Näytetään olion tiedot metodien avulla
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();

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
                    break;
                }
            }
           

            // Pidetään ikkuna auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}