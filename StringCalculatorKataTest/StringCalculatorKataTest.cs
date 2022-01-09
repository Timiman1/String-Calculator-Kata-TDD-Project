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

        [Fact]
        public void Should_Throw_Exception_With_Error_Message_When_Adding_Negatives()
        {
            var kata = new StringCalculatorKata();

            var exception = Assert.Throws<ArgumentException>(() => kata.Add("-5,6,-78"));

            Assert.Equal("negatives not allowed: -5 -78", exception.Message);
        }

        [Fact]
        public void Should_Return_103_When_Adding_1_And_2_And_100_And_1001_Because_Numbers_Greater_Than_1000_Gets_Ignored()
        {
            var kata = new StringCalculatorKata();

            int result = kata.Add("//€\n1,2€100\n1001");

            Assert.Equal(103, result);
        }

        [Theory]
        [InlineData("//[%%]\n1%%2%%3")]
        [InlineData("//[¤¤¤]\n1¤¤¤2¤¤¤3")]
        [InlineData("//[!#&$£]\n1!#&$£2!#&$£3")]
        public void Should_Return_6_When_Adding_1_And_2_And_3_And_Using_Custom_Delimeters_Of_Any_Length(string numbers)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add(numbers);

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData("//[%][$]\n10%20$30\n40,50")]
        [InlineData("//[%][$][£]\n10%20$30£40,50")]
        [InlineData("//[?][£][$][!]\n10!20$30£40?50")]
        public void Should_Return_150_When_Adding_10_And_20_And_30_And_40_And_50_Separated_By_Multiple_Custom_Delimeters_And_Commas_And_Newlines(string numbers)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int result = kata.Add(numbers);

            Assert.Equal(150, result);
        }
    }
}