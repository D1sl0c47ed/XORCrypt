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

            string plainString = null;
            List<string> plainList = new List<string>();
            //Ask user to input plaintext.
            int line = 1;
            do
            {
              
                Console.Write("Please enter line {0}:",line);

                plainString = Console.ReadLine();
                if (plainString != "exit")
                {
                    plainList.Add(plainString);
                    line++;
                }
                else
                {
                    break;
                }

            } while (true);

            List<string> CryptKeys = new List<string>();
            List<string> CypherList = new List<string>();

            //Create an instance of random class for key generation.
            Random random = new Random();
            foreach (string PlainText in plainList)
            {

                char[] cryptKey = new char[PlainText.Length]; // An array of chars for a key
                char[] cypherChar = new char[PlainText.Length]; // An array of chars for cypherText

                

                //Iterate through every character of the string.
                for (int i = 0; i < PlainText.Length; i++)
                {
                    //Assign a pseudo-random value in range of ASCII 7-bit.
                    cryptKey[i] = (char)random.Next(0, 128);
                    //Perform binary XOR on char from PlainText and a value from cryptKey.
                    cypherChar[i] = (char)(PlainText[i] ^ cryptKey[i]);
                }

                //Add results to lists
                CryptKeys.Add(new string(cryptKey));
                CypherList.Add(new string(cypherChar));
                
            }
            // Output CypherText
            foreach (string CypherText in CypherList)
            {
                Console.WriteLine("Cyphertext: {0}", CypherText);
            }
            Console.ReadLine();

      
            //Decrypt
            for(int iList=0; iList<CryptKeys.Count; iList++)
            {
                //Set iterable items.
                char[] CryptKey = CryptKeys[iList].ToCharArray();
                char[] CypherText = CypherList[iList].ToCharArray();

                char[] decryptedChar = new char[CypherText.Length];
                
                //Iterate through every char of the string.
                for (int i = 0; i < CypherText.Length; i++)
                {
                    //Perform binary XOR on the cyphertext and the key.
                    //If a bit from cyphertext = 0, and bit from cryptKey = 0, decrypted bit = 0; 1:1 - 0; 0:1 - 1; 1:0 - 1.
                    decryptedChar[i] = (char)(CypherText[i] ^ CryptKey[i]);
                }
                //Store result as a string.
                string decryptedText = new string(decryptedChar);

                Console.WriteLine("Decrypted text: {0}", decryptedText); //Output deciphered text.

            }
            Console.ReadLine();
        }
    }
}
