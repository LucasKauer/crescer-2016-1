using AulaReforcoAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaReforcoAuth.Services
{
    public static class ServicoSessao
    {
        public static string ImagemDeFundo
        {
            get
            {
                return HttpContext.Current.Session["IMAGEM_FUNDO"].ToString();
            }
        }

        public static void CriarSessao(UsuarioLogadoModel usuario)
        {
            UsuarioLogado = usuario;
        }

        public static void Sair()
        {
            HttpContext.Current.Session.Abandon();
        }
        
        public static UsuarioLogadoModel UsuarioLogado
        {
            get
            {
                return (UsuarioLogadoModel)HttpContext.Current.Session["USUARIO_LOGADO"];
            }
            private set
            {
                HttpContext.Current.Session["USUARIO_LOGADO"] = value;
            }
        }

        public static bool EstaLogado
        {
            get
            {
                return UsuarioLogado != null;
            }
        }
    }
}