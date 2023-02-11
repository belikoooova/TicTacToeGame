using TicTacToeLib;

class Program
{
    public static void Main(string[] args)
    {
        // Вызов приветствия.
        ConnectWithUser.Hello();
        
        // Вызов меню.
        do
        {
            ConnectWithUser.Menu();
        } while (ConnectWithUser.ExitFromProgram == false); 
        
        // Вызов прощания.
        ConnectWithUser.GoodBye();
    }
}