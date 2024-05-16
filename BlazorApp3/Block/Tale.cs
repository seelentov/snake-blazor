namespace BlazorApp3
{
    public class Tale : Block
    {
        public Tale()
        {
            Source source = new Source();
            string css = "background-color: black;";
            source.up = css;
            source.left = css;
            source.right = css;
            source.down = css;
            source.sourceType = SourceType.css;
            ChangeFullSource(source);
        }
    }
}
