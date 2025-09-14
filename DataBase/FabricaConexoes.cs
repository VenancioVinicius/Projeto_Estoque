using Microsoft.EntityFrameworkCore;

public class FabricaConexoes : DbContext{

    public FabricaConexoes(DbContextOptions<FabricaConexoes> options) : base(options) { }
    
    public DbSet<Produtos> produtos { get; set; }

}