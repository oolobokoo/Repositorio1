using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    //Esta es mi clase Auto
    class Auto {
        public int numeroDePuertas;
        private bool encendido; //Remover luego del test
        string marca;
        public Motor motor;

        private void Encender () {
            int numero = 0;
            //TODO: cambiar encendido a true
            Console.WriteLine ("Se encendió el Auto");
        }

        public Auto() {
            Console.WriteLine ("Se creó un nuevo Auto");
            numeroDePuertas = 5;
            motor = new Motor (this);
            motor.numCilindros = 4;
        }
    }
}
