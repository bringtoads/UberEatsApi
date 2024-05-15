using UberEats.Application.Common.Interfaces.Persistence;
using UberEats.Domain.Menus;

namespace UberEats.Infrastructure.Persistence.Repositories
{
    //private readonly UberEatsDbContext _dbContext;

    public sealed class MenuRepository : IMenuRepository
    {
        private readonly UberEatsDbContext _dbContext;

        public MenuRepository(UberEatsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
