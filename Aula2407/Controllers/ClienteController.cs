using AulaDeASPNet.Data;
using AulaDeASPNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;

namespace AulaDeASPNet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AulaContext _context;

        public ClienteController(AulaContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> BuscaClientes()
        {
            return View(await _context.Clientes.ToListAsync());        
        }


        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroCliente([Bind("Id,Nome,RG,CPF,Usuario,Senha,CEP,UF,Cidade,Bairro,Rua,Numero,Complemento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("BuscaClientes");
            }
            return View(cliente);
        }
    }
}
