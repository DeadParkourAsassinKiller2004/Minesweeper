namespace Minesweeper
{
    public class GameLogic
    {
        // пока обладаю только поверхностными знаниями о модификаторах доступа, поэтому скорее всего сделал не по канонам

        private static int[][] coords = GenerateCoordsOfBombs();
        private static int[][] GenerateCoordsOfBombs()
        {
            var coords = new List<int[]>();
            var bombs = new int[10][];
            var counter = 0;
            var randomNums = new int[10];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    coords.Add(new[] { i, j });
                }
            }

            while (counter < 10)
            {
                var rnd = new Random();
                var n = rnd.Next(0, 64);

                if (!randomNums.Contains(n))
                {
                    randomNums[counter] = n;
                    bombs[counter] = coords[n];
                    counter++;
                }
            }

            return bombs;
        }
        public static void SetBombs(Cell[,] field)
        {
            for (int i = 0; i < 10; i++)
                field[coords[i][0], coords[i][1]].IsBomb = true;
        }
        public static void SetNumOfMinesInCells(Cell[,] field)
        {
            var height = field.GetLength(0);
            var width = field.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var mineCounter = 0;
                    var startX = x - 1;
                    var startY = y - 1;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            try
                            {
                                if (field[startY + i, startX + j].IsBomb)
                                    mineCounter++;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    field[y, x].NumOfMinesInVicinity = mineCounter;
                }
            }
        }
        public static bool IsWin(Cell[,] field)
        {
            var numOfPeacefulOpenCells = field
                  .Cast<Cell>()
                  .Where(cell => !cell.IsBomb && cell.State)
                  .ToArray()
                  .Count();
            var numOfMines = field.Cast<Cell>().Where(cell => cell.IsBomb).Count();

            return numOfPeacefulOpenCells == 64 - numOfMines;
        }
    }
}
