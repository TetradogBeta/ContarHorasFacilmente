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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Jornada> jornadas;
        public MainWindow()
        {
            jornadas = new List<Jornada>();
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            Jornada jornadaNueva = new Jornada();
            jornadaNueva.Click += QuitarJornada;
            jornadaNueva.TimeUpdated += ActualizaTiempoTotal;
            jornadas.Add(jornadaNueva);
            stkJornadas.Children.Add(jornadaNueva);
        }

        private void ActualizaTiempoTotal(object sender=null, EventArgs e=null)
        {
            TimeSpan timeTotal = new TimeSpan();
            for (int i = 0; i < jornadas.Count; i++)
                timeTotal += jornadas[i].Total;
            txtResultado.Text = timeTotal.ToString();
        }

        private void QuitarJornada(object sender, EventArgs e)
        {
            Jornada jornadaAQuitar;
           if(chkEliminarHaciendoClick.IsChecked.GetValueOrDefault())
            {
                jornadaAQuitar = (Jornada)sender;
                jornadas.Remove(jornadaAQuitar);
                stkJornadas.Children.Remove(jornadaAQuitar);
                ActualizaTiempoTotal();
            }
        }
    }
}
