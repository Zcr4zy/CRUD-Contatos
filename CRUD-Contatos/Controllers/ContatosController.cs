using CRUD_Contatos.Data;
using CRUD_Contatos.Models;
using CRUD_Contatos.Repositorios.Contato;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Contatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly Contexto _contexto;
        public ContatosController(IContatoRepository contatoRepository, Contexto contexto)
        {
            _contatoRepository = contatoRepository;
            _contexto = contexto;
        }


        public IActionResult Index()
        {
            return View(_contatoRepository.ListarContatos());
        }


        #region Criar
        public IActionResult Criar()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _contatoRepository.CriarContato(contato);
                    TempData["Cadastrado"] = $"{contato.Nome} Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                if (!ModelState.IsValid)
                {
                    TempData["Erro"] = "";
                }

                
            }
            catch (Exception ex)
            {
                
            }
            return View(contato);
        }
        #endregion


        #region Editar
        public IActionResult Editar(int id)
        {
            ContatoModel contatoModel = _contatoRepository.BuscaPorId(id);
            return View(contatoModel);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["Editado"] = $"{contato.Nome} editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                else if (!ModelState.IsValid){
                    TempData["NaoEditado"] = "";
                }

            }
            catch (Exception ex)
            {
                return View(contato);
            }
            return View(contato);
        }

        #endregion


        public IActionResult DeletarConfirmacao(int id)
        {
           ContatoModel contato = _contatoRepository.DeletarConfirmacao(id);
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContatoModel contato = _contexto.Contatos.FirstOrDefault(x => x.Id == id);
                    TempData["Deletado"] = $"{contato.Nome} Deletado Com Sucesso";
                    _contatoRepository.Deletar(id);
                    return RedirectToAction("Index");
                }
            }catch ( Exception ex)
            {
               
            }

            return View(_contatoRepository.BuscaPorId(id));

        }


    }
}
