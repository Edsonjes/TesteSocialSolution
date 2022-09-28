using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entityes;
using Microsoft.AspNetCore.Mvc;
using ORM.Interface;

namespace CadIMoveis.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IIMovel _Imovel;
        private readonly ICliente _Cliente;
        public ImovelController(IIMovel Imovel, ICliente Cliente)
        {
            _Imovel = Imovel;
            _Cliente = Cliente;
        }

        public IActionResult Index ()
        {
            var Retorno = _Imovel.GetAll();
            return View(Retorno);

        }
        
        public IActionResult Cadastrar(int IdCliente)
        {
            List<TipoImovel> lsttipoImovels = new List<TipoImovel>();
            lsttipoImovels = _Imovel.GetTipoImovels().ToList();
            if(lsttipoImovels != null  )
            {
                ViewBag.TipoImovel = lsttipoImovels;

            }
            Imovel imovel = new Imovel();
            imovel.IdCliente = IdCliente;
           
            return View();
            
             
        }
        public IActionResult  ListaImoveisUsuario(int IdCliente)
        {
            var lstImoveisCli = _Imovel.GetImoveisClienteByIdCliente(IdCliente);

            return View(lstImoveisCli);
        }
       
        [HttpPost]
        public IActionResult Cadastrar(Imovel ImovelCliente)
        {

            try
            {
               
              _Imovel.Add(ImovelCliente);
                return View("Index", _Imovel.GetAll());
            }
           catch (Exception ex)
            {
                return View(ex.Message);
            }
             
        }



        
        public IActionResult Editar (int Id)
        {
            List<TipoImovel> lsttipoImovels = new List<TipoImovel>();
            lsttipoImovels = _Imovel.GetTipoImovels().ToList();
            if (lsttipoImovels != null)
            {
                ViewBag.TipoImovel = lsttipoImovels;

            }
            Imovel Imovelcliente = _Imovel.GetById(Id);
            return View(Imovelcliente);
;       }


        [HttpPost]
        public IActionResult Editar (Imovel Obj)
        {
            int cliId = Convert.ToInt32(Obj.IdCliente);
            try
            {
                if (Obj != null)
                {
                    _Imovel.Update(Obj);


                }
                return View("ListaImoveisUsuario", _Imovel.GetImoveisClienteByIdCliente(cliId));
            }


            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}