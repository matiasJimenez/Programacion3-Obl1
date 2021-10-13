using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Models.Response;
using BusinessLogic.BusinessService;

namespace ClubDeportivo.Controllers
{
    public class SocioController : Controller
    {
        public SocioService _socioService = new SocioService();

        public ActionResult Socios()
        {
            if (Convert.ToBoolean(Session["Logueado"]))
            {
                return View();
            }
            return Redirect("/Login/Login");
        }

        public ActionResult SocioDetails()
        {
            if (Convert.ToBoolean(Session["Logueado"]))
            {
                return View();
            }                
            return Redirect("/Login/Login");
        }

        public async Task<ActionResult> GetSocios(Filtro filtro)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                IList<Socio> data = new List<Socio>();
                data = await _socioService.GetSocios(filtro);
                responseModel.DataModel = data;
            }
            catch (Exception e)
            {
                responseModel = new ResponseModel(1, "Error: " + MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name, e.ToString());
            }

            return Json(new { response = responseModel }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetSocio(int? idSocio)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                Socio data = new Socio();
                data = await _socioService.GetSocio(idSocio ?? null);
                responseModel.DataModel = data;
            }
            catch (Exception e)
            {
                responseModel = new ResponseModel(1, "Error: " + MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name, e.ToString());
            }

            return Json(new { response = responseModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrUpdateSocio(Socio socio)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    if (Socio.ValidarCedula(socio.Cedula) && Socio.ValidarNombreCompleto(socio.NombreCompleto) && Socio.ValidadFechaNacimiento(socio.FechaNacimiento))
                    {
                        if (await _socioService.ExisteSocio(socio.Cedula))
                        {
                            responseModel.Code = 700;
                            responseModel.Message = "Ya se registró esa cédula.";
                        }
                        else
                        {
                            responseModel.DataModel = await _socioService.CreateUpdateSocio(socio);
                        }                        
                    }
                    else
                    {
                        responseModel.Code = 700;
                        responseModel.Message = "Revisar que cumple con los siguientes validaciones: \n El socio debe ser mayor de 3 y menor de 90 años. \n El largo del nombre debe ser mayor a 6. \n La cédula debe tener entre 6 y 9 carácteres.";
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