using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Ask user to input plaintext.
            Console.Write("Please enter plaintext:");
            string plainText = Console.ReadLine();

            //Encrypt

            //Create an array of chars for a key
            char[] cryptKey = new char[plainText.Length];
            //Create an array of chars for storing CypherText in process.
            char[] cypherChar = new char[plainText.Length];
            //Create an instance of random class for key generation.
            Random random = new Random();

            //Iterate through every character of the string.
            for (int i = 0; i < plainText.Length; i++)
            {
                //Create a value in range of ASCII 7-bit.
                cryptKey[i] = (char)random.Next(0, 128);
                //Perform binary XOR on a char from plaintext and a value from key.
                cypherChar[i] = (char)(plainText[i] ^ cryptKey[i]);

            }
            //Store result as a string.
            string cypherText = new string(cypherChar);
            

            Console.WriteLine("Cyphertext: {0}",cypherText); //Output cyphertext.

            //Decrypt

            //Create a char array for storing decrypted chars
            char[] decryptedChar = new char[cypherText.Length];

            //Iterate through every char of the string.
            for (int i = 0; i < cypherText.Length; i++)
            {
                //Perform binary XOR on the cyphertext and the key.
                //If a bit from cyphertext = 0, and bit from cryptKey = 0, decrypted bit = 0; 1:1 - 0; 0:1 - 1; 1:0 - 1.
                decryptedChar[i] = (char)(cypherText[i] ^ cryptKey[i]);
            }
            //Store result as a string.
            string decryptedText = new string(decryptedChar);

            Console.WriteLine("Decrypted text: {0}", decryptedText); //Output deciphered text.

            Console.ReadLine();

        }
    }
}
