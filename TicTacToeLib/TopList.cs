namespace TicTacToeLib;

public class TopList
{
    // Словарь с никнемами и победами всех игроков.
    private static Dictionary<string, int> _top = new Dictionary<string, int>();

    /// <summary>
    /// Метод доббавляет в слоаврь нового игрока.
    /// </summary>
    /// <param name="name"> Никнейм нового игрока. </param>
    public static void AddName(string name)
    {
        if (!_top.ContainsKey(name))
        {
            _top.Add(name, 0);
        }
    }

    /// <summary>
    /// Метод добавляет очко в случае выигрыша.
    /// </summary>
    /// <param name="name"> Имя игрока, которому нужно добавить очко. </param>
    public static void AddPoint(string name)
    {
        _top[name] += 1;
    }

    /// <summary>
    /// Метод выводит топ-лист в отсортированном порядке.
    /// </summary>
    public static void Print()
    {
        if (_top.Count == 0)
        {
            ConnectWithUser.WriteInCenter("Пока что не было ни одной игры :(");
        }
        else
        {
            string name = "Никнейм";
            string win = "Победы";
            ConnectWithUser.WriteInCenter(
                $"{name.PadLeft(Console.WindowWidth / 2 - 2)}\t{win.PadRight(Console.WindowWidth / 2 - 2)}");
            foreach (var pair in _top.OrderByDescending(pair => pair.Value))
            {
                ConnectWithUser.WriteInCenter(
                    $"{pair.Key.PadLeft(Console.WindowWidth / 2 - 2)}\t{pair.Value.ToString().PadRight(Console.WindowWidth / 2 - 2)}");
            }
        }
    }
}