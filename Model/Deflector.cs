using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    internal class Deflector
    {
        private string _wiring;

        public Deflector()
        {
            _wiring = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        }

        public char GetCharForward(char input)
        {
            int index = input - 'A';
            return _wiring[index];
        }
    }
}
