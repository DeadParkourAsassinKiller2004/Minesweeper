namespace Minesweeper
{
    class MainUnit
    {
        public static void Main()
        {
            Console.WriteLine("* Чтобы пометить ячейку флагом нужно дописать через пробел f");
            Console.WriteLine("* Чтобы удалить флаг нужно дописать букву d через пробел");
            Console.WriteLine();

            while (true)
            {
                Creator.ConstructField();
                Console.Write(">> ");
                var inp = Console.ReadLine();
                int x = ConsoleExtension.ReadCell(inp)[0];
                int y = ConsoleExtension.ReadCell(inp)[1];
                string flag;

                Console.Clear();

                try // смотрим наличие дополнительных параметров
                {
                    flag = inp.Split(' ')[2];

                    if (flag == "f")
                        Field.SetFlag(y - 1, x - 1);
                    else if (flag == "d")
                        Field.DeleteFlag(y - 1, x - 1);
                    else // если не удалось определить запрос, то ничего не делаем и отрисовываем поле заново
                        continue;
                }
                catch // если дополнительный параметр отсуствует, то реализуем стандартную логику игры
                {

                    if (Field.AllCells[y - 1, x - 1].IsBomb && !Field.AllCells[y - 1, x - 1].Flag) // тоже можно что-то с этим сделать
                    /*
                    * если запрашиваемая ячейка является непомеченной флагом бомбой, то завершаем игру
                    */
                    {
                        Console.WriteLine("You Loose");
                        Console.ReadKey();
                        break;
                    }

                    if (!Field.AllCells[y - 1, x - 1].Flag) // если запрашиваемая ячейка не является флагом, то открываем её
                        Field.OpenCell(y - 1, x - 1);
                }

                if (GameLogic.IsWin(Field.AllCells))
                {
                    Console.WriteLine("You Win!");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}