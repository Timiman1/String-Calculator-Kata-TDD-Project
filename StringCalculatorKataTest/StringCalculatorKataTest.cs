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
    }
}