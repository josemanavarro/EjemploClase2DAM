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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EjemploClase2DAM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogicaReservas logicaReservas;

        public MainWindow()
        {
            InitializeComponent();
            logicaReservas = new LogicaReservas();            
            dataGridReservas.DataContext = logicaReservas;
        }

        private void MenuItem_Click_Nuevo(object sender, RoutedEventArgs e)
        {
            DialogoReserva reserva = new DialogoReserva(logicaReservas);
            reserva.Show();
        }

        private void MenuItem_Click_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            DialogoReserva reserva = new DialogoReserva(logicaReservas,(Reserva)dataGridReservas.SelectedItem,dataGridReservas.SelectedIndex);
            reserva.Show();
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            logicaReservas.eliminarRserva(dataGridReservas.SelectedIndex);
        }
    }
}
