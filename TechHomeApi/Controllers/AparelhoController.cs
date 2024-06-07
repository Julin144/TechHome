using Microsoft.AspNetCore.Mvc;
using TechHomeApi.Data.Repository;
using TechHomeApi.Model.Entity;

namespace TechHomeApi.Controllers
{
    [Route("api/[controller]")]
    public class AparelhoController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<List<AparelhoEntity>> Get(int id)
        {
            AparelhoRepository db = new AparelhoRepository();
            List<AparelhoEntity> lista = new List<AparelhoEntity>();

            lista = db.GetAparelhos(id);

            return lista;
        }
    }
}
