using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System.IO;

namespace Tests_MsTest
{
    [TestClass]
    public class UnitTests
    {
        private IFile fileImpl = null;
        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [TestInitialize]
        public void InitializeTest()
        {
            fileImpl = new FileImpl.FileImpl();

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [TestMethod]
        public void TestMethod_CreateDirectory()
        {
            if (Directory.Exists(directory))
                Directory.Delete(directory);

            fileImpl.CreateDirectory(directory);

            Assert.IsTrue(Directory.Exists(directory));
        }

        [TestMethod]
        public void TestMethod_DeleteDirectory()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            fileImpl.DeleteDirectory(directory);

            Assert.IsFalse(Directory.Exists(directory));
        }

        [TestMethod]
        public void TestMethod_CreateFile()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            fileImpl.CreateFile(filePath);

            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        public void TestMethod_DeleteFile()
        {
            if (!File.Exists(filePath))
                File.Create(filePath);

            fileImpl.DeleteFile(filePath);

            Assert.IsFalse(File.Exists(filePath));
        }

        [TestMethod]
        public void TestMethod_WriteReadToFromFile()
        {
            WriteReadFileInit();

            fileImpl.WriteToFile(filePath, fileContents);
            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue(new FileInfo(filePath).Length > 0);

            string result = fileImpl.ReadFromFile(filePath);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual(result, this.fileContents);
        }

        private void WriteReadFileInit()
        {
            if (!Directory.Exists(directory))
                Directory.Delete(directory);

            if (File.Exists(filePath))
                File.Delete(filePath);

            Directory.CreateDirectory(directory);
            File.Create(filePath);
        }
    }
}
