namespace BlazorApp3
{
    public class Matrix<T>
    {
        public T[,] Map { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Size { get; private set; }
        public Matrix(int height, int width)
        {
            Map = new T[height, width];
            Height = height;
            Width = width;
            Size = width * height;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    yield return Map[row, col];
                }
            }
        }
        private bool IsColExist(int col)
        {
            return col >= 0 && col < Width;
        }

        public List<T> GetRow(int row)
        {
            if (!IsRowExist(row))
            {
                throw new ArgumentOutOfRangeException($"Ряда с индексом {row} не существет");
            }

            var result = new List<T>();

            for (int col = 0; col < Width; col++)
            {
                result.Add(Map[row, col]);
            }
            return result;
        }

        public List<T> GetCol(int col)
        {
            if (!IsColExist(col))
            {
                throw new ArgumentOutOfRangeException($"Столбца с индексом {col} не существует");
            }

            var result = new List<T>();

            for (int row = 0; row < Height; row++)
            {
                result.Add(Map[row, col]);
            }
            return result;
        }

        public void ClearRow(int row)
        {
            if (!IsRowExist(row))
            {
                throw new ArgumentOutOfRangeException($"Ряда с индексом {row} не существет");
            }

            for (int col = 0; col < Width; col++)
            {
                Clear(new Point(col, row));
            }
        }

        public void ClearCol(int col)
        {
            if (!IsColExist(col))
            {
                throw new ArgumentOutOfRangeException($"Столбца с индексом {col} не существет");
            }

            for (int row = 0; row < Height; row++)
            {
                Clear(new Point(col, row));
            }
        }

        public void MoveRow(int row, Direction direction, List<Point> ignore)
        {
            if (!IsRowExist(row))
            {
                throw new ArgumentOutOfRangeException($"Ряда с индексом {row} не существует");
            }

            if (direction == Direction.left || direction == Direction.right)
            {
                throw new ArgumentOutOfRangeException($"Невозможно переместить ряд {row} по вертикали");
            }

            for (int col = 0; col < Width; col++)
            {
                Point currPoint = new Point(col, row);
                if (!ignore.Any(point => point.X == currPoint.X && point.Y == currPoint.Y))
                {
                    Move(currPoint, direction);
                }
            }
        }

        public void MoveCol(int col, Direction direction)
        {
            if (!IsColExist(col))
            {
                throw new ArgumentOutOfRangeException($"Столбца с индексом {col} не существует");
            }

            if (direction == Direction.up || direction == Direction.down)
            {
                throw new ArgumentOutOfRangeException($"Невозможно переместить столбец {col} по вертикали");
            }

            for (int row = 0; row < Height; row++)
            {
                Move(new Point(col, row), direction);
            }
        }

        private bool IsRowExist(int row)
        {
            return row >= 0 && row < Height;
        }
        public bool IsCellExist(Point point)
        {
            return IsColExist(point.X) && IsRowExist(point.Y);
        }
        public bool IsCellEmpty(Point point)
        {
            return IsCellExist(point) && EqualityComparer<T>.Default.Equals(Get(point), default);
        }

        public void Push(Point point, T data)
        {
            if (IsCellExist(point))
            {
                Map[point.Y, point.X] = data;
            }
        }

        public void Fill(T data)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Push(new Point(col, row), data);
                }
            }
        }

        public T Get(Point point)
        {
            if (!IsCellExist(point))
            {
                throw new ArgumentOutOfRangeException($"Слота на точке {point.ToString} не существует");
            }
            return Map[point.Y, point.X];
        }

        public void Clear(Point point)
        {
            if (IsCellExist(point))
            {
                Map[point.Y, point.X] = default;
            }
        }

        public bool Move(Point point, Direction direction)
        {
            Point nextPoint = point.GetDir(direction);

            if (IsCellExist(nextPoint))
            {

                if (IsCellEmpty(nextPoint))
                {
                    T data = Get(point);
                    Push(nextPoint, data);
                    Clear(point);
                    return true;
                }
            }
            return false;
        }
        public bool CanMove(Point point, Direction direction)
        {
            Point nextPoint = point.GetDir(direction);
            return IsCellEmpty(nextPoint);
        }

        public Point? RandPoint(Func<Point, bool>? condition = null)
        {
            for(int i = 0; i < Size; i++)
            {
                Random random = new();
                Point point = new(random.Next(0, Width), random.Next(0, Height));
                if (condition != null)
                {
                    if (condition(point))
                    {
                        return point;
                    }
                    continue;
                }
                else
                {
                    return point;
                }
            }
            return null;
        }
    }
}
