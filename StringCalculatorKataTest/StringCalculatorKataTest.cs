using StringCalculatorKataConsole;
using System;
using Xunit;

namespace TestProject
{
    public class StringCalculatorKataTest
    {
        [Fact]
        public void Should_Return_0_When_Adding_Empty_String()
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Should_Return_1_When_Adding_1()
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add("1");

            Assert.Equal(1, result);
        }
    }
}