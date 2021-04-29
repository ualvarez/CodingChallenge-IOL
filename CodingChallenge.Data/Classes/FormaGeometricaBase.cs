using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
   public abstract class FormaGeometricaBase
    {
        private readonly string _nombreEspañol;
        private readonly string _nombreIngles;
        private readonly string _nombrePortugues;

        protected FormaGeometricaBase(decimal ancho, string nombreEspañol, string nombreIngles, string nombrePortugues)
        {
            _lado = ancho;
            _nombreEspañol = nombreEspañol;
            _nombreIngles = nombreIngles;
            _nombrePortugues = nombrePortugues;
        }

        public string ObtenerNombre (Idioma idioma) { 
                switch (idioma)
                {
                    case Idioma.Ingles:
                    return _nombreIngles;                       
                    case Idioma.Español:
                    return _nombreEspañol;
                case Idioma.Portugues:
                    return _nombrePortugues;
                    default:
                    return _nombreIngles;                       
                }
            } 

        protected decimal _lado {get; set;}

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

    }
}
