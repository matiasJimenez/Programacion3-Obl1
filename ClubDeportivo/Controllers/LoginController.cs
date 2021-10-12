using BusinessLogic.BusinessService;
using Models;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClubDeportivo.Controllers
{
    public class LoginController : Controller
    {
        public FuncionarioService _funcionarioService = new FuncionarioService();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public async Task<ActionResult> Authentication(string mail, string contraseña)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                if (String.IsNullOrEmpty(mail) || String.IsNullOrEmpty(contraseña))
                {
                    responseModel.Code = 700;
                    responseModel.Message = "Mail o contraseña inválidos.";
                }
                else
                {
                    Funcionario data = new Funcionario();
                    data = await _funcionarioService.GetFuncionario(mail, contraseña);
                    if (data.IdFuncionario == 0)
                    {
                        responseModel.Code = 700;
                        responseModel.Message = "Mail o contraseña inválidos.";
                    }
                    else
                    {
                        responseModel.DataModel = data;
                    }                    
                }                
            }
            catch (Exception e)
            {
                responseModel = new ResponseModel(1, "Error: " + MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name, e.ToString());
            }

            return Json(new { response = responseModel }, JsonRequestBehavior.AllowGet);
        }
    }
}