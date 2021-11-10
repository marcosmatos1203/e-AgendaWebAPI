using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio
{
    public interface IRepository<TEntity>
    {
        bool Inserir(TEntity entity);

        bool Editar(int id, TEntity entity);

        bool Excluir(int id);

        List<TEntity> SelecionarTodos();

        TEntity SelecionarPorId(int id);
    }
}
