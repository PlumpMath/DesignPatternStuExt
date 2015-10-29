using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishSubscribeStu
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();
            Observer objA = new ConcreteObserverA("A_Liu", subject);
            Observer objB = new ConcreteObserverB("B_Zhang", subject);

            Observer objAExt = new ConcreteObserverA("A_Liu");
            Observer objBExt = new ConcreteObserverB("B_Zhang");

            subject.Update += objA.Update;
            subject.Update += objB.Update;

            subject.Update -= objA.Update;

            subject.Handle += objAExt.Trigger;
            subject.Handle += objBExt.Trigger;

            string input = Console.ReadLine();
            subject.SubjectState = input + " NotiyfInformation ";

            subject.Notify();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            subject.Handler();

            Console.ReadLine();

        }
    }

    public interface  Subject
    {
        void Notify();

        string SubjectState { get; set; }
    }

    public abstract class Observer
    {
        public string name;

        public Subject sub;

        public abstract void Update();

        public abstract void Trigger(Subject obj);
    }

    public delegate void MyEventHandler();

    public delegate void TestEventHandler(Subject obj);

    public class ConcreteSubject : Subject
    {
        public event MyEventHandler Update;

        public event TestEventHandler Handle;

        public  string SubjectState { get; set; }

        public void Notify()
        {
            Update();
        }

        public void Handler()
        {
            Handle(this);
        }
    }

    public class ConcreteObserverA : Observer
    {


        public ConcreteObserverA(string name)
        {
            this.name = name;
        }

        public ConcreteObserverA(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public override void Update()
        {
            Console.WriteLine(name + "  ConcreteObserverA : " + sub.SubjectState);
        }

        public override void Trigger(Subject obj)
        {
            Console.WriteLine(name + "  ConcreteObserverA : " + obj.SubjectState);
        }
    }

    public class ConcreteObserverB : Observer
    {


        public ConcreteObserverB(string name)
        {
            this.name = name;
        }

        public ConcreteObserverB(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }

        public override void Update()
        {
            Console.WriteLine(name + "  ConcreteObserverB : " + sub.SubjectState);
        }

        public override void Trigger(Subject obj)
        {
            Console.WriteLine(name + "  ConcreteObserverB : " + obj.SubjectState);
        }
    }
}
