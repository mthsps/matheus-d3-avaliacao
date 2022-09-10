using matheus_d3_avaliacao.Model;

namespace matheus_d3_avaliacao.Interface;

public interface ILog
{
    void RegisterAccess(User user, string login);
}