using Estudos.Domain;
using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Service;
using Estudos.Domain.Interfaces.UoW;
using Estudos.Domain.Interfaces.Validador;
using Estudos.Domain.ValueObjects.Structs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Service.Services
{
    public class BancoDadosService<TEntidade> : Service, IBancoDadosService<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly IRepository<TEntidade> _repository;
        protected readonly IValidador<TEntidade> _validador;
        protected readonly IUnitOfWork _unitOfWork;

        public BancoDadosService(IRepository<TEntidade> repository, IValidador<TEntidade> validador, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validador = validador;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TEntidade> BuscarPorId(long codigo)
        {
            return await _repository.BuscarPorId(codigo);
        }

        public async virtual Task Remover(long codigo)
        {
            await _repository.Remover(codigo);

            if (!await _unitOfWork.Commit())
                AdicionarNotificacaoFalhaBanco();

            await _repository.BuscarPorId(codigo);
        }

        public IQueryable<TEntidade> Buscar()
            => _repository.Buscar();

        public bool VerificarExistencia(long codigo)
        {
            return _repository.VerificarExistencia(codigo);
        }

        public void AdicionarNotificacaoFalhaBanco()
        {
            AddNotificacao(new Notificacao("Nenhuma alteração foi realizada"));
        }

        public async Task Incluir(TEntidade entidade)
        {
            if (await ValidarEntidade(entidade))
            {
                await _repository.Incluir(entidade);
                await _unitOfWork.Commit();
            }
        }

        public async Task Atualizar(TEntidade entidade)
        {
            if (await ValidarEntidade(entidade))
            {
                _repository.Atualizar(entidade);
                await _unitOfWork.Commit();
            }
        }

        private async Task<bool> ValidarEntidade(TEntidade entidade)
        {
            if (!await _validador.Validar(entidade))
            {
                AddNotificacoes(_validador.Erros);
                return false;
            }

            return true;
        }

        public async Task Salvar(IEnumerable<TEntidade> entidades)
        {
            if (!await _validador.Validar(entidades))
            {
                AddNotificacoes(_validador.Erros);
                return;
            }

            await _repository.Salvar(entidades);
            await _unitOfWork.Commit();
        }
    }
}
