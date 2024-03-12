using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevelopmentChallenge.Data.Models;


namespace DevelopmentChallenge.Data.Classes
{
    public class IFormaGeometrica : FormaGeometricaModel
    {
        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                //---- retorno el idioma italiano
                if (idioma == Italiano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | La Zona {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            { //---- para cada caso agrego el italiano y agrego el caso del rectangulo.
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    if (idioma == Italiano) return cantidad == 1 ? "Quadrato" : "Quadrati";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    if (idioma == Italiano) return cantidad == 1 ? "Cerchio" : "Cerchi";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    if (idioma == Italiano) return cantidad == 1 ? "Triangolo" : "Triangoli";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
                case Rectangulo: //---- este lo agrego completo, ya que no existia.
                    if (idioma == Castellano) return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                    if (idioma == Italiano) return cantidad == 1 ? "Rettangolo" : "Rettangoli";
                    else return cantidad == 1 ? "Rectangle" : "Rectangles";
            }

            return string.Empty;
        }
        //---- modifico ambos metodos agregando el calculod del rectangulo siendo que es igual que la del cuadrado.
        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado:
                case Rectangulo:
                    return _lado * _lado;
                case Circulo:
                    return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero:
                    return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado:
                case Rectangulo:
                    return _lado * 4;
                case Circulo:
                    return (decimal)Math.PI * _lado;
                case TrianguloEquilatero:
                    return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
