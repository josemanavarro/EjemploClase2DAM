using EjemploClase2DAM.dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploClase2DAM.logica
{
    public class LogicaReservas
    {
        public ObservableCollection<Reserva> listaReservas { get; set; }

        public LogicaReservas() {
            listaReservas = new ObservableCollection<Reserva>();
            listaReservas.Add(new Reserva("Aula Prueba","Profe Prueba",10,new DateTime(2022,11,12)));
        }
        public void addReserva(Reserva reserva)
        {
            listaReservas.Add(reserva);
        }
        public void modificarReserva(Reserva reserva, int posicion)
        {
            listaReservas[posicion] = reserva;
        }
        public void eliminarRserva(int posicion)
        {
            listaReservas.RemoveAt(posicion);
        }
    }
}
