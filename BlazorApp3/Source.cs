namespace BlazorApp3
{
    public struct Source
    {
        public string up;
        public string down;
        public string left;
        public string right;
        public SourceType sourceType;
    }
    public enum SourceType
    {
        url, css
    }
}
