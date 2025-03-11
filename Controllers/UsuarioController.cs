using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        /// <summary>
        /// Endpoint para Criar um usuario 
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        /// 
        [Authorize]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }

            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        /// <summary>
        /// Endpoint para buscar um usuario pelo seu id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {

            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                if(usuarioBuscado != null)
                { return Ok(usuarioBuscado);

                }
                return null;
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
