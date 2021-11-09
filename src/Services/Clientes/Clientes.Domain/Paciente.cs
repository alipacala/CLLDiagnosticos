﻿using Clientes.Common;

namespace Clientes.Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Sexo Sexo { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public bool Activo { get; set; }
    }
}
