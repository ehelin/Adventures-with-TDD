using Shared.interfaces;

namespace AdventuresWithTDD
{
    class Program
    {
        //TODO - Add autofac
        static void Main(string[] args)
        {
            IWindowsDirectory windowsDirectory = new WindowsDirectoryImpl.WindowsDirectoryImpl();
            IWindowsFile windowsFile = new WindowsFileImpl.WindowsFileImpl();

            IFile file = new FileImpl.FileImpl(windowsDirectory, windowsFile);

            string directory = "C:\\temp\\testing\\";
            string filePath = directory + "test.txt";
            string fileContents = "Testing a file insert";

            file.CreateDirectory(directory);
            file.CreateFile(filePath);
            file.WriteToFile(filePath, fileContents);

            string result = file.ReadFromFile(filePath);

            file.DeleteFile(filePath);
            file.DeleteDirectory(directory);
        }
    }
}
