namespace Shared.interfaces
{
    public interface IWindowsFile
    {
        bool CreateFile(string path);
        bool DeleteFile(string path);
        bool WriteToFile(string path, string msg);
        string ReadFromFile(string path);
    }
}
