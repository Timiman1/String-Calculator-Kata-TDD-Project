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

        [Theory]
        [InlineData("1,2")]
        [InlineData("2,1")]
        public void Should_Return_3_When_Adding_1_And_2_Separated_By_Comma(string numbers)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add(numbers);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData("1,2,3,45")]
        [InlineData("45,3,2,1")]
        public void Should_Return_51_When_Adding_1_And_2_And_3_And_45_Separated_By_Commas(string numbers)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add(numbers);

            Assert.Equal(51, result);
        }

        [Theory]
        [InlineData("1,2\n3,4\n5")]
        [InlineData("5\n4,3\n2,1")]
        public void Should_Return_15_When_Adding_1_And_2_And_3_And_4_And_5_Separated_By_Commas_And_NewLines(string numbers)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add(numbers);

            Assert.Equal(15, result);
        }

        [Theory]
        [InlineData("//;\n1;2\n3,4;5")]
        [InlineData("//%\n5%4,3\n2%1")]
        [InlineData("//$\n5$4,3\n2$1")]
        public void Should_Return_15_When_Adding_1_And_2_And_3_And_4_And_5_Separated_By_Commas_And_NewLines_And_Custom_Delimeter(string numbers)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add(numbers);

            Assert.Equal(15, result);
        }
    }
}