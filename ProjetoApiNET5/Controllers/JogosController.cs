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
    public class JogosController : ControllerBase
    {
        JogosServices _jogosServices = new JogosServices();

        [HttpGet("get-jogos")]
        public List<jogos> GetJogos()
        {
            return _jogosServices.GetJogos();
        }

        [HttpGet("get-jogo-id/{id}")]
        public jogos GetJogoId(int id)
        {
            return _jogosServices.GetJogoId(id);
        }

        [HttpPost("post-jogos")]
        public void Postjogos(jogos jogos)
        {
            _jogosServices.Postjogos(jogos);
        }

        [HttpPut("put-jogos")]
        public void PutJogos(jogos jogos)
        {
            _jogosServices.PutJogos(jogos);
        }

        [HttpDelete("delete-jogos-id/{id}")]
        public jogos DeleteJogosId(int id)
        {
            return _jogosServices.DeleteJogosId(id);
        }

        [HttpGet("get-usuariojogo-id/{usuario_id}")]
        public List<UsuarioJogo> GetUsuarioJogo(int usuario_id)
        {
            return  _jogosServices.GetUsuarioJogo(usuario_id);
        }
    }
}
