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

     
        public IActionResult Index() // Get ler as informações criadas
        {
            IEnumerable<EmpreestimoModel> empreestimos = BancoDados.Emprestimos; // Coletando os dados do banco de dados
            return View(empreestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()// Post: estamos dando uma Criando
        {
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id) {
        
            if(id == null || id == 0) { 
             
                return NotFound();
            
            }

            EmpreestimoModel empreestimo = BancoDados.Emprestimos.FirstOrDefault(x => x.Id == id);//fazendo um where dentro do banco x e a tabela

            if(empreestimo == null)
            {
                return NotFound();
            }

        return View(empreestimo);
        }
        [HttpPost]
        public IActionResult Cadastrar(EmpreestimoModel empreestimo)// Post: estamos dando uma Criando
        {
            if(ModelState.IsValid)
            {
                BancoDados.Emprestimos.Add(empreestimo);//adicionar no banco de dados
                BancoDados.SaveChanges();// vai salvar

                return RedirectToAction("Index");// vai mandar para pagina Index

            }
            return View();// vai permanecer na view cadastrar ate ficar certa
        }

        [HttpPost]
        public IActionResult Editar(EmpreestimoModel empreestimo)
        {
            if(ModelState.IsValid)
            {
                BancoDados.Emprestimos.Update(empreestimo);// vai alterar
                BancoDados.SaveChanges(); // salvar no banco
                return RedirectToAction("Index");
            }
            return View(empreestimo);
        }
        [HttpGet]
        public IActionResult Excluir(int ? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

           EmpreestimoModel empreestimo = BancoDados.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(empreestimo == null)
            {
                return NotFound();
            }
            return View(empreestimo);
        }
        [HttpPost]
        public IActionResult Excluir(EmpreestimoModel empreestimo)// Post: estamos dando uma Criando
        {
            if (empreestimo == null)
            {
                return NotFound();

            }

            BancoDados.Emprestimos.Remove(empreestimo);//adicionar no banco de dados
            BancoDados.SaveChanges();// vai salvar

            return RedirectToAction("Index");// vai mandar para pagina Index

        }

    }
}
