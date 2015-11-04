namespace Shared.Repository
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IRuleRepository RuleRepository { get; }
        IStatisticRepository StatisticRepository { get; }
    }
}
