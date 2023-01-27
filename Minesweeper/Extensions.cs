namespace Minesweeper
{
    public static class ConsoleExtension
    {
        public static int[] ReadCell(string input)
        {
            var line = input.Split(' ');
            var x = int.Parse(line[0]);
            var y = int.Parse(line[1]);

            return new int[] { x, y };
        } // просто по приколу сделал
    }
}