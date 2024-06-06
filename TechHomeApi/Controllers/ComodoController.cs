using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechHomeApi.Model.Entity;
using TechHomeApi.Model.Response;
using TechHomeApi.Data.Repository;
using System.ComponentModel;

namespace TechHomeApi.Controllers
{
    public class ComodosController : Controller
    {
        // GET: ComodosController
        [Route("api/[controller]")]
        public ActionResult<List<ComodoResponse>> Get()
        {
            CasaRepository db = new CasaRepository();
            List<ComodoResponse> lista = new List<ComodoResponse>();

            

            return lista;
        }
    }
}
