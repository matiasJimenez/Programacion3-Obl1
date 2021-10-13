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

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/Login/Login");
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
                        Session["LogueadoNombre"] = data.Mail;
                        Session["Logueado"] = true;
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

        [HttpPost]
        public async Task<ActionResult> CreateFuncionario(Funcionario funcionario)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    if (Funcionario.ValidarConatraseña(funcionario.Contraseña))
                    {                        
                        if (Funcionario.ValidarMail(funcionario.Mail))
                        {
                            if (await _funcionarioService.ExisteFuncionario(funcionario.Mail))
                            {
                                responseModel.Code = 700;
                                responseModel.Message = "Ya se registró ese mail.";
                            }
                            else
                            {
                                responseModel.DataModel = await _funcionarioService.CreateFuncionario(funcionario);
                            }                            
                        }
                        else
                        {
                            responseModel.Code = 700;
                            responseModel.Message = "El mail no es válido";
                        }
                    }
                    else
                    {
                        responseModel.Code = 700;
                        responseModel.Message = "La contraseña debe de cumplir con al menos 6 caracteres que incluyan letras mayúsculas y minúsculas(al menos una de cada una) y dígitos(0 al 9).";
                    }                    
                }
                else
                {
                    responseModel.Code = 700;
                    responseModel.Message = "Debe de completar todos los campos.";
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