using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Queries
{
   
    public class StudentsQuery
    {
        private readonly AppDbContext _dbContext;
        public StudentsQuery(AppDbContext dbContext)
        {
            _dbContext=dbContext;
        }

    }
}
