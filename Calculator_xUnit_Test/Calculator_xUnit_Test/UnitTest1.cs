using Xunit;
using Hesap.Makinesi;
using System;

namespace HesapMakinesi.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculate_Plus()
        {
            int result = Calculator.Calculate("2 + 3");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calculate_PlusAndMultiply()
        {
            int result = Calculator.Calculate("2 + 3 * 4");
            Assert.Equal(14, result);
        }

        [Fact]
        public void Calculate_InvalidExpression_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Calculate("2 +"));
        }

        [Fact]
        public void Calculate_DivideByZero()
        {
            int result = Calculator.Calculate("10 / 0");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_Minus()
        {
            int result = Calculator.Calculate("5 - 3");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_Completed()
        {
            int result = Calculator.Calculate("10 + 2 * 3 - 4 / 2");
            Assert.Equal(14, result);
        }
    }
}
