﻿namespace AdministracionColegio.Models
{
    public class Grado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
