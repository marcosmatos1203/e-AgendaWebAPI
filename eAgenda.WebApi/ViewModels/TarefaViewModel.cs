using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAgenda.WebApi.ViewModels
{
    public class TarefaListViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Prioridade { get; set; }

        public int Percentual { get; set; }
    }

    public class TarefaDetailsViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Prioridade { get; set; }

        public int Percentual { get; set; }

        public string DataCriacao { get; set; }

        public string DataConclusao { get; set; }

    }

    public class TarefaCreateViewModel
    {
        public string Titulo { get; set; }

        public int Prioridade { get; set; }
    }


    public class TarefaEditViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int Prioridade { get; set; }

        public int Percentual { get; set; }
    }
}
