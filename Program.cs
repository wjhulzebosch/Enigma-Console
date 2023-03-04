using Enigma.Model;

EnigmaMachine EnigmaMachine = new EnigmaMachine();
Console.WriteLine(EnigmaMachine.Encrypt("HELLOWORLDTHISISATESTWITHALONGERMESSAGEBECAUSEIWANTOSEEIFAROTORROLLSOVER"));

// Reset machine and decrypt message
EnigmaMachine = new EnigmaMachine();
Console.WriteLine(EnigmaMachine.Encrypt("QHHHQRMQUQWJGVNQUZUVDJVNJJOAZQVHUHKGGTYYMVHHZXCPGUMGAMFVAIKIAHYLGYGLSCZC"));
