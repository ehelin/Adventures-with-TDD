using Shared.interfaces;

namespace AdventuresWithTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            IFile file = new FileImpl.FileImpl();

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
