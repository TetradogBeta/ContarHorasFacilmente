using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContarHorasFacilmente
{
    /// <summary>
    /// Lógica de interacción para Time.xaml
    /// </summary>
    public partial class Time : UserControl
    {
        public event EventHandler TimeUpdated;
        public Time()
        {
            InitializeComponent();
            txbHoras.Text = "0";
            txbMinutos.Text = "0";
            txbHoras.TextChanged += SeHaCambiadoElTiempo;
            txbMinutos.TextChanged += SeHaCambiadoElTiempo;
        }

        private void SeHaCambiadoElTiempo(object sender, TextChangedEventArgs e)
        {
            int result;
            if (int.TryParse(((TextBox)sender).Text, out result))
                if (TimeUpdated != null)
                    TimeUpdated(this, new EventArgs());
        }

        public DateTime Hora
        {
            get {
                int horas = int.Parse(txbHoras.Text);
                int minutos = int.Parse(txbMinutos.Text);
                return new DateTime(2017, 1, 1, horas, minutos, 0);
            }
        }
    }
}
