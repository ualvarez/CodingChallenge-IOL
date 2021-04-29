using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrapecioRectangulo : FormaGeometricaBase
    {
        private decimal _ladoA;
        private decimal _ladoB;       
        public TrapecioRectangulo(decimal ancho, decimal ladoA, decimal ladoB) : base(ancho, "TrapecioRectangulo", "TrapezoidRectangle", "TrapezoidRectangle")
        {
            _ladoA = ladoA;
            _ladoB = ladoB;           
        }

        public override decimal CalcularArea()
        {
            return _lado * ((_ladoA + _ladoB) / 2);
        }

        public override decimal CalcularPerimetro()
        {
            decimal cateto1 = 0;
            decimal cateto2 = _lado;

            if(_ladoA > _ladoB)
            {
                cateto1 = _ladoA - _ladoB;
            }
            else
            {
                cateto1 = _ladoB - _ladoA;
            }

            double hipotenusaAlCuadrado = 0;
            double hipotenusa = 0;

            hipotenusaAlCuadrado = Convert.ToDouble((cateto1 * cateto1) + (cateto2 * cateto2));
            hipotenusa = Math.Sqrt(hipotenusaAlCuadrado);
            
            return Convert.ToDecimal(Convert.ToDouble(_lado + _ladoA + _ladoB) + hipotenusa);
        }
    }
}
