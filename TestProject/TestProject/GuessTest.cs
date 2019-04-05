using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class GuessTest {
        const string symbol = "*";
        const char emptySpace = ' ';
        string secretWord;
        public string shownWord { get; private set; }

        public GuessTest (string secretWord) {
            if (string.IsNullOrWhiteSpace (secretWord)) {
                Console.WriteLine ("WARNING YOU MADE A GAME WITH EMPTY SECRETWORD");
                return;
            }
            this.secretWord = secretWord;
            for (int i = 0; i < secretWord.Length; i++) {
                if (!(secretWord[i] == emptySpace)) {
                    shownWord += symbol;
                } else {
                    shownWord += emptySpace;
                }
            }
        }
    }
}
