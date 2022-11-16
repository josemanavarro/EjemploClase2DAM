using EjemploClase2DAM.dto;
using EjemploClase2DAM.logica;
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
using System.Windows.Shapes;

namespace EjemploClase2DAM
{
    /// <summary>
    /// Lógica de interacción para DialogoReserva.xaml
    /// </summary>
    public partial class DialogoReserva : Window
    {
        private Reserva reserva;
        private int posicion;
        private bool modificar;
        private LogicaReservas reservas;

        public DialogoReserva(LogicaReservas reservas)
        {
            InitializeComponent();
            this.modificar = false;
            this.reservas = reservas;
            this.reserva= new Reserva();
            this.DataContext = this.reserva;            
        }

        public DialogoReserva(LogicaReservas reservas, Reserva reserva, int posicion)
        {
            InitializeComponent();
            this.modificar = true;
            this.reservas = reservas;
            this.reserva = reserva;
            this.DataContext = this.reserva;
            this.posicion = posicion;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (modificar)
                reservas.modificarReserva(this.reserva,this.posicion);
            else
                reservas.addReserva(this.reserva);
            this.Close();
        }
    }
}
