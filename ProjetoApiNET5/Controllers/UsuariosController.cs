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
        public List<usuarios> GetUsuariosId(int id)
        {   
            var query = @"select * from usuarios where id = @Id ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<usuarios>(query, new { Id = id }).ToList();

                return resp;
            }
        }

        [HttpGet("get-jogos")]
        public List<jogos> GetJogos()
        {
            var query = @"select * from jogos";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<jogos>(query).ToList();

                return resp;
            }
        }



    }
}
