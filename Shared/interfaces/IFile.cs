namespace Shared.interfaces
{
    public interface IFile
    {
        void CreateDirectory(string directory);
        void DeleteDirectory(string directory);
        void CreateFile(string path);
        void DeleteFile(string path);
        void WriteToFile(string path, string msg);
        string ReadFromFile(string path);
    }
}
