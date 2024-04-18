using System.ComponentModel.DataAnnotations;

namespace CRUD_Contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome para o contato!")]
        public string Nome { get; set; }


        [Phone(ErrorMessage = "Insira um número celular válido!")]
        [Required(ErrorMessage = "Insira o celular do contato!")]
        public string Celular{ get; set;}


        [EmailAddress(ErrorMessage = "Insira um E-mail válido!")]
        [Required(ErrorMessage = "Insira o E-mail do contato!")]
        public string Email { get; set;}


        [Required(ErrorMessage = "Insira o endereço do contato!")]
        public string Endereco { get; set;}


        public DateTime DataCriacao { get; set;}


        public DateTime? DataModificacao { get; set;}
    }
}
