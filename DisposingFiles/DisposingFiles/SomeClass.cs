using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposingFiles
{
    class SomeClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposing someclass");
        }

        public void Say(string input)
        {
            Console.WriteLine(input);
        }
    }
}
