using Calculator;
using Data;
using Data.Context;
using Data.Repository.EntityFramework;
using Diagnostics;
using Entities.Models;
using System;
using System.Linq;
using System.Net.Http;
using Unity;
using Unity.Resolution;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                IUnityContainer container = new UnityContainer();

                // Register
                // Diagnostics interface that reports logs
                container.RegisterType<IDiagnostics, DiagnosticsConsole>();

                // Dummy diagnostics interface that doesn't report anything
                //container.RegisterType<IDiagnostics, DiagnosticsDummy>();

                // Diagnostics interface that writes logs to database
                //container.RegisterType<IDiagnosticsRepository, DiagnosticsRepository>();
                //container.RegisterType<IDiagnostics, DiagnosticsDatabase>();

                container.RegisterType<ISimpleCalculator, SimpleCalculator>();

                // Resolve
                IDiagnostics diagnostics = container.Resolve<IDiagnostics>();

                ISimpleCalculator calculator = container.Resolve<ISimpleCalculator>(new ResolverOverride[] { new ParameterOverride("diagnostics", diagnostics) });

                // Add method
                calculator.Add(0, 10);

                // Divide method
                calculator.Divide(9, 3);

                // Subtract method
                calculator.Subtract(10, 4);

                // Multiply method
                calculator.Multiply(5, 5);

                // Using web service
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44333/calculator/");

                    //HTTP GET
                    var responseTask = client.GetAsync("add/10/15");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        string resultValue = readTask.Result;

                        Console.WriteLine("Web Service Add result: " + resultValue);

                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Unable to run simple calculator program", e);
            }
        }

    }
}
