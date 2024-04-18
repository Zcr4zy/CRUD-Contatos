using System;
using System.Collections.Generic;
using CRUD_Contatos.Models;
using System.Linq;

namespace CRUD_Contatos.Data
{
    public class PopularDados
    {
        private readonly Contexto _contexto;

        public PopularDados(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void PopularContatos()
        {
                var listaContato = new List<ContatoModel>
                {
                    new ContatoModel
                    {
                        Nome = "Zcr4zy",
                        Celular = "123456789",
                        Email = "zcr4zybr@gmail.com",
                        DataCriacao = DateTime.Now,
                        Endereco = "Disney"
                    },
                };

                _contexto.Contatos.AddRange(listaContato);
                _contexto.SaveChanges();
        }
    }
}
