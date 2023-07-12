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
using System.Windows.Threading;
using MySql.Data;
namespace CookieClic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CookieManager cookieManager = new CookieManager();
     


        DispatcherTimer timer = new DispatcherTimer();
        public bool timer_encendido = false;
        double nuevoIntervalo = 0.0f;
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = cookieManager;

            //Mostrar Pantalla de Login/Registro
            sp_Bienvenida.Visibility = Visibility.Visible;
            sp_Login.Visibility = Visibility.Visible;
        }

        void Galleta_Click(object sender, RoutedEventArgs e)
        {
            cookieManager.GalletasActuales++;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            cookieManager.GalletasActuales++;
        }

        private void ComprarAutoClick_Click(object sender, RoutedEventArgs e)
        {
            if (cookieManager.GalletasActuales >= cookieManager.ListaEdificios[0].Precio)
            {
                cookieManager.AddAutoCursor();
            }
            else
            {
                MessageBox.Show("No tienes galletas suficientes para comprar este objeto");
            }

            ActualizarIntervaloTick();

        }
        private void ComprarAbuela_Click(object sender, RoutedEventArgs e)
        {
            if (cookieManager.GalletasActuales >= cookieManager.ListaEdificios[1].Precio)
            {
                cookieManager.AddAbuela();
            }
            else
            {
                MessageBox.Show("No tienes galletas suficientes para comprar este objeto");
            }

            ActualizarIntervaloTick();

        }
        public void ActualizarIntervaloTick()
        {
            nuevoIntervalo = 0.0f;
            if (cookieManager.ListaEdificios[0].Cantidad > 0) //AutoClickers
            {
                nuevoIntervalo += 0.1f * cookieManager.ListaEdificios[0].Cantidad;
            }
            if (cookieManager.ListaEdificios[1].Cantidad > 0) //Abuelas
            {
                nuevoIntervalo += 2 * cookieManager.ListaEdificios[1].Cantidad;
            }
            if (!timer_encendido)
            {
                timer.Tick += timer_Tick;
                timer.Start();
                timer_encendido = true;
            }
           
            timer.Interval = TimeSpan.FromSeconds(1/nuevoIntervalo);

        }

        private void Button_LLamarPA_Click(object sender, RoutedEventArgs e)
        {
            cookieManager.accesoDatos.LlamarPARegistrar(tb_usu.Text, tb_contra.Text);
        }

        private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            sp_Bienvenida.Visibility = Visibility.Collapsed;
            sp_Login.Visibility = Visibility.Collapsed;
            sp_Registro.Visibility = Visibility.Visible;
        }
        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            sp_Bienvenida.Visibility = Visibility.Visible;
            sp_Login.Visibility = Visibility.Visible;
            sp_Registro.Visibility = Visibility.Collapsed;
        }

        private void AltaNueva_Click(object sender, RoutedEventArgs e)
        {
            int resultado = cookieManager.AltaUsuario(tb_NuevoUsu.Text,tb_NuevaPass.Password);
            if (resultado == 0)
            {
                cookieManager.UsuarioActual = tb_NuevoUsu.Text;
                PantallaPrincipal();
            }
            else if(resultado == -1)
            {
                MessageBox.Show("Usuario o Contraseña vacíos");
            }
            else if (resultado == -2)
            {
                MessageBox.Show("El usuario ya existe");
            }
            else
            {
                MessageBox.Show("Error no tenido en cuenta");
            }
        }
        public void PantallaPrincipal()
        {
            sp_Bienvenida.Visibility = Visibility.Collapsed;
            sp_Login.Visibility = Visibility.Collapsed;
            sp_Registro.Visibility = Visibility.Collapsed;

            sp_usuarioActual.Visibility = Visibility.Visible;
            sp_GalletasActuales.Visibility = Visibility.Visible;
            sp_Galleta.Visibility = Visibility.Visible;
            sp_TituloTienda.Visibility = Visibility.Visible;
            sp_Edificios.Visibility = Visibility.Visible;
        }
        public void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            sp_usuarioActual.Visibility = Visibility.Collapsed;
            sp_GalletasActuales.Visibility = Visibility.Collapsed;
            sp_Galleta.Visibility = Visibility.Collapsed;
            sp_TituloTienda.Visibility = Visibility.Collapsed;
            sp_Edificios.Visibility = Visibility.Collapsed;

            sp_Bienvenida.Visibility = Visibility.Visible;
            sp_Login.Visibility = Visibility.Visible;

            cookieManager.UsuarioActual = "";
        }

    }
}
