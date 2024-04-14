using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;


namespace ConfigEnv
{
    public sealed class Config : IConfig
    {
        private static readonly Config _config = new Config();
        private const string AWS_SSM = "AWS_SSM_";
        public const string AWS_DEFAULT_REGION = "AWS_DEFAULT_REGION";
        public const string DEFAULT_REGION = "us-east-1";
        
        private readonly AmazonSimpleSystemsManagementClient? _ssmClient;

        static Config()
        {
        }

        private Config()
        {
            Console.WriteLine("Starting ConfigEnv AWS");
            string region = GetEnv(AWS_DEFAULT_REGION).Result == "" ? DEFAULT_REGION : GetEnv(AWS_DEFAULT_REGION).Result;
            Console.WriteLine($"Current AWS region set to {region}");
            _ssmClient = new AmazonSimpleSystemsManagementClient(RegionEndpoint.GetBySystemName(region));
        }

        public static Config Instance
        {
            get { return _config; }
        }

        public async Task<string> GetEnv(string key, string defaultValue = "")
        {
            if (key.StartsWith(AWS_SSM))
            {
                string ssmKey = key.Substring(AWS_SSM.Length);
                return await GetFromSsmAsync(ssmKey);
            }
            return Environment.GetEnvironmentVariable(key) ?? defaultValue;
        }

        private async Task<string> GetFromSsmAsync(string key, string defaultValue = "")
        {
            return (await _ssmClient!.GetParameterAsync(new GetParameterRequest { Name = key, WithDecryption = true })).Parameter.Value;
        }
    }
}