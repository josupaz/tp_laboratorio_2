using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region "Constructores"

        /// <summary>
        /// Constructor de Dulce, reutiliza el del padre.
        /// </summary>
        /// <param name="marca">Marca de producto</param>
        /// <param name="codigo">Codigo de barras</param>
        /// <param name="color">Color de empaque</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) 
            :base(codigo,marca,color)
        {
        }
        #endregion

        #region "Propiedades"

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region "Metodos"

        /// <summary>
        /// Metodo Mostrar hereda de padre y aumenta datos a mostrar propios de la clase
        /// </summary>
        /// <returns>Muestra datos heredados y propios.</returns>
        public override  string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS :"+ this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
