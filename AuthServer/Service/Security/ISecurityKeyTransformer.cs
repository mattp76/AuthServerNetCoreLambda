using System.Threading.Tasks;

namespace AuthServer.Service.Security
{
    public interface ISecurityKeyTransformer
    {
        Task Transform(params object[] configs);
    }
}