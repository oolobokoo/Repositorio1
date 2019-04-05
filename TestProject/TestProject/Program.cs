using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class Program {
        static void Main (string[] args) {

            string secretWord;
            string shownWord = "";
            secretWord = Console.ReadLine ();
            Console.Clear ();
            for (int i = 0; i < secretWord.Length; i++) {
                if (!(secretWord[i] == ' ')) {
                    shownWord += "*";
                } else {
                    shownWord += " ";
                }
            }
            Console.WriteLine ("Your secret word is " + shownWord);

            while (!(shownWord == secretWord)) {
                string charTry;
                charTry = Console.ReadLine ();

                while (charTry != secretWord || string.IsNullOrWhiteSpace(charTry) || charTry.Length > 1) {
                    Console.Clear ();
                    Console.WriteLine ("Your secret word is " + shownWord);
                    Console.WriteLine ("Please input just one letter per try");
                    charTry = Console.ReadLine ();
                }

                if (charTry == secretWord) {
                    shownWord = charTry;
                } else {

                    if (secretWord.Contains (charTry)) {
                        string tempWord = string.Empty;
                        for (int i = 0; i < secretWord.Length; i++) {
                            if (secretWord[i] == charTry[0]) {
                                tempWord += secretWord[i];
                            } else {
                                tempWord += shownWord[i];
                            }
                        }
                        shownWord = tempWord;
                    }
                }

                Console.Clear ();
                Console.WriteLine ("Your secret word is " + shownWord);
            }
        }
    }
}
