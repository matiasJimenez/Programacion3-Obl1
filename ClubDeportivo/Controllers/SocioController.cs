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
            return View();
        }

        public ActionResult CreateUpdateSocio()
        {
            return View();
        }

        public async Task<ActionResult> GetSocios()
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                IList<Socio> data = new List<Socio>();
                Filtro filtro = new Filtro();
                data = await _socioService.GetSocios(filtro);
                responseModel.DataModel = data;
            }
            catch (Exception e)
            {
                responseModel = new ResponseModel(1, "Error: " + MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name, e.ToString());
            }

            return Json(new { response = responseModel }, JsonRequestBehavior.AllowGet);
        }
    }
}