using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Services
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListarRegistros();
        PlanoContaModel RetornarRegistro(int id);
        void Salvar(PlanoContaModel model);
        void Excluir(int id);
    }
}