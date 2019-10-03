using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera,
            Descremada
        }

        ETipo tipo;


        /// <summary>
        /// Constructor de leche, reutiliza el del padre.
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Codigo de barras</param>
        /// <param name="color">Color de empaque</param>
        /// <param name="tipo">Tipo entera o Descremada</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color,ETipo tipo)
            : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor de Leche. Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Codigo de barras</param>
        /// <param name="color">Color de empaque</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : this(marca, codigo, color, ETipo.Entera)
        {
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// Metodo Mostrar hereda de padre y aumenta datos a mostrar propios de la clase
        /// </summary>
        /// <returns>Muestra datos de leche.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.Append("CALORIAS :" + this.CantidadCalorias);
            sb.AppendLine(" TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
