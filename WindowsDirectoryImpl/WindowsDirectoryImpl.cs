using Shared.interfaces;
using System.IO;

namespace WindowsDirectoryImpl
{
    public class WindowsDirectoryImpl : IWindowsDirectory
    {
        public bool CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return true;
        }

        public bool DeleteDirectory(string directory)
        {
            bool result = false;

            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    File.Delete(file);
                }

                Directory.Delete(directory);

                result = true;
            }

            return result;
        }
    }
}
