namespace BlazorApp3
{
    public class Apple : Block
    {
        public Apple()
        {
            Source source = new Source();
            string css = "background-color: red; border-radius: 50%;";
            source.up = css;
            source.left = css;
            source.right = css;
            source.down = css;
            source.sourceType = SourceType.css;
            ChangeFullSource(source);
        }
    }
}
