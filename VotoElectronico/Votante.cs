using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotoElectronico
{
    public class Votante
    {
        public string Nombre { get; set; }  
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Antecedentes { get; set; }

        public Votante() 
        {
        }

        public Votante(string nombre, string apellidos, int edad, string antecedentes)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Antecedentes = antecedentes;
        }
    }
}
