using System;
using blog.Entity;

namespace blog.Data
{
	public class Database
	{
        public static List<Noticia> noticias = new List<Noticia>() {
            new Noticia("Vagas Front-End", "Contratação na Nubank", "Fulano Detal", new DateTime()),
            new Noticia("Treinamento CSS", "Treinamento CSS na unifacisa", "Japa", new DateTime()),
        };
    }
}

