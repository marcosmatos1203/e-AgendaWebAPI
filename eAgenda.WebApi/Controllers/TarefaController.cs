using AutoMapper;
using eAgenda.Dominio;
using eAgenda.Infra.Data.ORM;
using eAgenda.Infra.Data.ORM.Repositories;
using eAgenda.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAgenda.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private TarefaOrmDao tarefaRepository = new TarefaOrmDao(new eAgendaDbContext());
        private ILogger _logger;
        private readonly IMapper mapper;

        public TarefaController(ILogger<TarefaController> _logger)
        {
           
            var autoMapperConfig = new MapperConfiguration(config =>
            {

                config.CreateMap<Tarefa, TarefaListViewModel>()
                    .ForMember(dest => dest.Prioridade,
                        opt => opt.MapFrom(src => src.Prioridade.GetDescription()));

                config.CreateMap<Tarefa, TarefaDetailsViewModel>();
                config.CreateMap<TarefaCreateViewModel, Tarefa>();
                config.CreateMap<TarefaEditViewModel, Tarefa>();
            });
            mapper = autoMapperConfig.CreateMapper();

            this._logger = _logger;
        }

        [HttpGet]
        public List<TarefaListViewModel> GetAll()
        {
            var tarefas = tarefaRepository.SelecionarTodos();

            return mapper.Map < List < TarefaListViewModel >> (tarefas); 

        }
        [HttpGet("{id:int}")]
        public TarefaDetailsViewModel Get(int id)
        {
            var tarefa = tarefaRepository.SelecionarPorId(id);

            var tarefaVM = mapper.Map<TarefaDetailsViewModel>(tarefa);


            if (tarefa.DataConclusao == DateTime.MinValue)
                tarefaVM.DataConclusao = "";
            else
                tarefaVM.DataConclusao = tarefa.DataConclusao.ToShortDateString();

            return tarefaVM;
        }

        [HttpPost]
        public void Insert(TarefaCreateViewModel tarefaVM)
        {
            var tarefa = mapper.Map<Tarefa>(tarefaVM);
            tarefaRepository.Inserir(tarefa);
        }

        [HttpPut]
        public void Update(TarefaEditViewModel tarefaVM)
        {
            var tarefa = mapper.Map<Tarefa>(tarefaVM);
            tarefaRepository.Editar(tarefa);
        }

        [HttpDelete]
        public void Delete(Tarefa tarefa)
        {
            tarefaRepository.Excluir(tarefa);
        }
    }
}
