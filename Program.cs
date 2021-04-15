using System;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            

            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InsereSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        InfosSerie();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listando todas as series: ");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("A lista de series está vazia!");
                return;
            }
            
            foreach (var serie in lista)
            {
                Console.WriteLine("ID: {0} -> {1}", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static void InsereSerie()
        {
            Console.WriteLine("Digite as informações da serie a ser adicionada!");

            Console.WriteLine("Digite o Genero da Serie: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano em que a serie iniciou: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), (Genero)genero, titulo, descricao, ano);

            repositorio.Insere(novaSerie);

        }

        private static void InfosSerie()
        {
            throw new NotImplementedException();
        }

        private static void ExcluiSerie()
        {
            throw new NotImplementedException();
        }

        private static void AtualizaSerie()
        {
            throw new NotImplementedException();
        }





        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("*******************************************");
            Console.WriteLine("Cadastro de Series");
            Console.WriteLine("Escolha alguma das operações listadas abaixo");
            Console.WriteLine("*******************************************");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir uma nova serie");
            Console.WriteLine("3 - Atualizar uma serie");
            Console.WriteLine("4 - Excluir uma serie");
            Console.WriteLine("5 - Vizualizar informações de uma serie");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }


    }
}
