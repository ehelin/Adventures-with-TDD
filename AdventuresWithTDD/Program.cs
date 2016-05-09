using Shared.interfaces;
using Autofac;

namespace AdventuresWithTDD
{
    class Program
    {        
        static void Main(string[] args)
        {
            string directory = "C:\\temp\\testing\\";
            string filePath = directory + "test.txt";
            string fileContents = "Testing a file insert";

            IContainer container = BuildSystem();

            using (var scope = container.BeginLifetimeScope())
            {
                IFile file = scope.Resolve<IFile>();

                file.CreateDirectory(directory);
                file.CreateFile(filePath);
                file.WriteToFile(filePath, fileContents);

                string result = file.ReadFromFile(filePath);

                file.DeleteFile(filePath);
                file.DeleteDirectory(directory);
            }
        }

        private static IContainer BuildSystem()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WindowsDirectoryImpl.WindowsDirectoryImpl>().As<IWindowsDirectory>();
            builder.RegisterType<WindowsFileImpl.WindowsFileImpl>().As<IWindowsFile>();

            builder.Register(x => new FileImpl.FileImpl(x.Resolve<IWindowsDirectory>(), 
                                                        x.Resolve<IWindowsFile>()))
                                                        .As<IFile>();

            return builder.Build();
        }
    }
}
