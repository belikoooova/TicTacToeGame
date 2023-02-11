namespace TicTacToeLib;

public class PlayingField
{
    // Символьный массив для отображения поля.
    private char[] _playingField; 
    
    // Список всех возможных позиций.
    private static readonly string[] _positions = new string[] { "1a", "1b", "1c", "2a", "2b", "2c", "3a", "3b", "3c" };
    
    // Булевый массив, значения которого отвечают, выигрышная ли это позиция или нет.
    private bool[] _isWinPosition;

    // Массив с возможными выигрышными комбинациями.
    private string[,] _winPositions =
    {
        { "1a", "2a", "3a" }, { "1b", "2b", "3b" }, { "1c", "2c", "3c" },
        { "1a", "1b", "1c" }, { "2a", "2b", "2c" }, { "3a", "3b", "3c" }, 
        { "1a", "2b", "3c" }, { "1c", "2b", "3a" }
    };

    /// <summary>
    /// Конструктор без параметров.
    /// </summary>
    public PlayingField()
    {
        _playingField = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
        _isWinPosition = new bool[] { false, false, false, false, false, false, false, false, false };
    }

    /// <summary>
    /// Индексатор поля по строковым индексам (например, '1a').
    /// </summary>
    /// <param name="index"> Строковый индекс. </param>
    private char this[string index]
    {
        get => _playingField[GetPosition(index)];
        set => _playingField[GetPosition(index)] = value;
    }
    
    /// <summary>
    /// Метод возвращает значение по строковому индексу и проверяет его корректность.
    /// </summary>
    /// <param name="position"> Строка-позиция. </param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"> Выбрасывается при некорректом индексе. </exception>
    private int GetPosition(string position)
    {
        if (_positions.Contains(position))
        {
            return Array.IndexOf(_positions, position);
        }
        throw new IndexOutOfRangeException("Индекс введен некорректно!");
    }

    /// <summary>
    /// Метод делает ход крестиками.
    /// </summary>
    /// <param name="position"> Позиция, в которую нужно сделать ход. </param>
    /// <exception cref="ArgumentException"> Выбрасывается, если позиция уже занята. </exception>
    public void MakeAStepCross(string position)
    {
        if (!IsPositionEmpty(position))
        {
            throw new ArgumentException("Данная клетка уже занята!");
        }
        else
        {
            this[position] = 'x';
        }
    }
    
    /// <summary>
    /// Метод делает ход ноликами.
    /// </summary>
    /// <param name="position"> Позиция, в которую нужно сделать ход. </param>
    /// <exception cref="ArgumentException"> Выбрасывается, если позиция уже занята. </exception>
    public void MakeAStepZero(string position)
    {
        if (!IsPositionEmpty(position))
        {
            throw new ArgumentException("Данная клетка уже занята!");
        }
        else
        {
            this[position] = 'o';
        }
    }

    /// <summary>
    /// Метод проверяет, занята ли данная позиция.
    /// </summary>
    /// <param name="position"> Позция, которую нужно проверить. </param>
    /// <returns> Возвращает true, если клетка пуста, иначе false. </returns>
    private bool IsPositionEmpty(string position)
    {
        return this[position] == '.';
    }

    /// <summary>
    /// Метод проверяет, есть ли выигрышная ситуация на поле (и в случае нахождения такого помечает позиции выгрышными).
    /// </summary>
    /// <returns> Возвращает true, если есть выигрышная ситуация на поле, иначе false. </returns>
    public bool IsWin()
    {
        for (int i = 0; i < 8; i++)
        {
            if (this[_winPositions[i, 0]] == this[_winPositions[i, 1]] 
                && this[_winPositions[i, 0]] == this[_winPositions[i, 2]] 
                && (this[_winPositions[i, 0]] == 'x' || this[_winPositions[i, 0]] == 'o'))
            {
                _isWinPosition[GetPosition(_winPositions[i, 0])] = true;
                _isWinPosition[GetPosition(_winPositions[i, 1])] = true;
                _isWinPosition[GetPosition(_winPositions[i, 2])] = true;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Метод проверяет, все ли клетки поля заняты.
    /// </summary>
    /// <returns> Возвращает true, если все клетки заняты, иначе false. </returns>
    public bool IsEnd()
    {
        foreach (char c in _playingField)
        {
            if (c == '.')
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Метод печатает в консоль текущеее игровое поле. 
    /// </summary>
    public void Print()
    {
        IsWin();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("  a b c");
        Console.ResetColor();
        for (int i = 0; i < 3; i++)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{i + 1} ");
            Console.ResetColor();
            for (int j = 0; j < 3; j++)
            {
                int position = 3 * i + j;
                if (_isWinPosition[position])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_playingField[position]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{_playingField[position]} ");
                }
            }
            Console.WriteLine();
        }
    }
}