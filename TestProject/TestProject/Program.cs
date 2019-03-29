using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class Program {
        static void Main (string[] args) {

            string secretWord;
            string showWord = "";
            secretWord = Console.ReadLine ();
            Console.Clear ();
            for (int i = 0; i < secretWord.Length; i++) {
                if (!(secretWord[i] == ' ')) {
                    showWord += "*";
                } else {
                    showWord += " ";
                }
            }
            Console.WriteLine ("Your secret word is " + showWord);
        }
    }
}
