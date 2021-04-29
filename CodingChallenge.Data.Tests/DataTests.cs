using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;


namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Impresion impresion = new Impresion(new List<FormaGeometricaBase>(), Idioma.Español);
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Impresion impresion = new Impresion(new List<FormaGeometricaBase>(), Idioma.Ingles);
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnPortugues()
        {
            Impresion impresion = new Impresion(new List<FormaGeometricaBase>(), Idioma.Portugues);
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>", impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {           
            var cuadrado = new List<FormaGeometricaBase>
            {
                new Cuadrado(5)                
            };

            Impresion impresion = new Impresion(cuadrado, Idioma.Español);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioRectangulo()
        {
            var cuadrado = new List<FormaGeometricaBase>
            {
                new TrapecioRectangulo(7,5,29)
            };

            Impresion impresion = new Impresion(cuadrado, Idioma.Español);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 TrapecioRectangulo | Area 119 | Perímetro 66 <br/>TOTAL:<br/>1 formas Perímetro 66 Area 119", impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            Impresion impresion = new Impresion(cuadrados, Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),              
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new TrapecioRectangulo(7,5,29.2m)
            };

            Impresion impresion = new Impresion(formas, Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 TrapezoidRectangle | Area 119,7 | Perimeter 66,39 <br/>TOTAL:<br/>8 shapes Perimeter 164,06 Area 211,35",
                impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            Impresion impresion = new Impresion(formas, Idioma.Español);

            Assert.AreEqual(
               "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Area 91,65",
               impresion.Imprimir());
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnPortugues()
        {
            var formas = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            Impresion impresion = new Impresion(formas, Idioma.Portugues);

            Assert.AreEqual(
               "<h1>Relatório de Formulários</h1>2 Quadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triângulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Area 91,65",
               impresion.Imprimir());
        }
    }
}
