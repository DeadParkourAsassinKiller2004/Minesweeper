namespace Minesweeper
{
    public class Cell
    {
        public string? ValueOnScreen;
        public bool State;  // при генерации поля у всех ячеек устанавливается статус closed (false)
        public bool IsBomb; // наличие бомбы генерируется рандомно
        public int NumOfMinesInVicinity;
        public bool Flag;
    }
}