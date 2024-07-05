using Microsoft.AspNetCore.Mvc;
using ProjetoApiNET5.Models;
using ProjetoApiNET5.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoApiNET5.Services
{
    public class JogosServices
    {
        JogosRepository _jogosRepository = new JogosRepository();

        public List<jogos> GetJogos()
        {
            return _jogosRepository.GetJogos();
        }


        public jogos GetJogoId(int id)
        {
            return _jogosRepository.GetJogoId(id);
        }


        public void Postjogos(jogos jogos)
        {
             _jogosRepository.Postjogos(jogos);
        }


        public void PutJogos(jogos jogos)
        {
            _jogosRepository.PutJogos(jogos);
        }

        public jogos DeleteJogosId(int id)
        {
            return _jogosRepository.DeleteJogosId(id);
        }


        public List<UsuarioJogo> GetUsuarioJogo(int usuario_id)
        {
            return _jogosRepository.GetUsuarioJogo(usuario_id);
        }
    }
}
