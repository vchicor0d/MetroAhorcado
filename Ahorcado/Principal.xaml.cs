using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ahorcado
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage : Page
    {
        public BlankPage()
        {
            this.InitializeComponent();
            bmi = new BitmapImage();
        }

        private String palabra;
        private int fallos;
        private int puntos;
        private List<String> letras;
        private BitmapImage bmi;

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnJ1_Click(object sender, RoutedEventArgs e)
        {
            barra.IsOpen = false;
            palabra = Palabra.getPalabra();
            fallos = 0;
            tbPalabra.Text = "";
            txtLetra.Text = "";
            tbUsadas.Text = "";
            puntos = 0;
            letras= new List<String>();
            btnResolver.Visibility = Windows.UI.Xaml.Visibility.Visible;
            bmi.UriSource = new Uri("ms-appx:/img/0.png", UriKind.Absolute);
            imgAhorcado.Source = bmi;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (i < palabra.Length - 1) tbPalabra.Text = tbPalabra.Text + "_ ";
                else tbPalabra.Text = tbPalabra.Text + "_";
            }
            txtLetra.IsEnabled = true;
            txtLetra.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        private void buscaletra()
        {
            if (palabra.IndexOf(txtLetra.Text.ToCharArray()[0]) != -1)
            {
                letras.Add(txtLetra.Text);
                String pal = "";
                Boolean acierto;
                for (int i = 0; i < palabra.Length; i++)
                {
                    acierto = false;
                    for (int j = 0; j < letras.Count && !acierto; j++)
                    {
                        if (palabra.Substring(i, 1).Equals(letras[j]))
                        {
                            pal = pal + letras[j];
                            acierto = true;
                        }
                    }
                    if (!acierto) pal = pal + "_";
                    if (i < palabra.Length - 1) pal = pal + " ";
                }
                tbPalabra.Text = pal;
                txtLetra.Text = "";
                if (comprueba())
                {
                    tbMensaje.Text = "¡Has ganado!";
                    popupfin.IsOpen = true;
                    txtLetra.IsEnabled = false;
                    btnResolver.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
            else
            {
                fallos++;
                tbUsadas.Text = tbUsadas.Text + txtLetra.Text+" ";
                String url = "ms-appx:/img/" + fallos + ".png";
                bmi.UriSource = new Uri(url, UriKind.Absolute);
                imgAhorcado.Source = bmi;
                if (fallos == 6)
                {
                    tbMensaje.Text = "Has perdido, la palabra era "+palabra.ToLower();
                    popupfin.IsOpen = true;
                    txtLetra.IsEnabled = false;
                    btnResolver.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
        }

        private Boolean comprueba()
        {
            String pal = "";
            for (int i = 0; i < tbPalabra.Text.Length; i++)
            {
                if (!tbPalabra.Text.Substring(i, 1).Equals(" ")) pal = pal + tbPalabra.Text.Substring(i, 1);
            }
            if (pal.Equals(palabra)) return true;
            else return false;
        }

        private void txtLetra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Back || e.Key == Windows.System.VirtualKey.Delete) txtLetra.Text = "";
            if (txtLetra.Text.Length == 1)
            {
                if (e.Key != Windows.System.VirtualKey.Enter) e.Handled = true;
                else
                {
                    buscaletra();
                    txtLetra.Text = "";
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
                if (Char.IsLetter(e.Key.ToString(),0) && e.Key.ToString().Length==1) txtLetra.Text = e.Key.ToString().ToUpper();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            popupfin.IsOpen = false;
        }

        private void btnResolver_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

