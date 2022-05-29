using System;

namespace YourPlaylist
{
    class Program
    {
        static RepositorioMusicas repositorio = new RepositorioMusicas();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusicas();
						break;
					case "2":
						InserirMusica();
						break;
					case "3":
						AtualizarMusica();
						break;
					case "4":
						ExcluirMusica();
						break;
					case "5":
						VisualizarMusica();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusica);
		}

        private static void VisualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(serie);
		}

        private static void AtualizarMusica()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Banda: ");
			string entradaBanda = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceMusica,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										banda: entradaBanda);

			repositorio.Atualiza(indiceMusica, atualizaSerie);
		}
        private static void ListarMusicas()
		{
			Console.WriteLine("Listar músicas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMusica()
		{
			Console.WriteLine("Inserir nova música");

		
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a banda: ");
			string entradaBanda = Console.ReadLine();

			Serie novaMusica= new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										banda: entradaBanda);

			repositorio.Insere(novaMusica);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("YourPlaylist a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar músicas");
			Console.WriteLine("2- Inserir nova música");
			Console.WriteLine("3- Atualizar música");
			Console.WriteLine("4- Excluir música");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
