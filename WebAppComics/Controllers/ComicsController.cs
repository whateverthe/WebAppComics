using Microsoft.AspNetCore.Mvc;
using WebAppComics.Domain;
using WebAppComics.Utils;

namespace WebAppComics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComicsController : ControllerBase
    {
        const string COMICS_FOLDER_FILE = ".comics";


        [HttpGet("GetComics")]
        public List<ComicsFolder> GetComics(string? path)
        {
            if (FileUtils.IsFolderValid(path))
            {
                List<ComicsFolder> comicFolderList = new List<ComicsFolder>();

                List<string> dirList = FileUtils.GetDirectoriesContainingFile(path, COMICS_FOLDER_FILE);
                foreach(string dir in dirList)
                {
                    ComicsFolder comicFolder = new ComicsFolder();
                    comicFolder.FolderName = dir;

                    foreach (string file in Directory.GetDirectories(dir)){

                        comicFolder.Comics.Add(new Comic()
                        {
                            Name = Path.GetFileName(file),
                            Url = ""
                        });

                    }
                    comicFolderList.Add(comicFolder);

                }
                return comicFolderList;

            }
            else
            {

                return new List<ComicsFolder>();
            }
        }
    }
}