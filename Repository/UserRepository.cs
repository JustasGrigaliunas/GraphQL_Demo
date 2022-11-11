using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Generic;

namespace Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(IDbContextFactory<Context> contextFactory) : base(contextFactory)
        {
        }
    }
}
