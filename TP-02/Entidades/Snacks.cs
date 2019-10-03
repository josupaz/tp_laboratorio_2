using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        /// <summary>
        /// Metodo Mostrar hereda de padre y aumenta datos a mostrar propios de la clase
        /// </summary>
        /// <returns>Muestra datos de snack.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACK");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS :" + this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
