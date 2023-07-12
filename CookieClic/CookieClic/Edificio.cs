using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CookieClic
{
    public class Edificio : INotifyPropertyChanged
    {
        //Campos
        private string _nombre;
        private int _cantidad;
        private double _precio;
        private int _galletasEdificio;

        //Propiedades
        public string Nombre {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                _cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }
        public double Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
                OnPropertyChanged("Precio");
            }
        }
        public int GalletasEdificio
        {
            get
            {
                return _galletasEdificio;
            }
            set
            {
                _galletasEdificio = value;
            }
        }
        //Constructor
        public Edificio(string nombreEdificio, double precioEdificio)
        {
            Nombre = nombreEdificio;
            Precio = precioEdificio;
            Cantidad = 0;
        }
        //Pieza para que funcionen los BINDINGS
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
