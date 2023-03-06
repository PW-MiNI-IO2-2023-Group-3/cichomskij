using IO2Workshop;

namespace UnitTest1
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.sumString("");
            Assert.Equal(0, result);
        }
        [Theory]
        [InlineData("12",12)]
        [InlineData("1",1)]
        [InlineData("1212",0)]
        [InlineData("225",225)]
        public void SingleNumberReturnsValue(string str,int expectedValue)
        {
            int result = StringCalculator.sumString(str);
            Assert.Equal(result, expectedValue);
        }
        [Theory]
        [InlineData("12,1,1", 14)]
        [InlineData("1,123",124)]
        [InlineData("1,2,1,2", 6)]
        [InlineData("22,5", 27)]
        public void SumNumberBetweenCommas(string str, int expectedValue)
        {
            int result = StringCalculator.sumString(str);
            Assert.Equal(result, expectedValue);
        }

        [Theory]
        [InlineData("12\n4", 16)]
        [InlineData("1\n123", 124)]
        public void SumNumbersSepartedByNewLine(string str, int expectedValue)
        {
            int result = StringCalculator.sumString(str);
            Assert.Equal(result, expectedValue);
        }

        [Theory]
        [InlineData("12\n4,1", 17)]
        [InlineData("1,2\n123", 126)]
        [InlineData("1\n2\n123", 126)]
        [InlineData("1,2,123", 126)]
        public void SumNumberNewLineAndCommaSepatator(string str, int expectedValue)
        {
            int result = StringCalculator.sumString(str);
            Assert.Equal(result, expectedValue);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-213")]
        [InlineData("1\n2\n-123")]
        [InlineData("1,-2,123")]
        public void NegativNumberThorwsArgumentExceptino(string str)
        {
            //int result = StringCalculator.sumString(str);
            Assert.Throws<ArgumentException>(() => StringCalculator.sumString(str));
            //Assert.Equal(result, expectedValue);
        }

        [Theory]
        [InlineData("1001",0)]
        [InlineData("1000",1000)]
        [InlineData("1\n2\n1123",3)]
        [InlineData("2\n999",1001)]
        public void NumGresateThan1000AreIgineroed(string str,int expectedValue)
        {
            int result = StringCalculator.sumString(str);
            Assert.Equal(result, expectedValue);
        }

        [Theory]
        [InlineData("//#12#4,1", 17)]
        [InlineData("//q1q2q123", 126)]
        [InlineData("//#\n1", 1)]
        public void CustomSeparator (string str, int expectedValue)
        {
            int result = StringCalculator.sumString(str);
            Assert.Equal(result, expectedValue);
        }

    }
}