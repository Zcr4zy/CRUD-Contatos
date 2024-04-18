using CRUD_Contatos.Models;

namespace CRUD_Contatos.Repositorios.Contato
{
    public interface IContatoRepository
    {
        List<ContatoModel> ListarContatos();

        ContatoModel CriarContato(ContatoModel contato);

        ContatoModel BuscaPorId(int id);

        ContatoModel Atualizar(ContatoModel contato);

        ContatoModel DeletarConfirmacao(int id);

        bool Deletar(int id);

    }
}
