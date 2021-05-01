using ConfigEnv;
using System;
using Xunit;

namespace ConfigEnv.Test
{
    public class ConfigEnvTest
    {
        [Theory]
        [InlineData("EMPTY_VAR", "", "")]
        [InlineData("SECRET_VAR", "supersecret", "supersecret")]
        public void GetValueFromEnvironment(string envVar, string value, string expected)
        {
            Environment.SetEnvironmentVariable(envVar, value);
            Assert.Equal(expected, Config.Instance.GetEnv(envVar).Result);
        }

        [Fact]
        public void GetNonExistantEnvironment()
        {
            Assert.Equal("", Config.Instance.GetEnv("SHOULD_NOT_EXIST").Result);
        }
    }
}
