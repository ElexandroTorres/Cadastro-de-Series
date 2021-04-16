using System;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Console.Clear();
            /* Adicionando Algumas series previamente para facilitar nos testes e demostração */
            InicializarRepositorio();

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
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Listando todas as series: ");
            Console.WriteLine("-------------------------------------------");
            var lista = repositorio.Lista();
            int numeroSeries = repositorio.SeriesAtivas();

            if(repositorio.SeriesAtivas() == 0)
            {
                Console.WriteLine("A lista de series está vazia!");
                Console.WriteLine("-------------------------------------------");
                return;
            }
            
            foreach (var serie in lista)
            {
                if(!serie.Excluida())
                {
                    Console.WriteLine("ID: {0} -> {1}", serie.RetornaId(), serie.RetornaTitulo());   
                }
            }
            Console.WriteLine("-------------------------------------------");
        }

        private static void InsereSerie()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite as informações da serie a ser adicionada!");
            Console.WriteLine("-------------------------------------------");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o numero correspondente ao Genero da Serie: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano em que a serie iniciou: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)genero, titulo, descricao, ano);

            repositorio.Insere(novaSerie);

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Serie {0} adicionada com Sucesso!", titulo);
            Console.WriteLine("-------------------------------------------");
            
            Esperar();
        }

        private static void AtualizaSerie()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Tela de Atualização");
            Console.WriteLine("---------------------------------");

            ListarSeries();

            Console.WriteLine("Digite o Id da Serie que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Serie serieEscolhida = repositorio.RetornaPorId(id);

            if(serieEscolhida == null || serieEscolhida.Excluida()) 
            {
                Console.WriteLine("Id digitado não existe na lista de series!");
                return;
            }
                
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
                        foreach (int i in Enum.GetValues(typeof(Genero)))
                        {
                            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                        }
                        Console.WriteLine("Inserir numero correspondente ao genero: ");
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

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Serie {0} Atualizada com sucesso", serieEscolhida.RetornaTitulo());
            Console.WriteLine("-------------------------------------------");

            Console.Clear();
        }

        private static void InfosSerie()
        {
            Console.Clear();
 
            ListarSeries();

            Console.WriteLine("Digite o Id da Serie que deseja ver as informações: ");
            int id = int.Parse(Console.ReadLine());

            Serie serieEscolhida = repositorio.RetornaPorId(id);

            if(serieEscolhida == null)
            {
                Console.WriteLine("Id digitado não existe na lista de series!");
                return;
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Informações da serie: ");
            Console.WriteLine(serieEscolhida);
            Console.WriteLine("---------------------------------");

            Esperar();
        }

        private static void ExcluiSerie()
        {
            ListarSeries();
            Console.WriteLine("Digite o Id da Serie que deseja excluir: ");

            int id = int.Parse(Console.ReadLine());
            repositorio.Exclui(id);
            Console.WriteLine("Serie Excluida!!!");

            Esperar();
        }

        private static string ObterOpcaoUsuario()
        {
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
            Console.Clear();

            return opcaoUsuario;

        }

        public static void Esperar()
        {
            Console.Write("Pressione qualquer tecla para continuar!");
            Console.ReadKey();
            Console.Clear();
        }

        public static void InicializarRepositorio()
        {
            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)5, "Breaking Bad",
                                         "O professor de química Walter White não acredita que sua vida possa piorar ainda mais. Quando descobre que tem câncer terminal, Walter decide arriscar tudo para ganhar dinheiro enquanto pode, transformando sua van em um laboratório de metanfetamina.",
                                          2009));
            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)5, "The Walking Dead",
                                         "baseado na história em quadrinhos escrita por Robert Kirkman, este drama potente e visceral retrata a vida nos Estados Unidos pós-apocalíptico. ",
                                          2010));
            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)3, "The Marvelous Mrs. Maisel",
                                         "Miriam Midge Maisel gostaria de levar uma vida comum em Manhattan, mas seu talento como comediante stand-up transforma sua rotina de dona de casa.",
                                          2017));

            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)5, "The Sopranos",
                                         "Nesta produção vencedora de 21 prêmios Emmy e 5 Globos de Ouro, Tony Soprano tenta equilibrar os problemas de sua família desajustada com outra \"família\" bem diferente - a máfia de Nova Jérsei.",
                                          1999));

            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)10, "Glee",
                                         "Com otimismo, o professor Will Schuester tenta inspirar um grupo de estudantes a reformar o antigo e bem sucedido Clube Glee, o coral da escola McKinley.",
                                          2009));
        }
    }
}
