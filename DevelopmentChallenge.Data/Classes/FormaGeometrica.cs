/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevelopmentChallenge.Data.Models;

namespace DevelopmentChallenge.Data.Classes
{

    public class FormaGeometrica : IFormaGeometrica 
    {
        public readonly decimal _lado;
        //----- Joel Benavidez
        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                if (idioma == Italiano) //---- agrego la condicion para el nuevo idioma. 
                    sb.Append("<h1>Elenco vuoto di forme!</h1>"); //---- el mensaje lo traduje con googleTranslate, no se italiano sepan disculpar :D
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            } 
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                if (idioma == Italiano) 
                    sb.Append("<h1>Rapporto sui moduli</h1>"); 
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var numeroRectangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var areaRectangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                var perimetroRectangulo = 0m;


                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                    //---- condicion para recorrer el rectangulo
                    if (formas[i].Tipo == Rectangulo)
                    {
                        numeroRectangulos++;
                        areaRectangulos += formas[i].CalcularArea();
                        perimetroRectangulo += formas[i].CalcularPerimetro();
                    }
                    //---- termino la condicion
                }
                
                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));
                //---- obtengo la linea del nuevo rectangulo
                sb.Append(ObtenerLinea(numeroRectangulos, areaRectangulos, perimetroRectangulo, Rectangulo, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                //---- agrego el italiano como respuesta y el rectangulo.
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroRectangulos + " " + (idioma == Castellano ? "formas" : (idioma == Italiano ? "forme" : "shapes")) + " ");
                sb.Append((idioma == Castellano ? "Perimetro" : (idioma == Italiano ? "Perimetro" : "Perimeter")) + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroRectangulo).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaRectangulos).ToString("#.##"));
            }

            return sb.ToString();
        } 

    }
}
