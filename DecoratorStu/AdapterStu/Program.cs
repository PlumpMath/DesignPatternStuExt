using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterStu
{
    class Program
    {
        static void Main(string[] args)
        {

            Player translator = new AdapterTranslator("姚明");

            Player player = new Forwards("yaoming");

            translator.Attack();

            translator.Defense();

            player.Attack();

            player.Defense();

            Console.ReadLine();
        }
    }

    abstract class Player
    {
        protected string name;

        public Player(string name)
        {
            this.name = name;
        }

        public abstract void Attack();

        public abstract void Defense();
    }

    class Forwards : Player
    {
        public Forwards(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine("Forwards Attack {0}",name);
        }

        public override void Defense()
        {
            Console.WriteLine("Forwards Attack {0}",name);
        }
    }

    class AdapterTranslator : Player
    {
        ForeignForwards foreignForwards;

        public AdapterTranslator(string name) : base(name) 
        {
            foreignForwards = new ForeignForwards(name);
        }

        public override void Attack()
        {
            foreignForwards.GongJi();
        }

        public override void Defense()
        {
            foreignForwards.FangYu();
        }
    }


    class ForeignForwards
    { 
        public string mingzi;

        public ForeignForwards(string mingzi)
        {
            this.mingzi = mingzi;
        }

        public void GongJi()
        {
            Console.WriteLine("ForeignForwards Attack {0}", mingzi);
        }

        public void FangYu()
        {
            Console.WriteLine("ForeignForwards Attack {0}", mingzi);
        }
    }


}
