namespace WebAppComics.Utils
{
    public static class FileUtils
    {
        /// <summary>
        /// Determines whether the given path refers to a valid and existing directory.
        /// </summary>
        /// 
        /// <param name="path">Directory path</param>
        /// <returns>True if the directory exists, False othersise</returns>

        public static bool IsFolderValid(string? path)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(path) && Directory.Exists(path);

            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Determines whether the given path refers to a valid and existing file.
        /// </summary>
        /// 
        /// <param name="path">File path</param>
        /// <returns>True if the file exists, False othersise</returns>

        public static bool IsFileValid(string? path)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(path) && File.Exists(path);

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static List<string> GetDirectoriesContainingFile(string? path, string fileName)
        {

            List<string> foundDirectories = new List<string>();
            
            List<string> nextDirToCheck = new List<string>();
            nextDirToCheck.Add(path);

            do
            {
                List<string> dirToCheck = new List<string>(nextDirToCheck);
                nextDirToCheck.Clear();

                foreach(string dir in dirToCheck)
                {

                    if (IsFileValid(Path.Combine(dir, fileName)))
                    {
                        foundDirectories.Add(dir);

                    }
                    else
                    {
                        nextDirToCheck.AddRange(Directory.EnumerateDirectories(dir, "*", SearchOption.TopDirectoryOnly));
                    }

                }

            } while (nextDirToCheck.Count > 0);

            return foundDirectories;
        }

    }
}
