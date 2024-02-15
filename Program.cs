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

    }

    // Tietokondeiden luokka, perii ominaisuuksia ja metodeja laiteluokasta Device


    // Pääohjelman luokka, josta tulee Program.exe
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ohjelman varsinaiset toiminnot tapahtuvat täällä.
            // Ohjelma kysyy käyttäjältä tietoja laitteista ja vastaamalla kysymyksiin tiedot tallennetann muuttujiin.

            // Luodaan uusi laite Device-luokasta
            Device laite = new Device("Opintokone");
            Console.WriteLine("Laitteen nimi on: " + laite.Name);
            laite.PurchaseDate = "14.11.2023";
            Console.WriteLine("Ostopäivä oli: " + laite.PurchaseDate);

            // Pidetään ikkuna auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}