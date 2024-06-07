using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechHomeApi.Model.Entity;
using TechHomeApi.Model.Response;
using TechHomeApi.Data.Repository;
using System.ComponentModel;
using TechHomeApi.Model.Request;

namespace TechHomeApi.Controllers
{
    [Route("api/[controller]")]
    public class ComodoController : Controller
    {
        
        [HttpGet("{id}")]
        public ActionResult<List<ComodoEntity>> Get(int id)
        {
            ComodoRepository db = new ComodoRepository();
            List<ComodoEntity> lista = new List<ComodoEntity>();

            lista = db.GetComodo(id);

            return lista;
        }
        [HttpPost]
        public void Post([FromBody] ComodoPostRequest comodo)
        {
            ComodoRepository db = new ComodoRepository();
            db.CreateComodo(comodo);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ComodoRequest name)
        {
            ComodoRepository db = new ComodoRepository();
            db.UpdateComodo(id, name.Name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ComodoRepository db = new ComodoRepository();
            db.DeleteComodo(id);
        }
    }
}
