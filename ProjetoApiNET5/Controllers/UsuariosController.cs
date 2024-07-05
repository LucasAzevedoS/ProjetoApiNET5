using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoApiNET5.Models;
using ProjetoApiNET5.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoApiNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuariosServices _usuariosServices = new UsuariosServices();

        [HttpGet("get-usuarios")]
        public List<usuarios> GetUsuarios()
        {
            return _usuariosServices.GetUsuarios();
        }

        [HttpGet("get-usuarios-id/{id}")]
        public usuarios GetUsuariosId(int id)
        {
            return _usuariosServices.GetUsuariosId(id);
        }

        [HttpPost("post-usuarios")]
        public void PostUsuarios(usuarios usuarios)
        {
            _usuariosServices.PostUsuarios(usuarios);
        }

        [HttpPut("put-usuarios")]
        public void PutUsuarios(usuarios usuarios)
        {
            _usuariosServices.PutUsuarios(usuarios);
        }

        [HttpDelete("delete-usuarios-id/{id}")]
        public usuarios DeleteUsuariosId(int id)
        {
            return  _usuariosServices.DeleteUsuariosId(id);
        }
    }
}
