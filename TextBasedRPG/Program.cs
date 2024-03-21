namespace TextBasedRPG
{
    internal class Program
    {
        static GameManager gameManager = new GameManager();
        static void Main(string[] args)
        {
            gameManager.Play();
        }
    }
}
