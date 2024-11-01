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

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {

        /*
        1) Idioma
        Se agregaron 2 idiomas, Italiano y Portugues, se modifica la logica de ifs por switch/case, menos validaciones, 
        mas rendimiento, obteniendo para c/ idioma su traduccion

        2) Nueva forma
        *Se agregaron 2 atributos altura y base, datos necesarios para calcular la figura solcitiada TRAPECIO RECTANGULO
        *Se investigo la formula para calcular el area y perimetro, escrita al lado de los algoritmos. 
        *Se extendio la funcionalidad, conviviendo con las anteriores 3 figuras y sus atributos, en donde (lado) se usa en el
        caso de la nueva figura como una de las bases,
        *Se modifico el constructo para soporte la creacion de la nueva figura.
        *Los nuevos parametros se inicializan en 0 por defecto, debido a que en el
        resto de las figuras no se usa.

        3) Test
        Se agregaron nuevos test alineados a los ya existentes.

        */

        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;
        public const int Portugues = 4;

        #endregion

        private readonly decimal _lado;// Para las 3 figuras es lado o radio, para el trapecio rectangular es una de las bases

        //Agregado solución
        private readonly decimal _base; 
        private readonly decimal _altura;

        public int Tipo { get; set; }

        //public FormaGeometrica(int tipo, decimal ancho)
        //{
        //    Tipo = tipo;
        //    _lado = ancho;
        //}

        public FormaGeometrica(int tipo, decimal ancho, decimal alto = 0, decimal _base = 0)//Se agregan parametros al constructor para soportar el trapecio como figura
        {
            Tipo = tipo;
            _lado = ancho;

            //Agregado solución
            _altura = alto;
            this._base = _base;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                //if (idioma == Castellano)
                //    sb.Append("<h1>Lista vacía de formas!</h1>");
                //else
                //    sb.Append("<h1>Empty list of shapes!</h1>");

                //Agregado para idioma
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Lista vacía de formas!</h1>");
                        break;
                    case Ingles:
                        sb.Append("<h1>Empty list of shapes!</h1>");
                        break;
                    case Italiano:
                        sb.Append("<h1>Lista vuota di forme!</h1>");
                        break;
                    case Portugues:
                        sb.Append("<h1>Lista vazia de formas!</h1>");
                        break;
                }
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                //if (idioma == Castellano)
                //    sb.Append("<h1>Reporte de Formas</h1>");
                //else
                //    // default es inglés
                //    sb.Append("<h1>Shapes report</h1>");

                // HEADER
                //Agregado para idioma
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Reporte de Formas</h1>");
                        break;
                    case Ingles:
                        sb.Append("<h1>Shapes report</h1>");
                        break;
                    case Italiano:
                        sb.Append("<h1>Rapporto sulle forme</h1>");
                        break;
                    case Portugues:
                        sb.Append("<h1>Relatório de formas</h1>");
                        break;
                }

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecios = 0;//Agregado solución

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTraprecios = 0m;//Agregado solución

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTraprecios = 0m;//Agregado solución

                //for (var i = 0; i < formas.Count; i++)
                //{
                //    if (formas[i].Tipo == Cuadrado)
                //    {
                //        numeroCuadrados++;
                //        areaCuadrados += formas[i].CalcularArea();
                //        perimetroCuadrados += formas[i].CalcularPerimetro();
                //    }
                //    if (formas[i].Tipo == Circulo)
                //    {
                //        numeroCirculos++;
                //        areaCirculos += formas[i].CalcularArea();
                //        perimetroCirculos += formas[i].CalcularPerimetro();
                //    }
                //    if (formas[i].Tipo == TrianguloEquilatero)
                //    {
                //        numeroTriangulos++;
                //        areaTriangulos += formas[i].CalcularArea();
                //        perimetroTriangulos += formas[i].CalcularPerimetro();
                //    }
                //    if (formas[i].Tipo == Trapecio)
                //    {
                //        numeroTrapecios++;
                //        areaTraprecios += formas[i].CalcularArea();
                //        perimetroTraprecios += formas[i].CalcularPerimetro();
                //    }
                //}

                // Mejor rendimiento, menos if disminuye la logica
                foreach (var unaForma in formas)
                {
                    switch (unaForma.Tipo)
                    {
                        case Cuadrado:
                            numeroCuadrados++;
                            areaCuadrados += unaForma.CalcularArea();
                            perimetroCuadrados += unaForma.CalcularPerimetro();
                            break;

                        case TrianguloEquilatero:
                            numeroTriangulos++;
                            areaTriangulos += unaForma.CalcularArea();
                            perimetroTriangulos += unaForma.CalcularPerimetro();
                            break;

                        case Circulo:
                            numeroCirculos++;
                            areaCirculos += unaForma.CalcularArea();
                            perimetroCirculos += unaForma.CalcularPerimetro();
                            break;

                        case Trapecio:
                            numeroTrapecios++;
                            areaTraprecios += unaForma.CalcularArea();
                            perimetroTraprecios += unaForma.CalcularPerimetro();
                            break;
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));
                //Agregado solución
                sb.Append(ObtenerLinea(numeroTrapecios, areaTraprecios, perimetroTraprecios, Trapecio, idioma));


                // FOOTER
                //sb.Append("TOTAL:<br/>");
                //sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                //sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                //sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));

                //Agregado solución
                // FOOTER
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + "formas" + " ");
                        sb.Append("Perimetro " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTraprecios).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTraprecios).ToString("#.##"));
                        break;
                    case Ingles:
                        sb.Append("TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + "shapes" + " ");
                        sb.Append("Perimeter " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTraprecios).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTraprecios).ToString("#.##"));
                        break;
                    case Italiano:
                        sb.Append("TOTALE:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + "forme" + " ");
                        sb.Append("Perimetro " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTraprecios).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTraprecios).ToString("#.##"));
                        break;
                    case Portugues:
                        sb.Append("TOTAL:<br/>");
                        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + "formas" + " ");
                        sb.Append("Perímetro " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTraprecios).ToString("#.##") + " ");
                        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTraprecios).ToString("#.##"));
                        break;
                }
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                //if (idioma == Castellano)
                //    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                //return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";

                ////Agregado solución
                switch (idioma)
                {
                    case Castellano: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";//Castellano
                    case Ingles: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";//Ingles
                    case Italiano: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";//Italiano
                    case Portugues: return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";//Portugues
                }
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            //switch (tipo)
            //{
            //    case Cuadrado:
            //        if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
            //        else return cantidad == 1 ? "Square" : "Squares";
            //    case Circulo:
            //        if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
            //        else return cantidad == 1 ? "Circle" : "Circles";
            //    case TrianguloEquilatero:
            //        if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
            //        else return cantidad == 1 ? "Triangle" : "Triangles";
            //}

            //Agregado solución
            switch (idioma)
            {
                case Castellano:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                        case Circulo: return cantidad == 1 ? "Círculo" : "Círculos";
                        case TrianguloEquilatero: return cantidad == 1 ? "Triángulo" : "Triángulos";
                        case Trapecio: return cantidad == 1 ? "Trapecio" : "Trapecios";
                    }
                    break;
                case Ingles:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Square" : "Squares";
                        case Circulo: return cantidad == 1 ? "Circle" : "Circles";
                        case TrianguloEquilatero: return cantidad == 1 ? "Triangle" : "Triangles";
                        case Trapecio: return cantidad == 1 ? "Trapeze" : "Trapezoids";
                    }
                    break;
                case Italiano:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Piazza" : "Piazze";
                        case Circulo: return cantidad == 1 ? "Cerchio" : "Cerchi";
                        case TrianguloEquilatero: return cantidad == 1 ? "Triangolo" : "Triangli";
                        case Trapecio: return cantidad == 1 ? "Trapezio" : "Trapezi";
                    }
                    break;
                case Portugues:
                    switch (tipo)
                    {
                        case Cuadrado: return cantidad == 1 ? "Quadrado" : "Quadrados";
                        case Circulo: return cantidad == 1 ? "Círculo" : "Círculos";
                        case TrianguloEquilatero: return cantidad == 1 ? "Triângulo" : "Triângulos";
                        case Trapecio: return cantidad == 1 ? "Trapézio" : "Trapézios";

                    }
                    break;
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case Trapecio: return _altura * ((_lado + _base) / 2);// Formula calculo area trapecio rectangulo
                                                                      // Area =  c * ((a+b)/2) siendo a,b  las bases y c el lado que coincide con la altura
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                case Trapecio: return (_lado + _base + _altura + CalcularLado(_altura, _base - _lado));//Formula calculo perimetro trapecio rectangulo
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }


        #region Trapecio Rectangular

        /*

        Este metodo devuelve el dato en decimal del lado o tambien llamado cateto, faltante del triangulo rectangulo, teorema de pitagoras

        Formula 
        la raíz cuadrada de la suma del área de los cuadrados de las respectivas longitudes de los catetos.

        a --> Parametro correspondiente a la medida de uno de los catetos
        b --> Parametro correspondiente a la medida del otro cateto conocido

         */

        public decimal CalcularLado(decimal a, decimal b)
        {
            return (decimal)Math.Sqrt((double)((a * a) + (b * b)));
        }

        #endregion
    }
}
