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
    /// Lógica de interacción para Jornada.xaml
    /// </summary>
    public partial class Jornada : UserControl
    {
        public event EventHandler TimeUpdated;
        public event EventHandler Click;
        public Jornada()
        {
            InitializeComponent();
            tInicio.TimeUpdated += PonResultado;
            tFin.TimeUpdated += PonResultado;
        }

        private void PonResultado(object sender, EventArgs e)
        {
           try
            {
                if (Correct)
                {
                    tblTiempoHecho.Text = Total.ToString();
                    if (TimeUpdated != null)
                        TimeUpdated(this, new EventArgs());
                }
            }catch(Exception ex) {

            }
        }

        public TimeSpan Total
        {
            get { return tFin.Hora - tInicio.Hora; }
        }
        public bool Correct
        {
            get { return tInicio.Hora < tFin.Hora; }
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Click != null)
                Click(this, new EventArgs());
        }
    }
}
