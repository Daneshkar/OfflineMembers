using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service1Controller : ControllerBase
    {
        public HomeServiceA ServiceA { get; set; }
        public HomeServiceB ServiceB { get; set; }
        public HomeServiceC ServiceC { get; set; }
        public ValidationService ValidationService { get; }

        public Service1Controller(
            HomeServiceA serviceA
            , HomeServiceB serviceB
            , HomeServiceC serviceC
            , ValidationService validationService
            )
        {
            ServiceA = serviceA;
            ServiceB = serviceB;
            ServiceC = serviceC;
            ValidationService = validationService;
        }

        [HttpGet(Name = "Service1")]
        public string Get()
        {
            ServiceA.Calc(10);
            ServiceB.Calc(10);
            ServiceC.Calc(10);

            ValidationService.IsValid();
            StringBuilder sb1 = new();
            sb1.Append("Scoped / ServiceA.CalcValue = ");
            sb1.Append(ServiceA.CalcValue);
            sb1.Append(Environment.NewLine);
            sb1.Append("Singleton / ServiceB.CalcValue = ");
            sb1.Append(ServiceB.CalcValue);
            sb1.Append(Environment.NewLine);
            sb1.Append("Transient / ServiceC.CalcValue = ");
            sb1.Append(ServiceC.CalcValue);
            return sb1.ToString();
        }
    }

    public class Model { }
    public class HomeServiceA
    {
        public int CalcValue { get; set; }
        public void Calc(int val)
        {
            CalcValue += val;
        }
    }
    public class HomeServiceB
    {
        public int CalcValue { get; set; }
        public void Calc(int val)
        {
            CalcValue += val;
        }
        public bool IsValid(Model model)
        {
            return true;
        }
    }
    public class HomeServiceC
    {
        public int CalcValue { get; set; }
        public void Calc(int val)
        {
            CalcValue += val;
        }
        public bool IsValid(Model model)
        {
            return true;
        }
    }

    public class ValidationService
    {
        public HomeServiceA ServiceA { get; set; }
        public HomeServiceB ServiceB { get; set; }
        public HomeServiceC ServiceC { get; set; }

        public ValidationService(HomeServiceA serviceA
            , HomeServiceB serviceB
            , HomeServiceC serviceC
            )
        {
            ServiceA = serviceA;
            ServiceB = serviceB;
            ServiceC = serviceC;
        }

        public void IsValid()
        {
            ServiceA.Calc(10);
            ServiceB.Calc(10);
            ServiceC.Calc(10);

            int x = ServiceA.CalcValue;
            int x2 = ServiceB.CalcValue;
            int x3 = ServiceC.CalcValue;
        }
    }
}