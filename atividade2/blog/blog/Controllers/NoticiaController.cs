using blog.Data;
using blog.Entity;
using Microsoft.AspNetCore.Mvc;

namespace blog.NoticiaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Database.noticias);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Noticia noticia)
        {
            noticia.Id = Guid.NewGuid();
            Database.noticias.Add(noticia);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            Noticia? noticia = GetNoticia(id);

            if (noticia == null) return NotFound();

            Database.noticias.Remove(noticia);

            return Ok("Notícia removida com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Noticia noticia)
        {
            var editNoticia = GetNoticia(id);
            if (editNoticia == null) return NoContent();

            editNoticia.Titulo = noticia.Titulo;
            editNoticia.Conteudo = noticia.Conteudo;
            editNoticia.Autor = noticia.Autor;
            editNoticia.Data = noticia.Data;

            return Ok(editNoticia);
        }

        private Noticia? GetNoticia(string id)
        {
            return Database.noticias.Where(noticia => noticia.Id.ToString().Equals(id)).FirstOrDefault();
        }
    }

}
