using Order.Data.Data;
using Order.Data.Interfaces;
using Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Repository
{
    public class OrderRepository : GenericRepository<Orders>, IOrdersRepository
    {
        public OrderRepository(ApplicationDbContext context)
            :base(context)
        {
        }
    }
}
