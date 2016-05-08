using System.IO;
using NUnit.Framework;
using Shared.interfaces;

namespace Tests_Nunit
{
    [TestFixture]
    public class UnitTests_IWindowsDirectory
    {
        private IWindowsDirectory windowsDirectoryImpl = null;
        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [OneTimeSetUp]
        public void InitializeTest()
        {
            windowsDirectoryImpl = new WindowsDirectoryImpl.WindowsDirectoryImpl();

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [Test]
        public void Nunit_TestMethod_WindowsDirectory_CreateDirectory()
        {
            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    File.Delete(file);
                }

                Directory.Delete(directory);
            }

            Assert.IsTrue(windowsDirectoryImpl.CreateDirectory(directory));
            Assert.IsTrue(Directory.Exists(directory));
        }

        [Test]
        public void Nunit_TestMethod_WindowsDirectory_DeleteDirectory()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Assert.IsTrue(windowsDirectoryImpl.DeleteDirectory(directory));
            Assert.IsFalse(Directory.Exists(directory));
        }        
    }
}
