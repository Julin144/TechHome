using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechHomeApi.Data.Repository;
using TechHomeApi.Model.Entity;
using TechHomeApi.Model.Request;
using TechHomeApi.Model.Response;

namespace TechHomeApi.Controllers
{
    [Route("api/[controller]")]
    public class CasaController : Controller
    {
        // GET: CasaController
        [HttpGet("{id}")]
        public ActionResult<List<CasaEntity>> Get(int id)
        {
            CasaRepository db = new CasaRepository();
            List<CasaEntity> lista = new List<CasaEntity>();

            lista = db.GetCasa(id);

            return lista;
        }
        [HttpPost]
        public void Post([FromBody] CasaEntity Casa)
        {
            CasaRepository db = new CasaRepository();
            db.CreateCasa(Casa);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CasaRequest name)
        {
            CasaRepository db = new CasaRepository();
            db.UpdateCasa(id,name.Name);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CasaRepository db = new CasaRepository();
            db.DeleteCasa(id);
        }
    }

}
