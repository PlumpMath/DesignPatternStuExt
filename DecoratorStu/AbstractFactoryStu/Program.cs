using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryStu
{
    class Program
    {
        static void Main(string[] args)
        {
            //IFactory factory = new SqlServerFactory();
            //IFactory factory = new AccessFactory();



            IFactory factory = DataAccess.CreateFacotry();

            //IUser user = DataAccess.CreateUser(); 
            
            IUser user = factory.CreateUser();

            user.Insert(null); user.GetUser(0);

            //IDepartment department = DataAccess.CreateDepartment(); 
            
            IDepartment department = factory.CreateDepartment();

            department.Insert(null); department.GetDepartment(0);

            Console.ReadLine();
        }
    }

    class DataAccess
    {
        private static readonly string db =  ConfigurationManager.AppSettings["DB"];

        private static readonly string name = "AbstractFactoryStu";

        public static IFactory CreateFacotry()
        {
            return (IFactory)Assembly.Load(name).CreateInstance(name +"."+ db + "Factory");
        }

        public static IUser CreateUser()
        {
            return (IUser)Assembly.Load(name).CreateInstance(name + "." + db + "User");
        }

        public static IDepartment CreateDepartment()
        {
            return (IDepartment)Assembly.Load(name).CreateInstance(name + "." + db + "Department");
        }
    }

    interface IUser
    {
        IUser GetUser(int id);
        void Insert(IUser user);
    }

    interface IDepartment
    {
        IUser GetDepartment(int id);
        void Insert(IDepartment department);
    }

    
    interface IFactory
    {
        IUser CreateUser();

        IDepartment CreateDepartment();
    }
    
    class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlServerUser();
        }

        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }

    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }

        public IDepartment CreateDepartment()
        {
            return new AccessDepartment();
        }
    }
    

    class SqlServerDepartment : IDepartment
    {
        public IUser GetDepartment(int id)
        {
            Console.WriteLine("Get Department Form SqlServer "); return null;
        }

        public void Insert(IDepartment department)
        {
            Console.WriteLine("Inser Department to SqlServer ");
        }
    }

    class AccessDepartment : IDepartment
    {
        public IUser GetDepartment(int id)
        {
            Console.WriteLine("Get Department Form Access "); return null;
        }

        public void Insert(IDepartment department)
        {
            Console.WriteLine("Inser Department to Access ");
        }
    }

    class SqlServerUser : IUser
    {
        public IUser GetUser(int id)
        {
            Console.WriteLine("Get User Form SqlServer "); return null;
        }

        public void Insert(IUser user)
        {
            Console.WriteLine("Inser User to SqlServer ");
        }
    }

    class AccessUser : IUser
    {
        public IUser GetUser(int id)
        {
            Console.WriteLine("Get User Form Access "); return null;
        }

        public void Insert(IUser user)
        {
            Console.WriteLine("Inser User to Access ");
        }
    }

}
