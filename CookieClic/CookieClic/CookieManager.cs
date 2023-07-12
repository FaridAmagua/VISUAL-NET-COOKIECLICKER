using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CookieClic
{
    public class CookieManager : INotifyPropertyChanged
    {
        //Campos PRIVADOS
        private string _usuarioActual;
        private int _galletasActuales;
        private ObservableCollection<Edificio> _listaEdificios = new ObservableCollection<Edificio>();

        //Propiedades PUBLICAS
        public AccesoDatos accesoDatos = new AccesoDatos();
        public string UsuarioActual
        {
            get
            {
                return _usuarioActual;
            }
            set
            {
                _usuarioActual = value;
                OnPropertyChanged("UsuarioActual"); //Avisamos a la vista para que cambie
            }
        }
        public int GalletasActuales
        {
            get
            {
                return _galletasActuales;
            }
            set
            {
                _galletasActuales = value;
                OnPropertyChanged("GalletasActuales"); //Avisamos a la vista para que cambie
            }
        }
        
        //CONSTRUCTORES
        
        public ObservableCollection<Edificio> ListaEdificios
        {
            get
            {
                return _listaEdificios;
            }
            set
            {
                _listaEdificios = value;
                OnPropertyChanged("ListaEdificios");
            }
        }
        
        public CookieManager()
        {
            _galletasActuales = 0;
            ListaEdificios.Add(new Edificio("AutoClickers",15));
            ListaEdificios.Add(new Edificio("Abuelas Cocineras", 30));
        }
        //Métodos
        public void AddAutoCursor()
        {
            ListaEdificios[0].Cantidad++;

            GalletasActuales = (int) (GalletasActuales - ListaEdificios[0].Precio);
            ListaEdificios[0].Precio = ListaEdificios[0].Precio * 2;
        }
        public void AddAbuela()
        {
            ListaEdificios[1].Cantidad++;

            GalletasActuales = (int)(GalletasActuales - ListaEdificios[1].Precio);
            ListaEdificios[1].Precio = ListaEdificios[1].Precio * 2;
        }
        public int AltaUsuario(string usuario, string pass)
        {
            return accesoDatos.LlamarPARegistrar(usuario, pass);
        }

        //Pieza para que funcionen los BINDINGS
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
