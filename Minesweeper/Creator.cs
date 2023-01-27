using System;

namespace Minesweeper
{
    public static class Creator
    {
        public static Cell[,] Generate()
        {
            var field = new Cell[8, 8];
            Random rnd = new Random();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    field[i, j] = new Cell
                    {
                        NumOfMinesInVicinity = 0,
                        State = false,
                        ValueOnScreen = "*",
                        Flag = false
                    };
                }
            }

            GameLogic.SetBombs(field);
            GameLogic.SetNumOfMinesInCells(field);

            return field;

        }
        public static void ConstructField()
        {
            var height = Field.AllCells.GetLength(0);
            var width = Field.AllCells.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    Console.Write("{0} ", Field.AllCells[i, j].ValueOnScreen);
                Console.WriteLine();
            }
        }
    }
}