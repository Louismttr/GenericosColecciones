using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjControlRegistroLibros
{
    public partial class fmrLibros : Form
    {
        static int contador;
        public fmrLibros()
        {
            InitializeComponent();
        }

        private void fmrLibros_Load(object sender, EventArgs e)
        {
            lblNumero.Text = GenerarNumero();
        }

        //Implementación de expresiones Lambda
        Func<string> GenerarNumero = () =>
         {
             contador++;
             return contador.ToString("00000");
         };

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (Valida() == " ")
            {
                //Capturando elementos
                double costo = getCosto();
                string categoria = getCategoria();
                double descuento = AsignaDescuento(categoria, costo);
                double precioVenta = CalculaPrecioVenta(costo, descuento);

                //Imprimir registro
                ImprimirRegistro(descuento, precioVenta);
            }
            else
                MessageBox.Show("El error se encunetra en " + Valida());
        }

        private void ImprimirRegistro(double descuento, double precioVenta)
        {
            ListViewItem fila= new ListViewItem(getNumero().ToString());
            fila.SubItems.Add(getTitulo());
            fila.SubItems.Add(getCategoria());
            fila.SubItems.Add(getCosto().ToString("0.00"));
            fila.SubItems.Add(descuento.ToString("0.00"));
            fila.SubItems.Add(precioVenta.ToString("0.00"));
            lvLibros.Items.Add(fila);

        }

        Func<string, double, double> AsignaDescuento = (categoria, costo) =>
         {
             double descuento = 0;
             switch(categoria)
             {
                 case "Gestión": descuento= (10.0/100) * costo; break;
                 case "Ingenieríá": descuento= (20.00/100)*costo; break;
                 case "Base de Datos": descuento=(15.0/100)*costo; break;
             }
             return descuento;
         };

        Func<double, double, double> CalculaPrecioVenta = (costo, descuento) => costo - descuento;

        //MEtodos de captura
        private string getTitulo()
        {
            return txtTitulo.Text;
        }
        private int getNumero()
        {
            return int.Parse(lblNumero.Text);
        }

        private string getCategoria()
        {
            return cboCategoria.Text;
        }

        private double getCosto()
        {
            return double.Parse(txtCosto.Text);
        }

        //metodod de validacion de ingresos de datos
        private string Valida()
        {
            if(txtTitulo.Text.Trim().Length==0)
            {
                txtTitulo.Focus();
                return "Título del libro";
            }
            else if(cboCategoria.SelectedIndex == -1)
            {
                cboCategoria.Focus();
                return "Categoría del libro";
            }
            else if(txtTitulo.Text.Trim().Length==0)
            {
                txtCosto.Focus();
                return "Costo del libro";
            }
            return " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            txtCosto.Clear();
            cboCategoria.SelectedIndex = -1;
            txtTitulo.Focus();
          
        }
    }
}
