﻿using Api.Gateway.Models.Clientes.Common;

namespace Api.Gateway.Models.Clientes.DTOs
{
    public class PacienteDto
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
