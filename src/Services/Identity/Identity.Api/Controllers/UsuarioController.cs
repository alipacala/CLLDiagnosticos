﻿using Identity.Service.Queries;
using Identity.Service.Queries.DTOs;
using Identity.Service.Queries.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioQueryService UsuarioQueryService;

        public UsuarioController(
            IUsuarioQueryService usuarioQueryService)
        {
            UsuarioQueryService = usuarioQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<UsuarioDto>> GetAll(
            int page = 1,
            int take = 10,
            string ids = null)
        {
            IEnumerable<string> users = ids?.Split(',');
            return await UsuarioQueryService.GetAllAsync(page, take, users);
        }

        [AllowAnonymous]
        [HttpGet("{username}")]
        public async Task<Result> Get(string username)
        {
            return await UsuarioQueryService.GetAsync(username);
        }
    }
}
