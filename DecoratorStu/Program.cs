using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorStu
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent ConcreteComponet = new ConcreteComponent();
            ConcreteDecoratorA DecoratorA = new ConcreteDecoratorA();
            ConcreteDecoratorB DecoratorB = new ConcreteDecoratorB();
            DecoratorA.SetComponent(ConcreteComponet);
            DecoratorB.SetComponent(DecoratorA);
            DecoratorB.Operation();

            Console.ReadLine();
        }
    }

    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Concrete Component.");
        }
    }

    public class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }

        public void OperationComponent()
        {
            if (component != null)
            {
                Console.WriteLine("=" + this.ToString());
                component.Operation();
            }
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation(); 

            //OperationComponent();

            Console.WriteLine("Concrete Decorator A."); 
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();

            //OperationComponent();

            Console.WriteLine("Concrete Decorator B."); 
        }
    }
}
