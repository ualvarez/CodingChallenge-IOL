using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Impresion
    {
        private readonly List<FormaGeometricaBase> _formas;
        private readonly Idioma _idioma;
        private Texto _texto;

        public Impresion(List<FormaGeometricaBase> formas, Idioma idioma)
        {
            _formas = formas;
            _idioma = idioma;
            InicializarTextos();
        }

        private void InicializarTextos()
        {
            string path = string.Empty;
            switch (_idioma)
            {
                case Idioma.Español:
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IdiomasConfig\es-ar.json");
                    break;
                case Idioma.Ingles:
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IdiomasConfig\en-us.json");
                    break;
                case Idioma.Portugues:
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IdiomasConfig\pt-br.json");
                    break;
                default:
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IdiomasConfig\en-us.json");
                    break;
            }
            try
            {
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    var json = reader.ReadToEnd();
                    _texto = JsonConvert.DeserializeObject<Texto>(json);
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("Archivo de Idioma no encontrado en el directorio: " + path);
            }

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
                return "<h1>" + _texto.Header.TituloListaConDatos + "</h1>";
            }
            else
            {
                return "<h1>" + _texto.Header.TituloListaVacia + "</h1>";
            }
        }
        private string obtenerLinea(int cantidad, decimal area, decimal perimetro, string nombreTipo)
        {
            if (cantidad > 0)
            {
                string nombre = nombreTipo + (cantidad > 1 ? "s" : "");

                return $"{cantidad} {nombre} | Area {area:#.##} | {_texto.FiguraGeometrica.Perimetro} {perimetro:#.##} <br/>";
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
                sb.Append(totales.Sum(x => x.Cantidad) + " " + _texto.FiguraGeometrica.Formas + " ");
                sb.Append(_texto.FiguraGeometrica.Perimetro + " " + (totales.Sum(x => x.Perimetro)).ToString("#.##") + " ");
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
