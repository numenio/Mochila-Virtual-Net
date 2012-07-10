using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Voz;

namespace mochila
{
    /// <summary>
    /// Lógica de interacción para Ventana.xaml
    /// </summary>
    public partial class Ventana : Window
    {
        voz miVoz = new voz();

        public Ventana()
        {
            InitializeComponent();
        }

        public void cerrarVentana()
        {
            voz.hablar("cerrando el programa");
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.cerrarVentana();
        }
    }
}
