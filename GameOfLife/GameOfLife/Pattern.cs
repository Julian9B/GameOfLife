namespace GameOfLife
{
    public partial class PatternsListPage
    {
        public class Pattern
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Discoverer { get; set; }
            public string ImageId { get; set; }

            public Pattern(string name, string type, string discoverer, string imageId)
            {
                Name = name;
                Type = type;
                Discoverer = discoverer;
                ImageId = imageId;
            }
        }
    }
}