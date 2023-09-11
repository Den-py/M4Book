namespace M4Book.Model
{
    public class Tag
    {
        public string TagName { get; set; }
        public string TagValue { get; set; }

        public Tag() { }

        public Tag(string tagName, string tagValue)
        {
            this.TagName = tagName;
            this.TagValue = tagValue;
        }
    }
}