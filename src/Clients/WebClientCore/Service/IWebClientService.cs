﻿using Api.Gateway.Models;
using Api.Gateway.Models.Clientes.Commands;
using Api.Gateway.Models.Clientes.DTOs;
using Api.Gateway.Models.Diagnosticos.DTOs;
using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Models.Identity.DTOs;
using Api.Gateway.Models.Identity.Responses;
using Api.Gateway.Models.Personal.Commands;
using Api.Gateway.Models.Personal.DTOs;
using Refit;
using System.Threading.Tasks;

namespace WebClientCore.Service
{
    public interface IWebClientService
    {
        /* For auth porpuses */

        [Post("/identity/auth")]
        Task<ApiResponse<IdentityAccess>> Login(UsuarioLoginCommand usuarioLogin);

        [Post("/identity")]
        Task Signup(UsuarioCreateCommand usuarioCreate);

        [Get("/usuarios/{username}")]
        Task<ApiResponse<UsuarioDto>> GetUser(string username);

        [Post("/pacientes")]
        Task CreatePaciente(PacienteCreateCommand pacienteCreateCommand);

        /* With auth token */

        [Post("/identity/admin")]
        Task SignupAdmin(UsuarioAdminCreateCommand usuarioAdminCreate, [Authorize("Bearer")] string token);

        [Get("/admins")]
        Task<DataCollection<AdminDto>> GetAdmins([Authorize("Bearer")] string token, int take = 10, int page = 1, string dni = "");

        [Get("/admins/{id}")]
        Task<AdminDto> GetAdmin(int id, [Authorize("Bearer")] string token);

        [Post("/admins")]
        Task<IApiResponse> CreateAdmin(AdminCreateCommand adminCreate, [Authorize("Bearer")] string token);

        [Patch("/admins")]
        Task<IApiResponse> UpdateActivoAdmin(AdminUpdateActivoCommand adminUpdate, [Authorize("Bearer")] string token);

        [Delete("/admins")]
        Task DeleteAdmin([Body] AdminDeleteCommand adminDelete, [Authorize("Bearer")] string token);


        [Get("/diagnosticos")]
        Task<DataCollection<DiagnosticoDto>> GetDiagnosticos([Authorize("Bearer")] string token, int take = 30);

        [Get("/pacientes")]
        Task<DataCollection<PacienteDto>> GetPacientes([Authorize("Bearer")] string token, string usuarioId);
    }
}