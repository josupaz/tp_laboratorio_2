using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa cmbOperador, setea por defecto el operador ( + )
        /// e inhabilita los botones convertir a binario y convertir a decimal
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            String[] operadores = {"+","-","*","/" };
            foreach (string oper in operadores)// Cargo cmbOperador con los operadores correspondientes
            {
                cmbOperador.Items.Add(oper);
            }
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperador.SelectedItem=("+");
            lblResultado.Text = "";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
        #region metodos
        /// <summary>
        /// Recibe por parametro 2 datos de tipo string, y un operador de tipo string
        /// devuelve el resultado del primer operando por el segundo.
        /// </summary>
        /// <param name="numero1">dato de tipo string, 1er operando</param>
        /// <param name="numero2">dato de tipo string, 2do operando</param>
        /// <param name="operador">dato de tipo string, operador</param>
        /// <returns>devuelve el valor minimo de dato double,
        /// si los operandos son diferente de null y el operador es ( + - * )
        /// o siempre que el operador sea ( / ), el 2do operando es > a 0
        /// devuelve el resultado del primer operando por el segundo.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }
        /// <summary>
        /// Borra el contenido de lblResultado, txtNumero1/2 e inhabilita los botones convertir a binario y convertir a decimal.
        /// </summary>
        private void Limpiar()
        {

            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
        #endregion
        #region botones
        /// <summary>
        /// Obtiene los datos ingresados por el usuario y realiza una operacion,
        /// si la puede realizar escribe en lblResultado, el resultado
        /// de forma contraria arroja mensaje con error correspondiente en lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = resultado.ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;

        }
        /// <summary>
        /// Limpia el formulario, invocando a metodo Limpiar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Convierte binario en decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            if (lblResultado.Text.Equals("Valor invalido"))
                btnConvertirABinario.Enabled = false;

            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Convierte decimal en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
              
              lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
              if (lblResultado.Text.Equals("Valor invalido"))
                     btnConvertirADecimal.Enabled = false;

              btnConvertirABinario.Enabled = false;

        }
        #endregion
    }
}
