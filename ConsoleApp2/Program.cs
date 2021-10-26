using System;
using System.Collections.Generic;

namespace Zdacha_na_5
{
  public  class Ship
    {
        private string name;
       public Ship(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
        
        protected void showName(){ Console.WriteLine($"The speed is {name}");}
    }

   public class Admiral
    {
        private string name;
        private int age;
        public Squadron squadron = null;

       public Admiral(String name, int age, Squadron squad1)                  //У каждой эскадрильи есть только один адмирал    ассоциация 1:1
        {
            this.name = name;
            this.age = age;
            this.squadron = squad1;
        }
        public Admiral(){}

        public void ShootCorvette()
        {
            foreach (Ship ship in squadron.Ships)
            {
                if(ship is Corvette)
                    Console.WriteLine($"Admiral told {ship.GetName()} to shot");
            }
        }
        public void ShootFregate()
        {
            foreach (var ship in squadron.Ships)
            {
                if(ship is Fregate)
                    Console.WriteLine($"Admiral told {ship.GetName()} to shot");
            }
        }
        public void ShootAll()
        {
            foreach (Ship ship in squadron.Ships)
            {
                if(ship is Corvette)
                    Console.WriteLine($"Admiral told {ship.GetName()} to shot");
                if(ship is Fregate)
                    Console.WriteLine($"Admiral told {ship.GetName()} to shot");
            }
        }
    }

  public  class Squadron
    {
        public Ship[] Ships = new Ship[4] ;                    //Список кораблей входящих в эскадрилью
        public Admiral admiral = null;                

        public Squadron(Admiral adm1, Ship[] ships)                        //У каждого адмирала есть только одна эскадрилья    ассоциация 1:1
        {
            this.admiral = adm1;
            this.Ships = ships;
        }
        public Squadron(){}
        
    }
    
    
    

    class Corvette : Ship
    {
        public Corvette(string name)
            : base(name)
        {
        }
    }

    class Fregate : Ship
    {
       public Fregate(string name)
            : base(name)
        {
        }
    }
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Admiral Ush = new Admiral();
            Ship ship1 = new Corvette("Corvette 1");
            Ship ship2 = new Corvette("Corvette 2");
            Ship ship3 = new Fregate("Fregate 1");
            Ship ship4 = new Fregate("Fregate 2");
            Ship[] ships = new Ship[] {ship1, ship2, ship3, ship4};
            Squadron Squad = new Squadron(Ush, ships);
            Ush.squadron = Squad;
            Ush.ShootAll();
            Console.WriteLine("\n");
            Ush.ShootCorvette();
            Console.WriteLine("\n");
            Ush.ShootFregate();
        }
    }
}