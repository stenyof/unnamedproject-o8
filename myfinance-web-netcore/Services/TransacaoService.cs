using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Infrastructure.Entities;

namespace myfinance_web_netcore.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransacaoModel> ListarRegistros()
        {
            return _dbContext.Transacao
                .Include(t => t.PlanoConta) // JOIN com PlanoConta
                .Select(entidade => new TransacaoModel
                {
                    Id = entidade.Id,
                    Historico = entidade.Historico,
                    DataTransacao = entidade.DataTransacao,
                    PlanoContaId = entidade.PlanoContaId,
                    Valor = entidade.Valor,
                    // Evita exceções caso o relacionamento não esteja carregado
                    PlanoContaNome = entidade.PlanoConta != null ? entidade.PlanoConta.Nome : string.Empty
                })
                .ToList();
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var entidade = _dbContext.Transacao
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (entidade == null)
                return new TransacaoModel();

            return new TransacaoModel
            {
                Id = entidade.Id,
                Historico = entidade.Historico,
                DataTransacao = entidade.DataTransacao,
                PlanoContaId = entidade.PlanoContaId,
                Valor = entidade.Valor
            };
        }

        public void Salvar(TransacaoModel model)
        {
            if (model.Id == null)
            {
                var entidade = new myfinance_web_netcore.Infrastructure.Entities.Transacao
                {
                    Historico = model.Historico,
                    DataTransacao = model.DataTransacao,
                    PlanoContaId = model.PlanoContaId,
                    Valor = model.Valor
                };
                _dbContext.Transacao.Add(entidade);
            }
            else
            {
                var entidade = _dbContext.Transacao.FirstOrDefault(x => x.Id == model.Id);
                if (entidade == null) return;

                entidade.Historico = model.Historico;
                entidade.DataTransacao = model.DataTransacao;
                entidade.PlanoContaId = model.PlanoContaId;
                entidade.Valor = model.Valor;
            }

            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entidade = _dbContext.Transacao.FirstOrDefault(x => x.Id == id);
            if (entidade == null) return;

            _dbContext.Transacao.Remove(entidade);
            _dbContext.SaveChanges();
        }
    }
}