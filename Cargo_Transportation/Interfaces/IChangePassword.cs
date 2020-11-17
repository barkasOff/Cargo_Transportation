using System.Security;

namespace Cargo_Transportation.Interfaces
{
	public interface IChangePassword
    {
        SecureString CurPass { get; }
        SecureString NewPass { get; }
        SecureString RepNewPass { get; }
    }
}
