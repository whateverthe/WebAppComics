using WebAppComics.Controllers;
using WebAppComics.Domain;
using WebAppComics.Utils;

namespace WebAppComicsTest.Controllers
{
    internal class ComicControllerTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetComicsTest()
        {
            string runningDir = TestContext.CurrentContext.TestDirectory;
            string projectDir = Directory.GetParent(runningDir).Parent.Parent.FullName;

            string comicsFolders = Path.Combine(projectDir, "Resources\\ComicsFolders");
            string comicsFile = ".comics";

            List<string> comicsDirList = new List<string>();
            comicsDirList.Add("comicsDir1");
            comicsDirList.Add("comicsDir2");

            string[] comicsDir1 = new string[] { "comics1", "comics2" };
            string[] comicsDir2 = new string[] { "comics3" };


            /*Telerik.JustMock.Mock.SetupStatic(typeof(FileUtils), StaticConstructor.Mocked);

            Telerik.JustMock.Mock.Arrange(() => FileUtils.GetDirectoriesContainingFile(comicsFolders, comicsFile)).Returns(comicsDirList);
            Telerik.JustMock.Mock.Arrange(() => Directory.GetDirectories("comicsDir1")).Returns(comicsDir1);
            Telerik.JustMock.Mock.Arrange(() => Directory.GetDirectories("comicsDir2")).Returns(comicsDir2);

            ComicsController controller = new ComicsController();
            List<ComicsFolder> comics = controller.GetComics("comicPath");

            Assert.IsNotNull(comics);*/

        }

    }
}
