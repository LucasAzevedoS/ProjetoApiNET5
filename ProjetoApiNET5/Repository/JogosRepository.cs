using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoApiNET5.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoApiNET5.Repository
{
    public class JogosRepository
    {
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


        public void PutJogos(jogos jogos)
        {
            var query = @"alterar_jogo @Id, @Id_usuario, @Nome, @Avalicacao, @Status";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                conn.Query(query, new
                {
                    Id = jogos.Id,
                    Id_usuario = jogos.Id_usuario,
                    Nome = jogos.nome,
                    Avalicacao = jogos.avalicacao,
                    Status = jogos.status,
                }).FirstOrDefault();
            }
        }


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


        public List<UsuarioJogo> GetUsuarioJogo(int usuario_id)
        {
            var query = @"buscar_usuario_jogo @Id  ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<UsuarioJogo>(query, new { Id = usuario_id }).ToList();

                return resp;
            }
        }
    }
}
