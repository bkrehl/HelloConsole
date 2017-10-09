using System;


namespace HelloConsole
{
    public class ConsoleOutput : IHelloWorld
    {
        public void SendMessage(string message)
        {
            try
            {
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                throw new Exception("Exception creating console output", e);
            }
        }
    }
}
