using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoApiNET5.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoApiNET5.Repository
{
    public class UsuarioRepository
    {

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


        public void PutUsuarios(usuarios usuarios)
        {
            var query = @"update usuarios set
	                        nome = @Nome,
	                        email = @Email,
	                        idade = @Idade
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

                }).FirstOrDefault();
            }
        }


        public usuarios DeleteUsuariosId(int id)
        {
            var query = @"delete from usuarios where id = @Id ";

            using (var conn = new SqlConnection("Server=PC-LUCAS; Database=BANCO01; User Id=sa; Password=Lucas30092004;"))
            {
                conn.Open();

                var resp = conn.Query<usuarios>(query, new { Id = id }).FirstOrDefault();

                return resp;
            }
        }
        }
}
