using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System.IO;
using Moq;

namespace Tests_MsTest
{
    [TestClass]
    public class UnitTests_IFile
    {
        private IFile fileImpl = null;

        private Mock<IWindowsDirectory> windowsDirectory = null;
        private Mock<IWindowsFile> windowsFile = null;

        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [TestInitialize]
        public void InitializeTest()
        {
            windowsDirectory = new Mock<IWindowsDirectory>();
            windowsFile = new Mock<IWindowsFile>();

            fileImpl = new FileImpl.FileImpl(windowsDirectory.Object, windowsFile.Object);

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [TestMethod]
        public void MsTest_TestMethod_CreateDirectory()
        {
            windowsDirectory.Setup(x => x.CreateDirectory(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.CreateDirectory(directory));
        }

        [TestMethod]
        public void MsTest_TestMethod_DeleteDirectory()
        {
            windowsDirectory.Setup(x => x.DeleteDirectory(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.DeleteDirectory(directory));
        }

        [TestMethod]
        public void MsTest_TestMethod_CreateFile()
        {
            windowsFile.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.CreateFile(filePath));
        }

        [TestMethod]
        public void MsTest_TestMethod_DeleteFile()
        {
            windowsFile.Setup(x => x.DeleteFile(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.DeleteFile(filePath));
        }

        [TestMethod]
        public void MsTest_TestMethod_WriteReadToFromFile()
        {
            windowsFile.Setup(x => x.ReadFromFile(It.IsAny<string>())).Returns("The lazy brown dog jumped over the moon");
            windowsFile.Setup(x => x.WriteToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.WriteToFile(filePath, fileContents));

            string result = fileImpl.ReadFromFile(filePath);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual(result.Replace("\r\n", ""), this.fileContents);
        }
    }
}
