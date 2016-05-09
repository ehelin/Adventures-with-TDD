using Moq;
using NUnit.Framework;
using Shared.interfaces;

namespace Tests_Nunit
{
    [TestFixture]
    public class UnitTests_IFile
    {
        private IFile fileImpl = null;

        private Mock<IWindowsDirectory> windowsDirectory = null;
        private Mock<IWindowsFile> windowsFile = null;

        private string directory = string.Empty;
        private string filePath = string.Empty;
        private string fileContents = string.Empty;

        [OneTimeSetUp]
        public void InitializeTest()
        {
            windowsDirectory = new Mock<IWindowsDirectory>();
            windowsFile = new Mock<IWindowsFile>();

            fileImpl = new FileImpl.FileImpl(windowsDirectory.Object, windowsFile.Object);

            directory = "c:\\temp\\test\\";
            filePath = directory + "testfile.txt";
            fileContents = "The lazy brown dog jumped over the moon";
        }

        [Test]
        public void Nunit_TestMethod_CreateDirectory()
        {
            windowsDirectory.Setup(x => x.CreateDirectory(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.CreateDirectory(directory));
        }

        [Test]
        public void Nunit_TestMethod_DeleteDirectory()
        {
            windowsDirectory.Setup(x => x.DeleteDirectory(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.DeleteDirectory(directory));
        }

        [Test]
        public void Nunit_TestMethod_CreateFile()
        {
            windowsFile.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.CreateFile(filePath));
        }

        [Test]
        public void Nunit_TestMethod_DeleteFile()
        {
            windowsFile.Setup(x => x.DeleteFile(It.IsAny<string>())).Returns(true);

            Assert.IsTrue(fileImpl.DeleteFile(filePath));
        }

        [Test]
        public void Nunit_TestMethod_WriteReadToFromFile()
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