namespace Shared.interfaces
{
    public interface IWindowsDirectory
    {
        bool CreateDirectory(string directory);
        bool DeleteDirectory(string directory);
    }
}
