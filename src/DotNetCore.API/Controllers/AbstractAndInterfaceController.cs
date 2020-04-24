using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractAndInterfaceController : ControllerBase
    {
    }

    /// <summary>
    /// AbstractClassOne and AbstractClassTwo are abstract classes.
    /// IEmployee is an interface.
    /// Que Ans. Below statement is this Possible? 
    /// No -> Employee : AbstractClassOne
    /// 
    /// Yes -> AbstractClassOne : Employee
    /// 
    /// Yes -> AbstractClassOne : IEmployee
    /// 
    /// Yes -> AbstractClassOne : Employee, IEmployee
    /// 
    /// Yes -> AbstractClassOne : AbstractClassTwo, 
    /// 
    /// Yes -> AbstractClassOne : AbstractClassTwo, IEmployee
    /// 
    /// </summary>
    /// <seealso cref="AbstractClassOne" />
    public class Employee : AbstractClassOne, IEmployee
    {
        public override string GetCurrentUtcDateTime()
        {
            return DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }

        public string GetEmployeeFirstName()
        {
            return "Jay";
        }
    }

    public interface IEmployee
    {
        //Constructor is not possible
        //public IEmployee()
        //{
        //        
        //}

        //Static method is not possible
        //static string GetEmployeeName()
        //{
        //    return "Jay Mistry";
        //}

        // Trying to create constructor for interface but it is not allowed to create constructor of an interface.
        //CS0526	Interfaces cannot contain constructors
        //public IEmployee()
        //{
        //}

        //interface members cannot have a definition
        //string GetEmployeeName()
        //{ //Interface method can not declare a body
        //
        //    return "Jay Mistry";
        //}

        string GetEmployeeFirstName();
    }

    public abstract class AbstractClassOne
    {
        //We can write Static method in abstract class
        public static string GetStringData()
        {
            return "This is a demo string.";
        }

        //1. Constructor is possible
        //2. Public constructor is not required. Use Protected Access Modifier.
        //public AbstractClassOne()
        //{
        //
        //}

        //Making constructor as Protected is the best practice.
        //Because we can not create an instance of an abstract class so no need to make it as public constructor.
        protected AbstractClassOne()
        {

        }

        //This is the signature of the method.
        public abstract string GetCurrentUtcDateTime();
    }

    //This abstract class inherits one abstract class and one interface
    //Abstract class can inherit another abstract class 
    //Abstract class can inherit interface
    public abstract class AbstractClassTwo : AbstractClassOne, IEmployee
    {
        //It is not possible to create an object of the abstract class.
        //Error	CS0144	Cannot create an instance of the abstract class or interface
        //private AbstractClassOne a = new AbstractClassOne();

        string getStringFromAbstractClass = GetStringData();
        public string GetEmployeeFirstName()
        {
            return "Jay";
        }
    }
}