using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechHomeApi.Data.Repository;
using TechHomeApi.Model.Entity;
using TechHomeApi.Model.Response;

namespace TechHomeApi.Controllers
{
    [Route("api/[controller]")]
    public class CasaController : Controller
    {
        // GET: CasaController
        public ActionResult<List<CasaEntity>> Get(int id)
        {
            CasaRepository db = new CasaRepository();
            List<CasaEntity> lista = new List<CasaEntity>();

            lista = db.GetCasa(1);

            return lista;
        }

    }

}
