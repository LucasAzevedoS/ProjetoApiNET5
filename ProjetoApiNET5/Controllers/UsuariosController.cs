using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoApiNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet("get-usuarios")]
        public List<usuarios> GetUsuarios()
        {
            var query = @"select * from usuarios";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<usuarios>(query).ToList();

                return resp;
            }
        }

        [HttpGet("get-usuarios-id/{id}")]
        public usuarios GetUsuariosId(int id)
        {   
            var query = @"select * from usuarios where id = @Id ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<usuarios>(query, new { Id = id }).FirstOrDefault();

                return resp;
            }
        }

        [HttpPost("post-usuarios")]
        public void PostUsuarios(usuarios usuarios)
        {
            var query = @"insert into usuarios values(@Nome, @Email, @Idade, getdate())";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                conn.Query(query, new 
                {
                    Nome = usuarios.nome,
                    Email = usuarios.email,
                    Idade = usuarios.idade
                }).FirstOrDefault();
            }
        }

        [HttpPut("post-usuarios")]
        public void PutUsuarios(usuarios usuarios)
        {
            var query = @"update usuarios set
	                        nome = @Nomee,
	                        email = @Email,
	                        idade = @Idade,
                            dt_cadastro = @Data
                    where id = @Id ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                conn.Query(query, new
                {
                    Id = usuarios.Id,
                    Nome = usuarios.nome,
                    Email = usuarios.email,
                    Idade = usuarios.idade,
                    Data = usuarios.dt_cadastro
                }).FirstOrDefault();
            }
        }



    }
}
