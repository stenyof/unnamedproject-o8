using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Services
{
    public interface ITransacaoService
    {
        List<TransacaoModel> ListarRegistros();
        TransacaoModel RetornarRegistro(int id);
        void Salvar(TransacaoModel model);
        void Excluir(int id);
    }
}
