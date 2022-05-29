using System;
using System.Collections.Generic;
using YourPlaylist.Interfaces;

namespace YourPlaylist
{
	public class RepositorioMusicas : IRepositorio<Serie>
	{
        private List<Serie> listaMusica = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaMusica[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaMusica[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaMusica.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaMusica;
		}

		public int ProximoId()
		{
			return listaMusica.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaMusica[id];
		}
	}
}