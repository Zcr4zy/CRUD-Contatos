using CRUD_Contatos.Data;
using CRUD_Contatos.Models;
using CRUD_Contatos.Repositorios.Contato;

namespace CRUD_Contatos.Repositorios
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly Contexto _contexto;

        public ContatoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }


        public List<ContatoModel> ListarContatos()
        {
            var contato = _contexto.Contatos.ToList();
            return contato;
        }


        public ContatoModel CriarContato(ContatoModel contato)
        {
            contato.DataCriacao = DateTime.Now;
            _contexto.Contatos.Add(contato);
            _contexto.SaveChanges();
            return contato;
        }

        public ContatoModel BuscaPorId(int id)
        {
            ContatoModel contatoDB = _contexto.Contatos.FirstOrDefault(c => c.Id == id);
            return contatoDB;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscaPorId(contato.Id);

            contatoDB.Nome = contato.Nome;
            contatoDB.Celular = contato.Celular;
            contatoDB.Email = contato.Email;
            contatoDB.Endereco = contato.Endereco;
            contatoDB.DataModificacao = DateTime.Now;

            _contexto.Contatos.Update(contatoDB);
            _contexto.SaveChanges();
            return contatoDB;

        }

        public ContatoModel DeletarConfirmacao(int id)
        {
            ContatoModel contatoDB = BuscaPorId(id);
            return contatoDB;
        }

        public bool Deletar(int id)
        {
            ContatoModel contatoDB = BuscaPorId(id);

            _contexto.Contatos.Remove(contatoDB);
            _contexto.SaveChanges();
            return true;
        }

    }
}
