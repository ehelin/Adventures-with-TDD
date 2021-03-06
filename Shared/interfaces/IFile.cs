﻿namespace Shared.interfaces
{
    public interface IFile
    {
        bool CreateDirectory(string directory);
        bool DeleteDirectory(string directory);
        bool CreateFile(string path);
        bool DeleteFile(string path);
        bool WriteToFile(string path, string msg);
        string ReadFromFile(string path);
    }
}
