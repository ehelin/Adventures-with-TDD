using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System.IO;

namespace Tests_MsTest
{
    [TestClass]
    public class UnitTests_IWindowsFile
    {
        private IWindowsFile windowsFileImpl = null;
        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [TestInitialize]
        public void InitializeTest()
        {
            windowsFileImpl = new WindowsFileImpl.WindowsFileImpl();

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [TestMethod]
        public void MsTest_TestMethod_WindowsFile_CreateFile()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Assert.IsTrue(windowsFileImpl.CreateFile(filePath));
            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        public void MsTest_TestMethod_WindowsFile_DeleteFile()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            Assert.IsTrue(windowsFileImpl.DeleteFile(filePath));
            Assert.IsFalse(File.Exists(filePath));
        }

        [TestMethod]
        public void MsTest_TestMethod_WindowsFile_WriteReadToFromFile()
        {
            WriteReadFileInit();

            windowsFileImpl.WriteToFile(filePath, fileContents);
            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue(new FileInfo(filePath).Length > 0);

            string result = windowsFileImpl.ReadFromFile(filePath);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual(result.Replace("\r\n",""), this.fileContents);
        }

        private void WriteReadFileInit()
        {
            if (!Directory.Exists(directory))
                Directory.Delete(directory);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
