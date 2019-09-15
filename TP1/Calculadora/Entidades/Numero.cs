using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {

        private double numero;

        #region Construcores
        /// <summary>
        /// constructor, por defecto setea this.numero en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// constructor recibe por parametro double a ser ingresado en this.numero
        /// </summary>
        /// <param name="numero">double a ingresar en this.numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// constructor recibe por parametro un dato string con valor a setear en this.numero,
        /// utilizando el constructor que recibe por parametro dato double.
        /// </summary>
        /// <param name="strNumero">string a ingresar en this.numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// recibe un dato string, valida si se puede parsear a double y devuelve el doueble parseado.
        /// </summary>
        /// <param name="strNumero">dato a parsear</param>
        /// <returns>por defecto double con valor 0, si el dato string se puede parsear devuelve
        /// double con el valor de string parseado</returns>
        public double ValidarNumero(string strNumero)
        {
            double aux;
            double retorno = 0;
            if (double.TryParse(strNumero, out aux))
                retorno = aux;

            return retorno;
        }
        /// <summary>
        /// Si el numero ingresado es valido, lo setea en this.numero
        /// </summary>
        private string SetNumero
        {
            set
                {
                numero = ValidarNumero(value);
                }
        }
        /// <summary>
        /// Recibe un dato de tipo double, si es factible lo convierte en binario
        /// y devuelve el mismo, caso contrario retorna Valor invalido.
        /// </summary>
        /// <param name="dato">dato de tipo double que contiene el decimal a convertir en binario</param>
        /// <returns>por default devuelve string "Cadena Invalida", si el dato ingresado por parametro
        /// puede convertirse a binario, devuelve el mismo</returns>
        public static string DecimalBinario(double dato)
        {
            string convertidoABinario = "";
            string retorno = "Valor invalido";

            if (dato > 0) {

                do
                {

                    convertidoABinario = convertidoABinario + (dato % 2);
                    dato = (int)dato / 2;

                } while (dato != 0.00);

                char[] charArray = convertidoABinario.ToCharArray();
                Array.Reverse(charArray);
                convertidoABinario = new string(charArray);
                retorno = convertidoABinario;
            }


            return retorno;
        }
        /// <summary>
        /// Recibe un dato de tipo String, si es factible lo convierte en binario
        /// y devuelve el mismo, caso contrario retorna Valor invalido.
        /// </summary>
        /// <param name="dato">dato de tipo string que contiene el decimal a convertir en binario</param>
        /// <returns>por default devuelve string "Cadena Invalida", si el dato ingresado por parametro
        /// puede convertirse a binario, devuelve el mismo</returns>
        public static string DecimalBinario(string dato)
        {
            string retorno = "Valor invalido";

            if (!(dato.Contains("-1,79769313486232E+308")) && !(dato.Contains("Valor invalido")))
                {
                double decim = Convert.ToDouble(dato);
                decim = Math.Truncate(decim);
                retorno = DecimalBinario(decim);
                }

            return retorno;

        }
        /// <summary>
        /// Recibe un dato de tipo String, si es factible lo convierte en decimal
        /// y devuelve el mismo, caso contrario retorna Valor invalido.
        /// </summary>
        /// <param name="dato">dato de tipo string que contiene el binario a convertir en decimal</param>
        /// <returns>por default devuelve string "Cadena Invalida", si el dato ingresado por parametro
        /// puede convertirse a decimal, devuelve el mismo</returns>
        public static String BinarioDecimal(string dato)
        {
            string retorno = "Valor invalido";
            char[] charArray = dato.ToCharArray();
            Array.Reverse(charArray);
            int sum = 0;

            bool flag = true;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '1')
                {
                    sum += (int)Math.Pow(2, i);
                }
                else if (charArray[i] != '0' || int.Parse(dato)==0)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {

                retorno = Convert.ToString(sum);
            }
            return retorno;
        }


        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Recibe 2 datos de tipo Numero, Valida que no sean null,  suma los numeros ingresados por parametro.
        /// </summary>
        /// <param name="numUno">dato de tipo Numero</param>
        /// <param name="numDos">dato de tipo Numero</param>
        /// <returns>por defecto 0, si los valores ingresados por parametro no son null
        /// devuelve el resultado de la suma</returns>
        public static double operator +(Numero numUno, Numero numDos)
        {
            double retorno = 0;
            if (!(numUno is null) && !(numDos is null))
            {
                retorno = numUno.numero + numDos.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Recibe 2 datos de tipo Numero, Valida que no sean null,  resta los numeros ingresados por parametro.
        /// </summary>
        /// <param name="numUno">dato de tipo Numero</param>
        /// <param name="numDos">dato de tipo Numero</param>
        /// <returns>por defecto 0, si los valores ingresados por parametro no son null
        /// devuelve el resultado de la resta</returns>
        public static double operator -(Numero numUno, Numero numDos)
        {
            double retorno = 0;
            if (!(numUno is null) && !(numDos is null))
            {
                retorno = numUno.numero - numDos.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Recibe 2 datos de tipo Numero, Valida que no sean null,  multiplica el primer Numero por el segundo.
        /// </summary>
        /// <param name="numUno">dato de tipo Numero</param>
        /// <param name="numDos">dato de tipo Numero</param>
        /// <returns>por defecto 0, si los valores ingresados por parametro no son null
        /// devuelve el resultado de la multiplicacion</returns>
        public static double operator *(Numero numUno, Numero numDos)
        {
            double retorno = 0;
            if (!(numUno is null) && !(numDos is null))
            {
                retorno = numUno.numero * numDos.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Recibe 2 datos de tipo Numero, Valida que no sean null, si el valor del 2do numero es > a 0, divide el valor del primero Numero por el segundo.
        /// </summary>
        /// <param name="numUno">dato de tipo Numero, a ser dividido</param>
        /// <param name="numDos">dato de tipo Numero, que divide</param>
        /// <returns>por defecto 0, si los valores ingresados por parametro no son null
        /// y el divisor es > 0 , devuelve el resultado de la division.</returns>
        public static double operator /(Numero numUno, Numero numDos)
        {
            double retorno = 0;
            if (!(numUno is null) && !(numDos is null))
            {
                if (numDos.numero > 0)
                {
                    retorno = numUno.numero / numDos.numero;
                }
                else
                {
                    retorno = double.MinValue;
                }
            }

            return retorno;
        }

        #endregion
    }
}
