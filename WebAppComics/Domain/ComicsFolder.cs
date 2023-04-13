namespace WebAppComics.Domain
{
    public class ComicsFolder
    {
        public string? FolderName { get; set; }

        public List<Comic> Comics { get; set; } = new List<Comic>();

    }
}