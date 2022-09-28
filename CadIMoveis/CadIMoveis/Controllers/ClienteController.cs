using Domain.Entityes;
using Microsoft.AspNetCore.Mvc;
using ORM.Interface;
using System;

namespace CadIMoveis.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ICliente _Cliente;

        public ClienteController (ICliente cliente)
        {
            _Cliente = cliente;
        }

        public IActionResult Index()
        {
            var Retorno = _Cliente.GetAll();
            return View(Retorno);
        }

      public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente obj)
        {
            try
            {
                if(obj != null)
                {
                    _Cliente.Add(obj);
                }
                return View("Index",_Cliente.GetAll());
              
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult Editar (int Id)
        {
            Cliente Cli = _Cliente.GetById(Id);
            return View(Cli);
;        }


        [HttpPost]
        public IActionResult Editar (Cliente Obj)
        {
            try
            {
                if (Obj != null)
                {
                    _Cliente.Update(Obj);


                }
                return View("Index", _Cliente.GetAll());
            }


            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult filterCliente(string Cpf_Cnpj)
        {
            
            if(Cpf_Cnpj != null)
            {
                return View("Index", _Cliente.Filter(Cpf_Cnpj));
            }
            else
            {
                return RedirectToAction("Index", _Cliente.GetAll());
            }
        }
        

    }
}
