using System;


namespace DIOGFT2DOTNET.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpacaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "2":
                        InserirSerie();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "3":
                        AtualizaSerie();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "4":
                        ExcluiSerie();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "5":
                        VisualizarSerie();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "6":
                        ReciclarSerie();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "7":
                        ListarSeriesCadastradas();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = ObterOpacaoUsuario();
                        break;

                }
            }

            Console.WriteLine("Hello World!");
        }

        private static string ObterOpacaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("6 - Reciclar uma serie excluida");
            Console.WriteLine("7 - Lista todas as series cadastradas, até as excluídas ;)");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada...Ainda, tente a opção 2");
                return;
            }
            foreach (var serie in lista)
            {
                if (serie.retornaExcluido() == false)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static void ListarSeriesCadastradas()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada...Ainda, tente a opção 2");
                return;
            }
            foreach (var serie in lista)
            {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        public static Serie PegaDadosSerie(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o numero do genero desejado dada a lista acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da serie:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie:");
            string entradaDescricao = Console.ReadLine();

            //caso for uma nova serie passar como parametro id = -1 caso for atualizacao passar o id desejado
            if (id == -1)
            {
                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    descricao: entradaDescricao,
                    ano: entradaAno);
                return novaSerie;
            }
            else
            {
                Serie novaSerie = new Serie(id: id,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    descricao: entradaDescricao,
                    ano: entradaAno);
                return novaSerie;
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie.ToString());
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir serie");
            repositorio.Insere(PegaDadosSerie(-1));
            return;
        }

        private static void AtualizaSerie()
        {
            Console.WriteLine("Atualiza serie");
            Console.Write("Digite o id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Atualiza(indiceSerie, PegaDadosSerie(indiceSerie));
        }

        private static void ExcluiSerie()
        {
            Console.Write("Digite o Id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void ReciclarSerie()
        {
            Console.Write("Digite o Id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Recicla(indiceSerie);
        }
    }
}
