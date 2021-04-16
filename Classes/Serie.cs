

using System;

namespace CadastroSeries
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Decricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Decricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Decricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;

            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void AlteraTitulo(string novoTitulo)
        {
            this.Titulo = novoTitulo;
        }

        public void AlteraGenero(Genero novoGenero)
        {
            this.Genero = novoGenero;
        }

        public void AlteraAno(int novoAno)
        {
            this.Ano = novoAno;
        }

        public void AlteraDescricao(string novaDescr)
        {
            this.Decricao = novaDescr;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }

    
}