using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        } 
        /// <summary>
           /// Endpoint para Listar um Filme 
           /// </summary>
           /// <param name="id">id do genero buscado</param>
           /// <returns>Genero Buscado</returns>
           /// 
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<Filme> listadefime = _filmeRepository.Listar();
                return Ok(listadefime);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
             }
        /// <summary>
        /// Endpoint para Criar um filme 
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        /// 
        [HttpPost]

            public IActionResult Post(Filme novoFilme)
            {
                try
                {
                    _filmeRepository.Cadastrar(novoFilme);
                    return Created();
                }

                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }

            }
        /// <summary>
        /// Endpoint para buscar um Filme pelo seu id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        /// 
        [HttpGet("BuscarPorId/{id}")]
            public IActionResult GetById(Guid id)
            {

                try
                {
                    Filme filmeBuscado = _filmeRepository.BuscarPorId(id);
                    return Ok(filmeBuscado);
                }
                catch (Exception error)
                {

                    return BadRequest(error.Message);
                }
            }
        /// <summary>
        /// Endpoint para Deletar um Filme 
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        /// 
        [HttpDelete("{id}")]
            public IActionResult Delete(Guid id)
            {
                try
                {
                    _filmeRepository.Deletar(id);
                    return NoContent();

                }
                catch (Exception)
                {

                    throw;
                }

            }
        /// <summary>
        /// Endpoint para Atualizar um Filme 
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        /// 
        [HttpPut("id")]
            public IActionResult Put(Guid id, Filme filme)
            {
                try
                {
                    _filmeRepository.Atualizar(id, filme);
                    return NoContent();
                }
                catch (Exception error)
                {

                    return BadRequest(error.Message);
                }
            }






}
    }

