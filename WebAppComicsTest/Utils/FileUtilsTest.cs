using WebAppComics.Utils;

namespace WebAppComicsTest.Utils
{
    internal class FileUtilsTest
    {

        private string comicsFolders;

        [SetUp]
        public void Setup()
        {
            string runningDir = TestContext.CurrentContext.TestDirectory;
            string projectDir = Directory.GetParent(runningDir).Parent.Parent.FullName;

            comicsFolders = Path.Combine(projectDir, "Resources\\ComicsFolders");

        }

        [Test]
        public void IsFolderValid_NullOrEmptyTest()
        {
            FileUtils.IsFolderValid("");

            Assert.IsFalse(FileUtils.IsFolderValid(null));
            Assert.IsFalse(FileUtils.IsFolderValid(""));
            Assert.IsFalse(FileUtils.IsFolderValid("  "));
        }

        [Test]
        public void IsFolderValid_InvalidTest()
        {
            string path = "/wrong/path";
            Assert.IsFalse(FileUtils.IsFolderValid(path));
        }

        [Test]
        public void IsFolderValid_ValidTest()
        {
            string path = comicsFolders;
            Assert.IsTrue(FileUtils.IsFolderValid(path));
        }

        [Test]
        public void IsFileValid_InValidTest()
        {
            string path = comicsFolders;
            Assert.IsFalse(FileUtils.IsFileValid(path));
        }

        [Test]
        public void IsFileValid_ValidTest()
        {
            string path = Path.Combine(comicsFolders, "ComicsFolder1\\.comics");
            Assert.IsTrue(FileUtils.IsFileValid(path));
        }

        [Test]
        public void GetDirectoriesContainingFileTest()
        {

            List<string> directoriesList = FileUtils.GetDirectoriesContainingFile(comicsFolders, ".comics");

            Assert.IsNotNull(directoriesList);
            Assert.That(directoriesList.Count, Is.EqualTo(2));

            string dir1 = Path.Combine(comicsFolders, "ComicsFolder1");
            Assert.That(directoriesList[0], Is.EqualTo(dir1));

            string dir2 = Path.Combine(comicsFolders, "ComicsFolder2");
            Assert.That(directoriesList[1], Is.EqualTo(dir2));

        }

    }
}
