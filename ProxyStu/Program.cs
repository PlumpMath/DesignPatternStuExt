using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyStu
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxyObj = new Proxy();
            proxyObj.Request();
            Console.ReadLine();

            Console.WriteLine("********************");

            ProxyHuman proxyHuman = new ProxyHuman(new SchoolGirl() { Name = "HanMeimei" });
            proxyHuman.GiveChocolate();
            proxyHuman.GiveDolls();
            Console.ReadLine();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Real Subject Request");
        }
    }

    class Proxy : Subject
    {
        Subject realSubject;

        //public Proxy()
        //{
        //    realSubject = new RealSubject();
        //}

        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();
        }
    }


    /************************/

    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }

    class SchoolGirl
    {
        public string Name {get;set;}
    }

    class Pursuit : IGiveGift
    {
        SchoolGirl mm;

        public Pursuit(SchoolGirl mm)
        {
            this.mm = mm;
        }

        public void GiveDolls()
        {
            Console.WriteLine(mm.Name + " Give You Dolls");
        }

        public void GiveFlowers()
        {
            Console.WriteLine(mm.Name + " Give You Flowers");
        }

        public void GiveChocolate()
        {
            Console.WriteLine(mm.Name + " Give You Chocolates");
        }
    }

    class ProxyHuman : IGiveGift
    {
        Pursuit pursuit;

        public ProxyHuman(SchoolGirl mm)
        {
            pursuit = new Pursuit(mm);
        }

        public void GiveDolls()
        {
            pursuit.GiveDolls();
        }

        public void GiveFlowers()
        {
            pursuit.GiveFlowers();
        }

        public void GiveChocolate()
        {
            pursuit.GiveChocolate();
        }
    }


}
