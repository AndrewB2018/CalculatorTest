using Diagnostics;
using Moq;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class ISimpleCalculatorTest
    {
        ISimpleCalculator calculator;
        Mock<IDiagnostics> mockDiagnostics;

        [SetUp]
        public void Setup()
        {
            mockDiagnostics = new Mock<IDiagnostics>();
            calculator = new SimpleCalculator(mockDiagnostics.Object);
        }

        [Test]
        public void Add_NormalNumbers_Pass()
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
            mockDiagnostics.Verify(m => m.Log($"Add calculation result: {expected}"), Times.Exactly(1));
        }

        [Test]
        public void Subtract_NormalNumbers_Pass()
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
            mockDiagnostics.Verify(m => m.Log($"Subtract calculation result: {expected}"), Times.Exactly(1));
        }

        [Test]
        public void Multiply_NormalNumbers_Pass()
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
            mockDiagnostics.Verify(m => m.Log($"Multiply calculation result: {expected}"), Times.Exactly(1));
        }

        [Test]
        public void Divide_NormalNumbers_Pass()
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
            mockDiagnostics.Verify(m => m.Log($"Divide calculation result: {expected}"), Times.Exactly(1));
        }
    }
}