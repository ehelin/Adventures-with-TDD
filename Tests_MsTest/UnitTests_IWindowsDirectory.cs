using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System.IO;

namespace Tests_MsTest
{
    [TestClass]
    public class UnitTests_IWindowsDirectory
    {
        private IWindowsDirectory windowsDirectoryImpl = null;
        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [TestInitialize]
        public void InitializeTest()
        {
            windowsDirectoryImpl = new WindowsDirectoryImpl.WindowsDirectoryImpl();

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [TestMethod]
        public void MsTest_TestMethod_WindowsDirectory_CreateDirectory()
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

        [TestMethod]
        public void MsTest_TestMethod_WindowsDirectory_DeleteDirectory()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Assert.IsTrue(windowsDirectoryImpl.DeleteDirectory(directory));
            Assert.IsFalse(Directory.Exists(directory));
        }        
    }
}
