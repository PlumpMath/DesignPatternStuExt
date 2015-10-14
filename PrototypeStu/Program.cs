using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeStu
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PrototypeRegion

            Prototype prototypeObj = new ConcretePrototype("First");

            prototypeObj.Des = "FunnyPrototypeObj";

            Prototype CloneObj = prototypeObj.Clone();

            DisplayInfomation(prototypeObj, CloneObj);

            CloneObj.ID = "Second"; prototypeObj.Des = "SorrowObj";

            DisplayInfomation(prototypeObj, CloneObj);

            //Console.ReadLine(); 

            #endregion

            Resume resume = new Resume("LiuSmile", "24");

            resume.SetWorkExperience("2013", "YYJC");


            Resume cloneObj = (Resume)resume.Clone();

            cloneObj.SetWorkExperience("2014", "JGW");


            Resume cloneObj2 = (Resume)cloneObj.Clone();

            cloneObj2.work.WorkCompany = "SnowCompany";

            cloneObj2.SetInformation("Snow", "12");

            resume.Display();
            cloneObj.Display();
            cloneObj2.Display();

            Console.ReadLine();
        }

        private static void DisplayInfomation(Prototype prototypeObj, Prototype CloneObj)
        {
            Console.WriteLine(prototypeObj.ID + " " + CloneObj.ID);

            Console.WriteLine(prototypeObj.Des + " " + CloneObj.Des);
        }
    }

    //.NET 提供了ICloneable接口，提供了Clone方法，直接实现这个接口就可以完成原型模式
    abstract class Prototype 
    {
        public string ID { get; set; }

        public string Des { get; set; }

        public Prototype(string id)
        {
            this.ID = id;
        }

        //关键 就是有这样一个Clone方法。
        public abstract Prototype Clone();
    }

    class ConcretePrototype : Prototype
    {
        public ConcretePrototype(string id) : base(id) { }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
            //创建当前对象的浅表副本，复制非静态字段到新对象。复制值和引用
        }
    }

    //**************************************

    public class WorkExperience : ICloneable
    {
        public string WorkDate { get; set; }

        public string WorkCompany { get; set; }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }

    public class Resume : ICloneable
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public WorkExperience work;

        public Resume(string name, string age)
        {
            SetInformation(name, age);
            work = new WorkExperience();
        }

        private Resume(WorkExperience we)
        {
            this.work = (WorkExperience)we.Clone();
        }


        private void CloneRefChild(Resume resume)
        {
            this.work = (WorkExperience)resume.work.Clone();
        }

        #region SetInfo

        public void SetWorkExperience(string date, string company)
        {
            work.WorkDate = date;
            work.WorkCompany = company;
        }

        public void SetInformation(string name, string age)
        {
            Name = name; Age = age;
        } 

        #endregion

        public void Display()
        {
            Console.WriteLine("Name " + Name + " Age " + Age);
            Console.WriteLine("Date " + work.WorkDate + " Company "+ work.WorkCompany);
        }

        public object Clone()
        {
            //return (Resume)this.MemberwiseClone();

            Resume obj = new Resume(this.work);
            obj.Name = this.Name;
            obj.Age = this.Age;
            return obj;

            //2015年10月14日20:13:04 我自己的改进不知道好不好。
            //Resume obj = (Resume)this.MemberwiseClone();
            //obj.CloneRefChild(this);
            //return obj;
        }
    }


}
