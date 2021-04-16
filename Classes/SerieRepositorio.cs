using System;
using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        private int seriesAtivas = 0;
        public void Atualiza(int id, Serie serie)
        {
            if(ValidarId(id))
            {
                listaSeries[id] = serie;
            }
        }

        public void Exclui(int id)
        {
            if(ValidarId(id))
            {
                listaSeries[id].Excluir();
                seriesAtivas--;
            }

        }

        public void Insere(Serie serie)
        {
            listaSeries.Add(serie);
            seriesAtivas++;
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if(ValidarId(id))
            {
                return listaSeries[id];
            }
            return null;
        }

        public int SeriesAtivas()
        {
            return seriesAtivas;
        }

        public bool ValidarId(int id)
        {
            return listaSeries.Exists(x => x.RetornaId() == id);
        }
    }
}