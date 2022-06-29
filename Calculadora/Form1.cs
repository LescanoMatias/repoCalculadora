using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Principal : Form
    {
        double primerNumero;
        double segundoNumero;
        char operador;

        public Principal()
        {
            InitializeComponent();
        }

        private void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtDisplay.Text == "0")

                txtDisplay.Clear();

            txtDisplay.Text += boton.Text;
        }

        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            primerNumero = Convert.ToDouble(txtDisplay.Text);
            operador = Convert.ToChar(boton.Tag);

            switch (operador)
            {
                case '²':
                    primerNumero = Math.Pow(primerNumero, 2);
                    txtDisplay.Text = primerNumero.ToString();
                    break;
                case '√':
                    primerNumero = Math.Sqrt(primerNumero);
                    txtDisplay.Text = primerNumero.ToString();
                    break;
                default:
                    txtDisplay.Text = "0";
                    break;
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            segundoNumero = Convert.ToDouble(txtDisplay.Text);

            switch (operador)
            {
                case '+':
                    txtDisplay.Text = (primerNumero + segundoNumero).ToString();
                    primerNumero = Convert.ToDouble(txtDisplay.Text);
                    break;
                case '-':
                    txtDisplay.Text = (primerNumero - segundoNumero).ToString();
                    primerNumero = Convert.ToDouble(txtDisplay.Text);
                    break;
                case '÷':
                    if (txtDisplay.Text != "0")
                    {
                        txtDisplay.Text = (primerNumero / segundoNumero).ToString();
                        primerNumero = Convert.ToDouble(txtDisplay.Text);

                    }
                    else
                    {
                        MessageBox.Show("No se puede dividir por cero");
                    }
                    break;
                case 'X':
                    txtDisplay.Text = (primerNumero * segundoNumero).ToString();
                    primerNumero = Convert.ToDouble(txtDisplay.Text);
                    break;
            }
        }

        private void btnBorrarUno_Click(object sender, EventArgs e)
        {
            if (txtDisplay.TextLength > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.TextLength - 1);
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            primerNumero = 0;
            segundoNumero = 0;
            operador = '\0';
            txtDisplay.Text = "0";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.Text = "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btnMasMenos_Click(object sender, EventArgs e)
        {
            primerNumero = Convert.ToDouble(txtDisplay.Text);
            primerNumero *= -1;
            txtDisplay.Text = primerNumero.ToString();
        }
    }
}
