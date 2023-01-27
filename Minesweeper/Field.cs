namespace Minesweeper
{
    public static class Field
    {
        public static Cell[,] AllCells; // здесь будем хранить все ячейки
        static Field()
        {
            AllCells = Creator.Generate();
        }
        public static void OpenCell(int i, int j)
        {
            var cell = AllCells[i, j];

            if (cell.State == false && cell.Flag == false)
            {
                cell.ValueOnScreen = cell.NumOfMinesInVicinity.ToString();
                cell.State = true;
            }
        } // этот и следующие методы вынесены в класс Field из-за удобства
        public static void SetFlag(int i, int j)
        {
            var cell = AllCells[i, j];

            if (cell.State == false)
            {
                cell.ValueOnScreen = "!";
                cell.Flag = true;
            }
        }
        public static void DeleteFlag(int i, int j)
        {
            var cell = AllCells[i, j];

            if (cell.State == false)
            {
                cell.ValueOnScreen = "*";
                cell.Flag = false;
            }
        }
    }
}