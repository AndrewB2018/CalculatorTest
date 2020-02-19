using Diagnostics;
using System;

namespace Calculator
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly IDiagnostics _diagnostics;

        public SimpleCalculator (IDiagnostics diagnostics)
        {
            _diagnostics = diagnostics;
        }

        public int Add(int start, int amount)
        {
            try
            {
                int result = start + amount;

                _diagnostics.Log($"Add calculation result: {result}");

                return result;
            }
            catch(Exception e)
            {
                throw new Exception($"Unable to add values start:{start}, amount: {amount}");
            }
        }

        public int Subtract(int start, int amount)
        {
            try
            { 
                int result = start - amount;

                _diagnostics.Log($"Subtract calculation result: {result}");

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to subtract values start:{start}, amount: {amount}");
            }
        }

        public int Multiply(int start, int amount)
        {
            try
            { 
                int result = start * amount;

                _diagnostics.Log($"Multiply calculation result: {result}");

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to multiply values start:{start}, amount: {amount}");
            }

        }

        public int Divide(int start, int amount)
        {
            try
            { 
                int result = start / amount;

                _diagnostics.Log($"Divide calculation result: {result}");

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to divide values start:{start}, amount: {amount}");
            }
        }
    }
}
