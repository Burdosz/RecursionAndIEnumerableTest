namespace CollectionTests
{
    public class NewTree
    {
        public string Id { get; set; }

        public IEnumerable<NewTree> Parents { get; set; }
    }
}