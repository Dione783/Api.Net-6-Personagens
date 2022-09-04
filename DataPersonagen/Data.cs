using Microsoft.EntityFrameworkCore;

namespace Personagens{
    public class Data : DbContext{
        public Data(DbContextOptions<Data> options) : base(options){
            
        }
        public DbSet<Personagen> personagens {get;set;}
    }
}
