using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class Program {
        static void Main (string[] args) {

            int num = 0;
            float dec = 1.25f;
            char letter = 'A';
            bool truth = false;
            string word = "Word";

            Auto auto = new Auto();
            Console.Write ("con " + auto.numeroDePuertas + " puertas ");
            Console.WriteLine ("y con un motor de " + auto.motor.numCilindros + " cilindros");
        }
    }
}
