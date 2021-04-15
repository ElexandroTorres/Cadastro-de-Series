namespace CadastroSeries
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Decricao { get; set; }
        private int Ano { get; set; }
    }
}