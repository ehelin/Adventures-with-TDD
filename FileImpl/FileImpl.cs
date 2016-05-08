using System;
using Shared.interfaces;
using System.IO;

namespace FileImpl
{
    public class FileImpl : IFile
    {
        private IWindowsDirectory windowsDirectory = null;
        private IWindowsFile windowsFile = null;

        public FileImpl(IWindowsDirectory windowsDirectory, IWindowsFile windowsFile)
        {
            this.windowsDirectory = windowsDirectory;
            this.windowsFile = windowsFile;
        }

        public bool CreateDirectory(string directory)
        {
            bool result = windowsDirectory.CreateDirectory(directory);

            return result;
        }

        public bool DeleteDirectory(string directory)
        {
            bool result = windowsDirectory.DeleteDirectory(directory);

            return result;
        }

        public bool CreateFile(string path)
        {
            bool result = windowsFile.CreateFile(path);

            return result;
        }

        public bool DeleteFile(string path)
        {
            bool result = windowsFile.DeleteFile(path);

            return result;
        }

        public string ReadFromFile(string path)
        {
            string result = windowsFile.ReadFromFile(path);

            return result;
        }

        public bool WriteToFile(string path, string msg)
        {
            bool result = windowsFile.WriteToFile(path, msg);

            return result;
        }
    }
}
