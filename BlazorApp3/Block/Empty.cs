namespace BlazorApp3
{
    public class Empty : Block
    {
        public Empty()
        {
            Source source = new Source();
            string css = "background-color: white;";
            source.up = css;
            source.left = css;
            source.right = css;
            source.down = css;
            source.sourceType = SourceType.css;
            ChangeFullSource(source);
        }
    }
}
