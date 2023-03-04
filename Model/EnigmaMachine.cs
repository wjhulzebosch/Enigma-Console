using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    internal class EnigmaMachine
    {
        private Rotor _rotorI;
        private Rotor _rotorII;
        private Rotor _rotorIII;

        public EnigmaMachine()
        {
            _rotorI = new Rotor(RotorType.RotorI, 0);
            _rotorII = new Rotor(RotorType.RotorII, 0);
            _rotorIII = new Rotor(RotorType.RotorIII, 0);
        }

        public string Encrypt(string input)
        {
            string output = "";

            foreach (char c in input)
            {
                
            }

            return output.ToString();
        }
    }
}
