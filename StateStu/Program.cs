using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateStu
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new ConcreteStateA());

            context.Request();

            context.Request();

            context.Request();

            context.Request();

            context.Request();

            Console.ReadLine();

            WorkContext contextObj = new WorkContext(new MorningState());

            contextObj.Hour = 6; contextObj.Request();

            contextObj.Hour = 9; contextObj.Request();

            contextObj.Hour = 12; contextObj.Request();

            contextObj.Hour = 15; contextObj.Request();

            contextObj.Hour = 22; contextObj.Request();

            contextObj.Hour = 31; contextObj.Request();

            Console.ReadLine();

        }
    }

    public class Context
    {
        public Context(state state) { ConcreteState = state; }

        public state ConcreteState { get; set; }

        #region concreteState
        //private state concreteState;

        //public state ConcreteState
        //{
        //    get { return concreteState; }

        //    set
        //    {

        //        concreteState = value;

        //        Console.WriteLine("Current State : " + concreteState.GetType().Name);
        //    }
        //} 
        #endregion

        public void Request()
        {
            //Console.WriteLine(ConcreteState.ToString());
            ConcreteState.Handle(this);
        }
    }

    public abstract class state
    {
        public abstract void Handle(Context context);
    }

    public class ConcreteStateA : state
    {
        public override void Handle(Context context)
        {
            Console.WriteLine(" Handle Operation State A");

            context.ConcreteState = new ConcreteStateB();
        }
    }
    public class ConcreteStateB : state
    {
        public override void Handle(Context context)
        {
            Console.WriteLine(" Handle Operation State B");

            context.ConcreteState = new ConcreteStateC();
        }
    }

    public class ConcreteStateC : state
    {
        public override void Handle(Context context)
        {
            Console.WriteLine(" Handle Operation State C");

            context.ConcreteState = new ConcreteStateA();

        }
    }

    public class WorkContext 
    {
        public WorkContext(WorkState state)
        { 
            WorkState = state;
        }

        public WorkState WorkState { get; set; }

        public int Hour { get; set; }

        public void Request()
        {
            WorkState.Handle(this);
        }

    }

    public abstract class WorkState
    {
        public abstract void Handle(WorkContext context);
    }

    public class MorningState : WorkState
    {
        public override void Handle(WorkContext context)
        {
            if (context.Hour < 8)
            {
                Console.WriteLine("Morning State");
            }
            else
            {
                context.WorkState = new ForenoonState();
                context.Request();
            }
        }
    }


    public class ForenoonState : WorkState
    {
        public override void Handle(WorkContext context)
        {
            if (context.Hour < 11)
            {
                Console.WriteLine("Forenoon State");
            }
            else
            {
                context.WorkState = new NoonState();
                context.Request();
            }
        }
    }

    public class NoonState : WorkState
    {
        public override void Handle(WorkContext context)
        {
            if (context.Hour < 13)
            {
                Console.WriteLine("Noon State");
            }
            else
            {
                context.WorkState = new AfternoonState();
                context.Request();
            }
        }
    }

    public class AfternoonState : WorkState
    {
        public override void Handle(WorkContext context)
        {
            if (context.Hour < 18)
            {
                Console.WriteLine("Afternoon State");
            }
            else
            {
                context.WorkState = new EveningState();
                context.Request();
            }
        }
    }

    public class EveningState : WorkState
    {
        public override void Handle(WorkContext context)
        {
            if (context.Hour < 24)
            {
                Console.WriteLine("Evening State");
            }
            else
            {
                Console.WriteLine("Error Input");
            }
        }
    }
   


}
