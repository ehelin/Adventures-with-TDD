using System.IO;
using NUnit.Framework;
using Shared.interfaces;

namespace Tests_Nunit
{
    [TestFixture]
    public class UnitTests
    {
        private IFile fileImpl = null;
        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [OneTimeSetUp]
        public void Setup()
        {
            fileImpl = new FileImpl.FileImpl();

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [Test]
        public void TestMethod_NUnit_CreateDirectory()
        {
            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    File.Delete(file);
                }

                Directory.Delete(directory);
            }

            fileImpl.CreateDirectory(directory);

            Assert.IsTrue(Directory.Exists(directory));
        }

        [Test]
        public void TestMethod_NUnit_DeleteDirectory()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            fileImpl.DeleteDirectory(directory);

            Assert.IsFalse(Directory.Exists(directory));
        }

        [Test]
        public void TestMethod_NUnit_CreateFile()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            fileImpl.CreateFile(filePath);

            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void TestMethod_NUnit_DeleteFile()
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            fileImpl.DeleteFile(filePath);

            Assert.IsFalse(File.Exists(filePath));
        }

        [Test]
        public void TestMethod_NUnit_WriteReadToFromFile()
        {
            WriteReadFileInit();

            fileImpl.WriteToFile(filePath, fileContents);
            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue(new FileInfo(filePath).Length > 0);

            string result = fileImpl.ReadFromFile(filePath);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual(result.Replace("\r\n", ""), this.fileContents);
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