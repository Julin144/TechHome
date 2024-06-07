using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using TechHomeApi.Data.Repository;
using TechHomeApi.Model.Entity;

namespace TechHomeApi.Controllers
{

    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult<int> Get(int id )
        {
            UsuarioRepository db = new UsuarioRepository();
            int user;

            user = db.Login("adm","adm");

            return user;
        }
    }
}
