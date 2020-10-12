using System.Security;

namespace Cargo_Transportation.Interfaces
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
