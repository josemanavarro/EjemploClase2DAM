using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploClase2DAM.dto
{
    public class Reserva : INotifyPropertyChanged, ICloneable, IDataErrorInfo
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

        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get {
                string result = "";
                if (columnName == "Aula") { 
                    if (string.IsNullOrEmpty(this.aula))
                    {
                        result = "El campo aula no debe estar vacio";
                    }
                }
                if (columnName == "Profesor")
                {
                    if (string.IsNullOrEmpty(this.profesor))
                    {
                        result = "El campo profesor no debe estar vacio";
                    }
                }
                if (columnName == "Alumnos")
                {
                    if (this.alumnos <= 0)
                    {
                        result = "El campo aula no debe ser menor o igual que cero";
                    }
                }
                return result;
            }
        }
    }
}
