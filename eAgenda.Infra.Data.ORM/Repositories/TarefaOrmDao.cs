using eAgenda.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Infra.Data.ORM.Repositories
{
    public class TarefaOrmDao : RepositoryOrmBase<Tarefa>, ITarefaRepository
    {
        public TarefaOrmDao(eAgendaDbContext db) : base(db)
        {
        }
    }
}
