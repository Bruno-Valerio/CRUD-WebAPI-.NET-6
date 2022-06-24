using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using usuario.Model;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>{
                new Usuario{ nome = "Bruno", id = 1, DataNascimento = new DateTime(1995, 2, 7)}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var usuarios = Usuarios();
            usuarios.Add(usuario);
            return Ok(Usuarios());
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok(Usuarios());
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(Usuarios());
        }
    }
}