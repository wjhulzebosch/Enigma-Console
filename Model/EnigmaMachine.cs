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
        private Deflector _deflector;

        public EnigmaMachine()
        {
            _rotorI = new Rotor(RotorType.RotorI, 0);
            _rotorII = new Rotor(RotorType.RotorII, 0);
            _rotorIII = new Rotor(RotorType.RotorIII, 0);
            _deflector = new Deflector();
        }

        public string Encrypt(string input)
        {
            string output = "";

            foreach (char c in input)
            {
                // Start with incrementing first rotor
                // If the result is true, increment the second rotor
                // If the result is true, increment the third rotor
                if (_rotorI.IncrementPosition())
                {
                    if (_rotorII.IncrementPosition())
                    {
                        _rotorIII.IncrementPosition();
                    }
                }

                char result;

                // Encrypt the character
                result = _rotorI.GetCharForward(c);
                result = _rotorII.GetCharForward(result);
                result = _rotorIII.GetCharForward(result);

                result = _deflector.GetChar(result);

                result = _rotorIII.GetCharBackward(result);
                result = _rotorII.GetCharBackward(result);
                result = _rotorI.GetCharBackward(result);

                output += result;

            }

            return output;
        }
    }
}
