﻿using ControleCustos.Dominio.Criptografia.Interface;
using ControleCustos.Dominio.Interface;

namespace ControleCustos.Dominio.UsuarioDominio.Classe
{
    public class UsuarioServico
    {
        private IServicoDeCriptografia servicoDeCriptografia;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IServicoDeCriptografia servicoDeCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoDeCriptografia = servicoDeCriptografia;
        }

        public Usuario BuscarPorAutenticacao(string email, string senha)
        {
            Usuario usuarioEncontrado = this.usuarioRepositorio.BuscarPorEmail(email);

            string senhaCriptografada = this.servicoDeCriptografia.Criptografar(senha);

            if (usuarioEncontrado != null && usuarioEncontrado.Senha.Equals(senhaCriptografada))
            {
                return usuarioEncontrado;
            }

            return null;
        }
    }
}