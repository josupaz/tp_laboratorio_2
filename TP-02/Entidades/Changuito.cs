using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        /// <summary>
        /// Constructor privado, unico lugar donde inicializa lista productos.
        /// </summary>
        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>(espacioDisponible);
        }
        /// <summary>
        /// Constructor publico.
        /// </summary>
        /// <param name="espacioDisponible">Cantidad de productos permitidos</param>
        public Changuito(int espacioDisponible) :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns>string con todos los productos del changuito</returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista.
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto p in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (p.GetType() == typeof(Snacks))
                            sb.AppendLine(p.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (p.GetType() == typeof(Dulce))
                            sb.AppendLine(p.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (p.GetType() == typeof(Leche))
                            sb.AppendLine(p.Mostrar());
                        break;
                    default:
                        sb.AppendLine(p.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista.
        /// </summary>
        /// <param name="c">Changuito donde se agregará el elemento</param>
        /// <param name="p">producto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                    return c;
            }
            if(c.espacioDisponible > c.productos.Count)
            c.productos.Add(p);

            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">changuito donde se quitará el elemento</param>
        /// <param name="p">producto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            bool existe = false;
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    existe = true;
                    break;
                }
            }
            if (existe)
                c.productos.Remove(p);

            return c;
        }
        #endregion
    }
}
