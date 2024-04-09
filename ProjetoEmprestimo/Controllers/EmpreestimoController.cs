using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimo.Data;
using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Controllers
{
    public class EmpreestimoController : Controller
    {
        readonly private DadosContex BancoDados;

        public EmpreestimoController(DadosContex bancoDados)// essa classe posso usar esse metodos dentro do banco
        {
            BancoDados = bancoDados;
        }

     
        public IActionResult Index()
        {
            IEnumerable<EmpreestimoModel> empreestimos = BancoDados.Emprestimos;
            return View();
        }
    }
}
