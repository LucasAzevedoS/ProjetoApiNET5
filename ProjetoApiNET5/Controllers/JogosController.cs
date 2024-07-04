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
    public class JogosController : ControllerBase
    {
        [HttpGet("get-jogos")]
        public List<jogos> GetJogos()
        {
            var query = @"buscar_jogos";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<jogos>(query).ToList();

                return resp;
            }
        }

        [HttpGet("get-jogo-id/{id}")]
        public jogos GetJogoId(int id)
        {
            var query = @"buscar_jogos_id @Id";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<jogos>(query, new { Id = id }).FirstOrDefault();

                return resp;
            }
        }

        [HttpPost("post-jogos")]
        public void Postjogos(jogos jogos)
        {
            var query = @"criar_jogo @Id_usuario, @Nome, @Avalicacao, @Status ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                conn.Query(query, new
                {
                    Id_usuario = jogos.Id_usuario,
                    Nome = jogos.nome,
                    Avalicacao = jogos.avalicacao,
                    Status = jogos.status
                }).FirstOrDefault();
            }
        }

        [HttpPut("put-jogos")]
        public void PutJogos(jogos jogos)
        {
            var query = @"alterar_jogo @Id, @Id_usuario, @Nome, @Avalicacao, @Status";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                conn.Query(query, new
                {   
                    Id= jogos.Id,
                    Id_usuario = jogos.Id_usuario,
                    Nome = jogos.nome,
                    Avalicacao = jogos.avalicacao,
                    Status = jogos.status,
                }).FirstOrDefault();
            }
        }

        [HttpDelete("delete-jogos-id/{id}")]
        public jogos DeleteJogosId(int id)
        {
            var query = @"deletar_jogo @Id  ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<jogos>(query, new { Id = id }).FirstOrDefault();

                return resp;
            }
        }
    }
}
