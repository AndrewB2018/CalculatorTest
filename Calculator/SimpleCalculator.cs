using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly ILogger _logger;

        public SimpleCalculator (ILogger logger)
        {
            _logger = logger;
        }

        public int Add(int start, int amount)
        {
            try
            {
                int result = start + amount;

                _logger.Log(LogLevel.Info, $"Add calculation result: {result}");

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

                _logger.Log(LogLevel.Info, $"Subtract calculation result: {result}");

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

                _logger.Log(LogLevel.Info, $"Multiply calculation result: {result}");

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

                _logger.Log(LogLevel.Info, $"Divide calculation result: {result}");

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to divide values start:{start}, amount: {amount}");
            }
        }
    }
}
