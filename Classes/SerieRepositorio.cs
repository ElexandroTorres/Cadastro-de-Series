using System;
using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie serie)
        {
            listaSeries[id] = serie;
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Serie serie)
        {
            listaSeries.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public Serie RetornaPorId()
        {
            throw new NotImplementedException();
        }
    }
}