namespace BlazorApp3
{
    public class Block
    {
        private Direction _direction = Direction.up;
        private Source _source;
        public Block() { }

        public string GetSource()
        {
            switch (_direction)
            {
                case Direction.down:
                    return _source.down;
                case Direction.left:
                    return _source.left;
                case Direction.right:
                    return _source.right;
                default:
                    return _source.up;
            }
        }

        public void ChangeFullSource(Source source)
        {
            _source = source;
        }

        public void ChangeSource(string url, Direction direction)
        {
            switch (direction)
            {
                case Direction.down:
                    _source.down = url; break;
                case Direction.left:
                    _source.left = url; break;
                case Direction.right:
                    _source.right = url; break;
                case Direction.up:
                    _source.up = url; break;
            }
        }

        public SourceType GetSourceType()
        {
            return _source.sourceType;
        }

        public void ChangeDirection(Direction direction)
        {
            _direction = direction;
        }
    }
}
