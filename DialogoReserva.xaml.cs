using EjemploClase2DAM.dto;
using EjemploClase2DAM.logica;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private int errores;

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

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)            
                errores++;
            else
                errores--;

            if (errores == 0)
                this.ButtonAceptar.IsEnabled = true;
            else
                this.ButtonAceptar.IsEnabled = false;

        }

        private void TextBoxAula_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxAula.Text))
            {
                MessageBox.Show("Debes completar el campo aula", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TextBoxProfesor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxProfesor.Text))
            {
                MessageBox.Show("Debes completar el campo profesor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TextBoxAlumnos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(TextBoxAlumnos.Text)<=0)
            {
                MessageBox.Show("El número de alumnos no puede ser menor o igual a cero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
