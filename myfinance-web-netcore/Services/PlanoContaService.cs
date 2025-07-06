using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PlanoContaModel> ListarRegistros()
        {
            return _dbContext.PlanoConta.Select(entidade => new PlanoContaModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Tipo = entidade.Tipo,
                Descricao = entidade.Descricao
            }).ToList();
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var entidade = _dbContext.PlanoConta.FirstOrDefault(x => x.Id == id);

            if (entidade == null)
                return new PlanoContaModel();

            return new PlanoContaModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Tipo = entidade.Tipo,
                Descricao = entidade.Descricao
            };
        }

        public void Salvar(PlanoContaModel model)
        {
            if (model.Id == null)
            {
                var entidade = new myfinance_web_netcore.Infrastructure.Entities.PlanoConta
                {
                    Nome = model.Nome,
                    Tipo = model.Tipo,
                    Descricao = model.Descricao
                };
                _dbContext.PlanoConta.Add(entidade);
            }
            else
            {
                var entidade = _dbContext.PlanoConta.First(x => x.Id == model.Id);
                entidade.Nome = model.Nome;
                entidade.Tipo = model.Tipo;
                entidade.Descricao = model.Descricao;
            }

            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entidade = _dbContext.PlanoConta.First(x => x.Id == id);
            _dbContext.PlanoConta.Remove(entidade);
            _dbContext.SaveChanges();
        }
    }
}