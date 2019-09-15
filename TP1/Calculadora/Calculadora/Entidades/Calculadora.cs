using System;
using System.Collections.Generic;
using System.Text;


namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Recibe dos datos de tipo Numero y un dato String
        /// valida que los Numeros no sean null,
        /// valida que el dato String contenga un operador correcto ( + - * / )
        /// y realiza la operacion, devolviendo esta.
        /// </summary>
        /// <param name="num1">1er operando de tipo de dato Numero</param>
        /// <param name="num2">2do operando de tipo de dato Numero</param>
        /// <param name="operador">operador de tipo de dato String</param>
        /// <returns>default min valor de double, o si se puede realizar la operancion, devuelve el resultado de la misma</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = double.MinValue;
            if (!(num1 is null) && !(num2 is null))//Valido que los Numero no sean null
            {
                ValidarOperador(operador);//Valido operador
                switch (operador)
                {
                    case "+":
                        retorno = num1 + num2;
                        break;
                    case "-":
                        retorno = num1 - num2;
                        break;
                    case "*":
                        retorno = num1 * num2;
                        break;
                    case "/":
                        retorno = num1 / num2;
                        break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Valida que el operador ingresado sea correcto ( + - * / ), de no ser asi setea el operador ( + )
        /// </summary>
        /// <param name="operador">string a validar</param>
        /// <returns>un operador valido (+ - * /)</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != "+" || operador != "-" || operador != "*" || operador != "/")
                operador = "+";

            return operador;
        }
    }
}
