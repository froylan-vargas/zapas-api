using FluentAssertions;
using Zapas.Helpers;

namespace zapas.Tests.Helpers
{
    public class DateHelperTest
    {
        [Fact]
        public void Should_Return_Seconds()
        {
            var seconds = DateHelper.RaceTimeToSeconds("00:01:00");
            seconds.Should().Be(60);
            seconds = DateHelper.RaceTimeToSeconds("01:00:00");
            seconds.Should().Be(3600);
            seconds = DateHelper.RaceTimeToSeconds("01:00");
            seconds.Should().Be(60);
            seconds = DateHelper.RaceTimeToSeconds("1:1");
            seconds.Should().Be(61);
        }

        [Fact]
        public void Should_Return_Zero()
        {
            var seconds = DateHelper.RaceTimeToSeconds("hola");
            seconds.Should().Be(0);
        }
    }
}
