using Moq;
using NLog;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class ISimpleCalculatorTest
    {
        ISimpleCalculator calculator;
        Mock<ILogger> mockLogger;

        [SetUp]
        public void Setup()
        {
            mockLogger = new Mock<ILogger>();
            calculator = new SimpleCalculator(mockLogger.Object);
        }

        [Test]
        public void CalculatorAddTest()
        {
            //Arrange
            int start = 2;
            int amount = 5;
            int expected = 7;
            int actual;

            //Act
            actual = calculator.Add(start, amount);

            //Assert
            Assert.AreEqual(expected, actual, $"{start} add {amount} should be {expected}");

            //Verify logger is called
            mockLogger.Verify(m => m.Log(LogLevel.Info, $"Add calculation result: {expected}"), Times.Exactly(1));
        }

        [Test]
        public void CalculatorSubtractTest()
        {
            //Arrange
            int start = 10;
            int amount = 4;
            int expected = 6;
            int actual;

            //Act
            actual = calculator.Subtract(start, amount);

            //Assert
            Assert.AreEqual(expected, actual, $"{start} subtract {amount} should be {expected}");

            //Verify logger is called
            mockLogger.Verify(m => m.Log(LogLevel.Info, $"Subtract calculation result: {expected}"), Times.Exactly(1));
        }

        [Test]
        public void CalculatorMultiplyTest()
        {
            //Arrange
            int start = 10;
            int amount = 4;
            int expected = 40;
            int actual;

            //Act
            actual = calculator.Multiply(start, amount);

            //Assert
            Assert.AreEqual(expected, actual, $"{start} multiplied by {amount} should be {expected}");

            //Verify logger is called
            mockLogger.Verify(m => m.Log(LogLevel.Info, $"Multiply calculation result: {expected}"), Times.Exactly(1));
        }

        [Test]
        public void CalculatorDivideTest()
        {
            //Arrange
            int start = 9;
            int amount = 3;
            int expected = 3;
            int actual;

            //Act
            actual = calculator.Divide(start, amount);

            //Assert
            Assert.AreEqual(expected, actual, $"{start} divided by {amount} should be {expected}");

            //Verify logger is called
            mockLogger.Verify(m => m.Log(LogLevel.Info, $"Divide calculation result: {expected}"), Times.Exactly(1));
        }
    }
}