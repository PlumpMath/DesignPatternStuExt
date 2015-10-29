using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoStu
{
    class Program
    {
        static void Main(string[] args)
        {
            Caretaker caretaker = new Caretaker();
            Originator player = new Originator();

            player.State1 = "Hello";
            player.State2 = "World";

            caretaker.MementoObj = player.SaveMemento();

            player.Show();

            player.Reset();

            player.Show();

            player.RecoveryMento(caretaker.MementoObj);

            player.Show();

            Console.ReadLine();

        }
    }

    class Originator
    {
        public string State1 { get; set; }
        public string State2 { get; set; }

        public Memento SaveMemento()
        {
            return new Memento(State1, State2);
        }

        public void RecoveryMento(Memento memento)
        {
            State1 = memento.State1;
            State2 = memento.State2;
        }

        public void Show()
        {
            Console.WriteLine("State1 : " + State1 + " State2 : " + State2);
        }

        public void Reset()
        {
            State1 = "Null";
            State2 = "No Informatioin";
        }
    }

    class Memento
    {
        public Memento(string str1, string str2)
        {
            State1 = str1; State2 = str2;
        }

        public string State1 { get; set; }
        public string State2 { get; set; }
    }

    class Caretaker
    {
        public Memento MementoObj { get; set; }
    }
}
