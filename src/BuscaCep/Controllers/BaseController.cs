using BuscaCep.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuscaCep.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult BadRequest(string mensagem)
        {
            return BadRequest(new RetornoErroModel(mensagem));
        }
    }
}
