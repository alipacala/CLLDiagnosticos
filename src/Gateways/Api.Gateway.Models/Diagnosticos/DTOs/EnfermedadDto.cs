﻿namespace Api.Gateway.Models.Diagnosticos.DTOs
{
    public class EnfermedadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
    }
}