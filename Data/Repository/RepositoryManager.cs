using Data.Model;
using Shared.Repository;

namespace Data.Repository
{
   public class RepositoryManager:IRepositoryManager
    {
       internal SplitterEntities TcModel { get; private set; }
       public IUserRepository UserRepository { get; private set; }
       public IRuleRepository RuleRepository { get; private set; }
       public IStatisticRepository StatisticRepository { get; private set; }

      public RepositoryManager()
       {
           TcModel = new SplitterEntities();
           UserRepository = new UserRepository(TcModel);
           RuleRepository = new RuleRepository(TcModel);
           StatisticRepository = new StatisticRepository(TcModel);
       }
    }
}
