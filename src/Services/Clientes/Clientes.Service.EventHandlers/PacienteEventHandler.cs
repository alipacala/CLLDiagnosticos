﻿using Clientes.Domain;
using Clientes.Persistence.Database;
using Clientes.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Service.EventHandlers
{
    public class PacienteEventHandler :
        INotificationHandler<PacienteCreateCommand>,
        INotificationHandler<PacienteUpdateContactInfoCommand>
    {
        private readonly ApplicationDbContext _context;

        public PacienteEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(PacienteCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Paciente {
                Usuario_Id = notification.Usuario_Id,
                Dni = notification.Dni,
                Nombres = notification.Nombres,
                Apellidos = notification.Apellidos,
                Sexo = notification.Sexo,
                FechaNacimiento = notification.FechaNacimiento,
                Region = notification.Region,
                Email = notification.Email,
                Celular = notification.Celular,
                Activo = notification.Activo
            });

            await _context.SaveChangesAsync();
        }

        public async Task Handle(PacienteUpdateContactInfoCommand notification, CancellationToken cancellationToken)
        {
            var originalPaciente =
                await _context.Pacientes
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id == notification.Id,
                        cancellationToken: cancellationToken);

            var updatedPaciente = new Paciente
            {
                Id = originalPaciente.Id,
                Usuario_Id = originalPaciente.Usuario_Id,
                Dni = originalPaciente.Dni,
                Nombres = originalPaciente.Nombres,
                Apellidos = originalPaciente.Apellidos,
                Sexo = originalPaciente.Sexo,
                FechaNacimiento = originalPaciente.FechaNacimiento,
                Region = originalPaciente.Region,
                Email = notification.Email,
                Celular = notification.Celular,
                Activo = originalPaciente.Activo
            };

            _context.Update(updatedPaciente);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
