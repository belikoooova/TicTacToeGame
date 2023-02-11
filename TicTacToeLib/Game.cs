namespace TicTacToeLib;

delegate void MakeAStepper(string? position);
public class Game
{
    public static void NewGame()
    {
        // Знакомство с пользователями.
        ConnectWithUser.WriteInCenter("Введите имя игрока, играющего крестиками: ");
        ConnectWithUser.SetCursorInCenter();
        string crossPlayer = Console.ReadLine() ?? string.Empty;
        ConnectWithUser.WriteInCenter("Введите имя игрока, играющего ноликами: ");
        ConnectWithUser.SetCursorInCenter();
        string zeroPlayer = Console.ReadLine() ?? string.Empty;
        
        // Добавление никнеймов в общий список для подсчета рейтинга.
        TopList.AddName(crossPlayer);
        TopList.AddName(zeroPlayer);
        Console.Clear();
        
        // Создание игрового поля.
        PlayingField playingField = new PlayingField();
        
        // Счетчик количества ходов, необходим для корректного ведения игры.
        int counter = 0;
        
        // Делегаты для совершения ходов.
        MakeAStepper crossStepper = playingField.MakeAStepCross;
        MakeAStepper zeroStepper = playingField.MakeAStepZero;
        
        // Вывод правил в консоль.
        ConnectWithUser.WriteInCenter("Команды вводятся в формате <цифра><буква>.");
        ConnectWithUser.WriteInCenter("Например, чтобы сделать ход в правую");
        ConnectWithUser.WriteInCenter("нижнюю клетку, нужно ввести 'c3' без кавычек.");

        // Цикл, пока кто-то не выиграет или не закончатся свободные поля.
        do
        {
            try
            {
                // Ход крестиков.
                if (counter % 2 == 0)
                {
                    Console.WriteLine($"Ход {crossPlayer} (крестики):");
                    playingField.Print();
                    crossStepper(Console.ReadLine());
                    counter++;
                    Console.Clear();
                }
                // Ход ноликов.
                else
                {
                    Console.WriteLine($"Ход {zeroPlayer} (нолики):");
                    playingField.Print();
                    zeroStepper(Console.ReadLine());
                    counter++;
                    Console.Clear();
                }
            }
            // Обработка исключений некорректного ввода команд.
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(900);
                Console.Clear();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(900);
                Console.Clear();
            }
            
        } while (!(playingField.IsWin() || playingField.IsEnd()));

        // Определение выигравшего (или ничьи).
        if (playingField.IsWin() && counter % 2 == 1)
        {
            Console.WriteLine($"Выигрыш {crossPlayer}!");
            playingField.Print();
            TopList.AddPoint(crossPlayer);
        }
        else if (playingField.IsWin() && counter % 2 == 0)
        {
            Console.WriteLine($"Выигрыш {zeroPlayer}!");
            playingField.Print();
            TopList.AddPoint(zeroPlayer);
        }
        else
        {
            Console.WriteLine("Ничья!");
            playingField.Print();
        }
    }
}