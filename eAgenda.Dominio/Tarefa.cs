using System;

namespace eAgenda.Dominio
{
    public class Tarefa : Entity 
    {
        public Tarefa()
        {
            DataCriacao = DateTime.Now;
            Prioridade = PrioridadeEnum.Baixa;
            Percentual = 0;
        }

        public string Titulo { get; set; }

        public PrioridadeEnum Prioridade { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataConclusao { get; set; }

        public int Percentual { get; private set; }

        public void AtualizarPercentual(int percentual)
        {
            if (percentual == 100)
                DataConclusao = DateTime.Now;

            Percentual = percentual;
        }
    }
}