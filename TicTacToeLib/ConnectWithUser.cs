using System.Text;

namespace TicTacToeLib;

public class ConnectWithUser
{
    /// <summary>
    /// Булевое поле показывает, хочет ли пользователь выйти из программы.
    /// </summary>
    private static bool _exitFromProgram = false;
    
    /// <summary>
    /// Свойство дает доступ к изменению и получению значения поля _exitFromProgram.
    /// </summary>
    public static bool ExitFromProgram
    {
        private set => _exitFromProgram = value;
        get => _exitFromProgram;
    }
    
    /// <summary>
    /// Метод печатает строку посередине консоли.
    /// </summary>
    /// <param name="line"> Строка, которую нужно вывести. </param>
    public static void WriteInCenter(string line)
    {
        int width = Console.WindowWidth;
        if (line.Length < width)
        {
            line = line.PadLeft((width - line.Length) / 2 + line.Length, ' ');
        }
        Console.WriteLine(line);
    }

    /// <summary>
    /// Метод устанавливает курсор посередине консоли.
    /// </summary>
    public static void SetCursorInCenter()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2, Console.GetCursorPosition().Top); 
    }
    
    /// <summary>
    /// Метод выводит в консоль приветствие пользователя.
    /// </summary>
    public static void Hello()
    {
        Console.Clear();
        WriteInCenter("Здравствуйте! Это крестики-нолики!");
    }

    /// <summary>
    /// Метод выводит в консоль главное меню и позволяет пользователю выбрать команду.
    /// </summary>
    public static void Menu()
    {
        // Cтрока - разделитель.
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 56; i++)
        {
            sb.Append('_');
        }
        WriteInCenter(sb.ToString());
        
        // Вывод команд меню.
        WriteInCenter("Выберите одну из команд, нажмите соответствующую клавишу");
        WriteInCenter("1 - Начать новую игру");
        WriteInCenter("2 - Посмотреть статистику");
        WriteInCenter("3 - Выйти из программы");
        
        // Строка - разделитель.
        WriteInCenter(sb.ToString());

        // Выбор команды.
        SetCursorInCenter();
        Choice(Console.ReadKey().Key); 
    }
    
    /// <summary>
    /// Метод осуществляет выбор команды главного меню.
    /// </summary>
    /// <param name="choiceKey"> Клавиша, которую нажал пользователь. </param>
    private static void Choice(ConsoleKey choiceKey)
    {
        switch (choiceKey)
        {
            // Команда 1 - начать новую игру.
            case ConsoleKey.D1:
                Console.Clear();
                
                // Игра.
                Game.NewGame();
                
                // Выход в главное меню.
                WriteInCenter("Нажмите любую клавишу для продолжения");
                SetCursorInCenter();
                Console.ReadKey();
                Console.Clear();
                break;
            
            // Команда 2 - просмотр статистики.
            case ConsoleKey.D2:
                Console.Clear();
                TopList.Print();

                // Выход в главное меню.
                WriteInCenter("Нажмите любую клавишу для продолжения");
                SetCursorInCenter();
                Console.ReadKey();
                Console.Clear();
                break;
            
            // Команда 3 - выход из программы.
            case ConsoleKey.D3:
                Console.Clear();
                ExitFromProgram = true;
                break;
            
            // Обработка неверно выбранной команды.
            default:
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                WriteInCenter("Выбрана неверная комманда");
                Console.ResetColor();
                break;
        }
    }
    
    /// <summary>
    /// Метод выводит в консоль прощание с пользователем.
    /// </summary>
    public static void GoodBye()
    {
        Console.WriteLine();
        WriteInCenter("Спасибо за работу! До свидания!");
    }
}