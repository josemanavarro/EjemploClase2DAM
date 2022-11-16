using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploClase2DAM.dto
{
    public class Reserva : INotifyPropertyChanged
    {
        private string aula;
        public string Aula { 
            get
            {
                return aula;
            }
            set
            {
                this.aula = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Aula"));

            }
        }

        private string profesor;
        public string Profesor
        {
            get
            {
                return profesor;
            }
            set
            {
                this.profesor = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Profesor"));
            }
        }

        private int alumnos;
        public int Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                this.alumnos = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Alumnos"));
            }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                this.fecha = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Fecha"));
            }
        }

        public Reserva()
        {
            this.fecha = System.DateTime.Now;
        }

        public Reserva(string aula, string profesor, int alumnos, DateTime fecha)
        {
            // No uso el público para no notificar a la interfaz, al no estar en la tabla no es necesario.
            this.aula = aula;
            this.profesor = profesor;            
            this.alumnos = alumnos;
            this.fecha = fecha;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
