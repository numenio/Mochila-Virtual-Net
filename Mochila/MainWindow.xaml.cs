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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mochila
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int posiciónEnPalabra = 0;
        string palabra;

        public MainWindow()
        {
            InitializeComponent();
            
            //    palabra = "hola";
            //    textBlock1.Text = palabra;
            //    List<string> nombres = new List<string>();
            //    nombres.Add("Juan");
            //    nombres.Add("Pedro");
            //    nombres.Add("José");
            //    nombres.Add("Marías");

            //    IEnumerable<string> result = nombres.Where(a => a.Length > 4)
            //                                        .OrderBy(a => a.Length)
            //                                        .Select(b => b.ToUpper());
            //    string av = result.ToString();


            //    double[] pixels = new[] { 3.0, 4.0, 6.0, 5.0, 7.0, 7.0, 6.0, 7.0, 8.0, 9.0 };



            //    IEnumerable<double> query1 =
            //        pixels.Select(
            //            p =>
            //            {
            //                if (p > 5.0)
            //                    return Limit((p - 5.0) * 1.5 + 5.0);
            //                else
            //                    return Limit(5.0 - (5.0 - p) * 1.5);
            //            }
            //        ).Select(p => Limit(p + 1.2));

            //    query1.ToString();

            //    delegado z = new delegado(borrame2); //los parámetros de borrame2 se pasan en la función que hace uso del delegado (borrame)

            //    borrame(2, borrame2);

            //    delegado y = (x, u) => x * u;
            //    borrame(3, y);

            //    var people = new[] {
            //        new { Name = "Bob", Age = 3 },
            //        new { Name = "Bill", Age = 3 },
            //        new { Name = "Mary", Age = 4 },
            //        new { Name = "June", Age = 3 },
            //        new { Name = "Nancy", Age = 4 },
            //        new { Name = "Shelly", Age = 4 },
            //        new { Name = "Cheryl", Age = 3 },
            //        new { Name = "Joe", Age = 3 }
            //    };

            //    var resultado = people.GroupBy(s => s.Age);

            //    //var nombres = new[] { "hola", "fer", "cómo", "estás" };


            //}

            //int borrame2(int a, int b)
            //{
            //    return a + b;
            //}

            //delegate int delegado(int a, int b);

            //void borrame(int a, delegado b)
            //{
            //    int z = a * b(a, a);
            //}

            //private static double Limit(double pixel)
            //{
            //    if (pixel > 10.0)
            //        return 10.0;
            //    if (pixel < 0.0)
            //        return 0.0;
            //    return pixel;
            //}

            //private void button1_Click(object sender, RoutedEventArgs e)
            //{
            //    Window  ventana = new Window1();
            //    ventana.ShowDialog();
            //}

            //private void Window_KeyDown(object sender, KeyEventArgs e)
            //{
            //    //string letra = obtenerLetraActual().ToLower();
            //    //if (e.Key.ToString().ToLower() == letra)
            //    //{
            //    //    TextEffectCollection colecciónEfectos = new TextEffectCollection();
            //    //    TextEffect efecto = new TextEffect();
            //    //    efecto.PositionStart = posiciónEnPalabra;
            //    //    efecto.PositionCount = 1;

            //    //    Thickness márgenesTexto = textBlock1.Margin;
            //    //    Thickness márgenesVentana = this.Margin;
            //    //    ScaleTransform transformación = new ScaleTransform(2, 2, márgenesTexto.Left, márgenesTexto.Top);


            //    //    //efecto.Transform = transformación;
            //    //    efecto.Foreground = Brushes.Yellow;

            //    //    colecciónEfectos.Add(efecto);
            //    //    textBlock1.TextEffects = colecciónEfectos;




            //    //    if (posiciónEnPalabra == palabra.Length)
            //    //        posiciónEnPalabra = 0;
            //    //    else
            //    //        posiciónEnPalabra++;
            //    //}
            //}

            ////string obtenerLetraActual()
            ////{
            ////    return palabra.Substring(posiciónEnPalabra, 1);
            ////}
        }
    }
}
