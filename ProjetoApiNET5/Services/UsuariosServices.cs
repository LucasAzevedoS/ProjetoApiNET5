using Microsoft.AspNetCore.Mvc;
using ProjetoApiNET5.Models;
using ProjetoApiNET5.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoApiNET5.Services
{
    public class UsuariosServices
    {
        UsuarioRepository _usuarioRepository = new UsuarioRepository();
        public List<usuarios> GetUsuarios()
        {
            return _usuarioRepository.GetUsuarios();
        }


        public usuarios GetUsuariosId(int id)
        {
            return _usuarioRepository.GetUsuariosId(id);
        }

        public void PostUsuarios(usuarios usuarios)
        {
            _usuarioRepository.PostUsuarios(usuarios);
        }


        public void PutUsuarios(usuarios usuarios)
        {
            _usuarioRepository.PutUsuarios(usuarios);
        }


        public usuarios DeleteUsuariosId(int id)
        {
            return _usuarioRepository.DeleteUsuariosId(id);
        }
    }
}
