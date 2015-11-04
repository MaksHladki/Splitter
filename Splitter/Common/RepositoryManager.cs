using Shared.Repository;

namespace Splitter.Common
{
    public static class RepositoryManager
    {
        private static IRepositoryManager _instance;

        public static IRepositoryManager Instance
        {
            get { return _instance ?? (_instance = new Data.Repository.RepositoryManager()); }
        }

    }
}