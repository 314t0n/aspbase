using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piton.Domain.Entities;
using System.Data.Entity;

namespace Piton.Domain.Concrete
{
    /**
     * this class automatically defines a property for each table in the database that we want to work with
     * the name of the property specifies the table and the  type parameter of the dbset result specifies the model
     * that the entity framewokr shoul use to repsresent rows in the table
     * */
    public class EFDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

    }
}
