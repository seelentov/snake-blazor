namespace BlazorApp3
{
    public class Head : Block
    {
        public Head()
        {
            Source source = new Source();
            string css = "background-color: green;";
            source.up = css;
            source.left = css;
            source.right = css;
            source.down = css;
            source.sourceType = SourceType.css;
            ChangeFullSource(source);
        }
    }
}
