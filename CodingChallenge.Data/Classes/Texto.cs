using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
   public class Texto
    {
        public FiguraGeometrica FiguraGeometrica { get; set; }
        public Header Header { get; set; }
        public Texto()
        {
            FiguraGeometrica = new FiguraGeometrica();
            Header = new Header();
        }
              
      
    }

    public class FiguraGeometrica
    {
        public string Circulo { get; set; }
        public string Cuadrado { get; set; }
        public string Triangulo { get; set; }
        public string TrapecioRectangulo { get; set; }
        public string Perimetro { get; set; }
        public string Area { get; set; }
        public string Formas { get; set; }
    }

    public class Header
    {
        public string TituloListaVacia { get; set; }

        public string TituloListaConDatos { get; set; }
         
        }
}
