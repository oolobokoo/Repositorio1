using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class HangGame {
        
        public GuessTest guessTest;

        public HangGame () {
            Console.WriteLine ("Choose your word: ");
            guessTest = new GuessTest (Console.ReadLine ());
            Console.Clear ();
            Console.WriteLine ("Your secret word is " + guessTest.shownWord);
        }
    }
}
