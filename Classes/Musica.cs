using System;

namespace YourPlaylist
{
    public class Serie : EntidadeBase
    {
        
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Banda { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        
		public Serie(int id, Genero genero, string titulo, string banda, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Banda = banda;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Banda: " + this.Banda + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}