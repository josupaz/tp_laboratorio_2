using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        /// <summary>
        /// Constructor de Producto
        /// </summary>
        /// <param name="codigo">Codigo de barras</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color de paquete</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornara la cantidad de calorias
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        public  static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p.codigoDeBarras);
            sb.AppendLine("MARCA          : "+ p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : "+ p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="p1">Primer producto a comparar</param>
        /// <param name="p2">Segundo producto a comparar</param>
        /// <returns> True si son iguales, False si son distintos</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.codigoDeBarras == p2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="p1">Primer producto a comparar</param>
        /// <param name="p2">Segundo producto a comparar</param>
        /// <returns> False si son iguales, True si son distintos</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
    }
}
