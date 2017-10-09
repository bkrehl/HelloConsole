using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConsole
{
    public class DatabaseOutput : IHelloWorld
    {
        public void SendMessage(string message)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw new Exception("Exception creating database output", e);
            }
            
        }
    }
}
