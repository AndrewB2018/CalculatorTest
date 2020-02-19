using Calculator;
using Diagnostics;
using System;
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

            }
            catch (Exception e)
            {
                throw new Exception($"Unable to run simple calculator program", e);
            }

        }

    }
}
