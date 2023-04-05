
namespace blog.Entity
{
	public class Noticia
	{
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public DateTime Data { get; set; }

        public Noticia(string titulo, string conteudo, string autor, DateTime data)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Conteudo = conteudo;
            Autor = autor;
            Data = data;
        }
    }
}

