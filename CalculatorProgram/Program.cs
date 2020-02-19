using Calculator;
using NLog;
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
                container.RegisterFactory<ILogger>(l => LogManager.GetCurrentClassLogger());

                // Dummy diagnostics interface that doesn't report anything
                //container.RegisterFactory<ILogger>(l => LogManager.CreateNullLogger());

                container.RegisterType<ISimpleCalculator, SimpleCalculator>();

                // Resolve
                ILogger logger = container.Resolve<ILogger>();

                ISimpleCalculator calculator = container.Resolve<ISimpleCalculator>(new ResolverOverride[] { new ParameterOverride("logger", logger) });

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
