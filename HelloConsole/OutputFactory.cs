using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConsole
{
    class OutputFactory
    {
        static public IHelloWorld CreateObj(string outputType)
        {
            IHelloWorld objSelector = null;
            try
            {
                switch (outputType)
                {
                    case "console":
                        objSelector = new ConsoleOutput();
                        break;
                    case "database":
                        objSelector = new DatabaseOutput();
                        break;
                    default:
                        objSelector = new ConsoleOutput();
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception creating output class", e);
            }
           
            return objSelector;

        }
    }
}
