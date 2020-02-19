using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class SimpleCalculator : ISimpleCalculator
    {
        public int Add(int start, int amount)
        {
            try
            {
                return start + amount;
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
                return start - amount;
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
                return start * amount;
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
                return start / amount;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to divide values start:{start}, amount: {amount}");
            }
        }
    }
}
