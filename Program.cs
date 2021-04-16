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

            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)genero, titulo, descricao, ano);

            repositorio.Insere(novaSerie);

        }

        private static void AtualizaSerie()
        {
            ListarSeries();
            Console.WriteLine("Digite o Id da Serie que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Serie serieEscolhida = repositorio.RetornaPorId(id);

            int opcaoUsuario;

            do
            {
                Console.WriteLine("Opções de Atualização: ");
                Console.WriteLine("1 - Atualizar genero!");
                Console.WriteLine("2 - Atualizar titulo!");
                Console.WriteLine("3 - Atualizar ano de lançamento!");
                Console.WriteLine("4 - Atualizar descrição!");
                Console.WriteLine("0 - Finalizar atualização!");
                Console.WriteLine("Digite a opção que deseja atualizar: Digite 0 caso tenha acabado: ");
                opcaoUsuario = int.Parse(Console.ReadLine());

                switch(opcaoUsuario)
                {
                    case 1:
                        Console.WriteLine("Inserir genero: ");
                        serieEscolhida.AlteraGenero((Genero)int.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Inserir titulo: ");
                        serieEscolhida.AlteraTitulo(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Inserir ano: ");
                        serieEscolhida.AlteraAno(int.Parse(Console.ReadLine()));
                        break;
                    case 4:
                        Console.WriteLine("Inserir descrição: ");
                        serieEscolhida.AlteraDescricao(Console.ReadLine());
                        break;
                    case 0:
                        Console.WriteLine("Atualização finalizada!!!");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while(opcaoUsuario != 0);

        }

        private static void InfosSerie()
        {
            ListarSeries();
            Console.WriteLine("Digite o Id da Serie que deseja ver as informações: ");
            int id = int.Parse(Console.ReadLine());

            Serie serieEscolhida = repositorio.RetornaPorId(id);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Informações da serie: ");
            Console.WriteLine(serieEscolhida);
            Console.WriteLine("---------------------------------");
        }



        private static void ExcluiSerie()
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
