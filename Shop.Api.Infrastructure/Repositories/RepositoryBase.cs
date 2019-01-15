using Shop.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Infrastructure.Repositories
{
    public class RepositoryBase
    {
        protected ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
