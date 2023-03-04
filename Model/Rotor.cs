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
        // RotorI:      EKMFLGDQVZNTOWYHXUSPAIBRCJ, notch at Q
        // RotorII:     AJDKSIRUXBLHWTMCQGZNPYFVOE, notch at E
        // RotorIII:    BDFHJLCPRTXVZNYEIWGAKMUSQO, notch at V
        // RotorIV:     ESOVPZJAYQUIRHXLNFTGKDCMWB, notch at J
        // RotorV:      VZBRGITYUPSDNHLXAWMJQOFECK, notch at Z
        // RotorVI:     JPGVOUMFYQBENHZRDKASXLICTW
        // RotorVII:    NZJHGRCXMYSWBOUFAIVLPEKQDT
        // RotorVIII:   FKQHTLXOCBJSPDZRAMEWNIUYGV

        private int _position;
        private RotorType _rotorType;
        private string _wiring;
        private int _notch;

        // create a constructor for the rotor class
        public Rotor(RotorType rotorType, int position)
        {
            // Set internal values to the values passed in as parameters
            _rotorType = rotorType;
            _position = position;

            // Determine _wiring from rotorType, based on rotorType
            setWiring();
        }

        /// <summary>
        /// Increments the position of the rotor with one.
        /// </summary>
        public bool IncrementPosition()
        {
            _position++;      
            _position %= 26;

            // If the rotor is at the notch, return true
            if (_position == _notch)
            {
                return true;
            }

            return false;
        }

        public int GetPosition()
        {
            return _position;
        }

        public void SetPosition(int newPosition)
        {
            _position = newPosition % 26;
        }

        public char GetCharForward(char input)
        {
            // Get the character at the position of the input character
            char output = _wiring[(input - 'A' + _position) % 26];

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

        private void setWiring()
        {
            switch (_rotorType)
            {
                case RotorType.RotorI:
                    _wiring = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
                    _notch = 16;
                    break;
                case RotorType.RotorII:
                    _wiring = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
                    _notch = 4;
                    break;
                case RotorType.RotorIII:
                    _wiring = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
                    _notch = 21;
                    break;
                case RotorType.RotorIV:
                    _wiring = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
                    _notch = 9;
                    break;
                case RotorType.RotorV:
                    _wiring = "VZBRGITYUPSDNHLXAWMJQOFECK";
                    _notch = 25;
                    break;
                case RotorType.RotorVI:
                    _wiring = "JPGVOUMFYQBENHZRDKASXLICTW";
                    throw new NotImplementedException();
                    break;
                case RotorType.RotorVII:
                    _wiring = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
                    throw new NotImplementedException();
                    break;
                case RotorType.RotorVIII:
                    _wiring = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
                    throw new NotImplementedException();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }
    }
}
