using System.Threading.Tasks;

namespace ConfigEnv
{
    public interface IConfig
    {
        Task<string> GetEnv(string key, string defaultValue = "");
    }
}