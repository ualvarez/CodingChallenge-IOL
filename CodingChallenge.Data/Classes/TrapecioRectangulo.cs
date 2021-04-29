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
        private decimal _ladoC;
        public TrapecioRectangulo(decimal ancho, decimal ladoA, decimal ladoB, decimal ladoC) : base(ancho, "TrapecioRectangulo", "TrapecioRectangulo", "TrapezoidRectangle")
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
        }

        public override decimal CalcularArea()
        {
            return _lado * ((_ladoA + _ladoB) / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return _lado + _ladoA + _ladoB + _ladoC;
        }
    }
}
