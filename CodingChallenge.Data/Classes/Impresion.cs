using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Impresion
    {
        private readonly List<FormaGeometricaBase> _formas;
        private readonly Idioma _idioma;

        public Impresion(List<FormaGeometricaBase> formas, Idioma idioma)
        {
            _formas = formas;
            _idioma = idioma;
        }

        public string Imprimir()
        {
            var sb = new StringBuilder();

            // Hay por lo menos una forma
            // HEADER               
            sb.Append(obtenerHeader());

            if (_formas.Any())
            {
                var cantidad = 0;
                var area = 0m;
                var perimetro = 0m;
                var nombreTipo = "";
                var listaTotales = new List<Totalisador>();
                foreach (var tipo in ObtenerListaDeTipos())
                {
                    foreach (var forma in _formas)
                    {
                        if (forma.GetType() == tipo)
                        {
                            nombreTipo = forma.ObtenerNombre(_idioma);
                            cantidad++;
                            area += forma.CalcularArea();
                            perimetro += forma.CalcularPerimetro();
                        }
                    }
                    listaTotales.Add(new Totalisador { NombreTipo = nombreTipo, Cantidad = cantidad, Area = area, Perimetro = perimetro });
                    sb.Append(obtenerLinea(cantidad, area, perimetro, nombreTipo));
                     cantidad = 0;
                     area = 0m;
                     perimetro = 0m;
                     nombreTipo = "";
                }

                sb.Append(obtenerFooter(listaTotales));
            }

            return sb.ToString();
        }

        private List<Type> ObtenerListaDeTipos()
        {
            List<Type> lista = new List<Type>();

            foreach (var item in _formas)
            {
                if (lista.FindLast(t => t.Name == item.GetType().Name) == null)
                {
                    lista.Add(item.GetType());
                }
            }

            return lista;
        }

        private string obtenerHeader()
        {
            if (_formas.Any())
            {
                switch (_idioma)
                {
                    case Idioma.Ingles:
                        return "<h1>Shapes report</h1>";
                    case Idioma.Español:
                        return "<h1>Reporte de Formas</h1>";
                    case Idioma.Portugues:
                    return "<h1>Relatório de Formulários</h1>";
                    default:
                        return "<h1>Shapes report</h1>";
                }
            }
            else
            {
                switch (_idioma)
                {
                    case Idioma.Ingles:
                        return "<h1>Empty list of shapes!</h1>";
                    case Idioma.Español:
                        return "<h1>Lista vacía de formas!</h1>";
                    case Idioma.Portugues:
                        return "<h1>Lista vazia de formas!</h1>";
                    default:
                        return "<h1>Empty list of shapes!</h1>";
                }
            }
        }
        private string obtenerLinea(int cantidad, decimal area, decimal perimetro, string nombreTipo)
        {
            if (cantidad > 0)
            {
                string nombre = nombreTipo + (cantidad > 1 ? "s" : "");
                string textoPerimetro = string.Empty;
                switch (_idioma)
                {
                    case Idioma.Español:
                        textoPerimetro = "Perímetro";
                        break;
                    case Idioma.Ingles:
                        textoPerimetro = "Perimeter";
                        break;
                    case Idioma.Portugues:
                        textoPerimetro = "Perímetro";
                        break;
                    default:
                        textoPerimetro = "Perimeter";
                        break;
                }

                return $"{cantidad} {nombre} | Area {area:#.##} | {textoPerimetro} {perimetro:#.##} <br/>";
            }
            else { return string.Empty; }
        }

        

        private StringBuilder obtenerFooter(List<Totalisador> totales)
        {
            var sb = new StringBuilder();
            sb.Append("TOTAL:<br/>");
            if (!totales.Any())
            {
                sb.Append("0");
            }
            else
            {
                string textoFormas = string.Empty;
                string textoPerimetro = string.Empty;
                switch (_idioma)
                {
                    case Idioma.Ingles:
                        textoFormas = "shapes";
                        textoPerimetro = "Perimeter";
                        break;
                    case Idioma.Español:
                        textoFormas = "formas";
                        textoPerimetro = "Perímetro";
                        break;
                    case Idioma.Portugues:
                        textoFormas = "formas";
                        textoPerimetro = "Perímetro";
                        break;
                    default:
                        textoFormas = "shapes";
                        textoPerimetro = "Perimeter";
                        break;
                }

                sb.Append(totales.Sum(x => x.Cantidad) + " " + textoFormas + " ");
                sb.Append(textoPerimetro + " " + (totales.Sum(x => x.Perimetro)).ToString("#.##") + " ");
                sb.Append("Area " + (totales.Sum(x => x.Area)).ToString("#.##"));
            }
            return sb;
        }

        public class Totalisador
        {
            public string NombreTipo { get; set; }
            public int Cantidad { get; set; }
            public decimal Area { get; set; }
            public decimal Perimetro { get; set; }
        }
    }
}
