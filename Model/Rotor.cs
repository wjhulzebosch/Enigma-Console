using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    // create a static enum for the rotor types
    public enum RotorType
    {
        RotorI,
        RotorII,
        RotorIII,
        RotorIV,
        RotorV,
        RotorVI,
        RotorVII,
        RotorVIII
    }

    internal class Rotor
    {
        // Rotor wiring for each rotor:
        // RotorI:      EKMFLGDQVZNTOWYHXUSPAIBRCJ
        // RotorII:     AJDKSIRUXBLHWTMCQGZNPYFVOE
        // RotorIII:    BDFHJLCPRTXVZNYEIWGAKMUSQO
        // RotorIV:     ESOVPZJAYQUIRHXLNFTGKDCMWB
        // RotorV:      VZBRGITYUPSDNHLXAWMJQOFECK
        // RotorVI:     JPGVOUMFYQBENHZRDKASXLICTW
        // RotorVII:    NZJHGRCXMYSWBOUFAIVLPEKQDT
        // RotorVIII:   FKQHTLXOCBJSPDZRAMEWNIUYGV

        private int _position;
        private RotorType _rotorType;
        private string _wiring;

        // create a constructor for the rotor class
        public Rotor(RotorType rotorType, int position)
        {
            // Set internal values to the values passed in as parameters
            _rotorType = rotorType;
            _position = position;

            // Determine _wiring from rotorType, based on rotorType
            setWiring();
        }

        public void incrementPosition()
        {
            _position++;
        }

        public int getPosition()
        {
            return _position;
        }

        public void SetPosition (int newPosition)
        {
            _position = newPosition % 26;
        }

        private void setWiring()
        {
            switch (_rotorType)
            {
                case RotorType.RotorI:
                    _wiring = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
                    break;
                case RotorType.RotorII:
                    _wiring = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
                    break;
                case RotorType.RotorIII:
                    _wiring = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
                    break;
                case RotorType.RotorIV:
                    _wiring = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
                    break;
                case RotorType.RotorV:
                    _wiring = "VZBRGITYUPSDNHLXAWMJQOFECK";
                    break;
                case RotorType.RotorVI:
                    _wiring = "JPGVOUMFYQBENHZRDKASXLICTW";
                    break;
                case RotorType.RotorVII:
                    _wiring = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
                    break;
                case RotorType.RotorVIII:
                    _wiring = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
                    break;
            }
        }

        public char GetCharForward(char input, bool increaseRotor)
        {
            // Get the character at the position of the input character
            char output = _wiring[(input - 'A' + _position) % 26];

            // If increaseRotor is true, increase the position of the rotor
            if(increaseRotor)
            {
                incrementPosition();
            }

            // Return the character
            return output;            
        }

        public char GetCharBackward(char input)
        {
            // Get the position of the input character
            int position = _wiring.IndexOf(input);

            // Get the character at the position of the input character
            char output = (char)('A' + (position - _position + 26) % 26);

            // Return the character
            return output;
        }
    }
}
