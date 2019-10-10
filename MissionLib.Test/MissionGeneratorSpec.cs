using System;
using Xunit;

namespace MissionLib.Test
{
    public class MissionGeneratorSpec
    {
        [Fact]
        public void can_generate_mission()
        {
            var sut = new MissionGenerator();
            var result = sut.Generate(3, 4, 7, 5);
            Assert.Equal(5, result.Answer.Count);
            Assert.Equal(4, result.Rotors.Count);
            Assert.True(sut.CheckAnswer(result, result.Answer.ToArray()));
        }

        [Fact]
        public void can_generate_at_maximum()
        {
            var sut = new MissionGenerator();
            var result = sut.Generate(12, 12, 132, 10);
            Assert.Equal(10, result.Answer.Count);
            Assert.Equal(12, result.Rotors.Count);
            Assert.True(result.Rotors.TrueForAll(x => x.CurrentState == 2));
            Assert.True(sut.CheckAnswer(result, result.Answer.ToArray()));
        }
    }
}
