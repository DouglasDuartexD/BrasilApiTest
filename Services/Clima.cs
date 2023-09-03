using System;
using System.Threading.Tasks;
using BrasilApi.Models;

public class ClimaService
{
    private readonly ApplicationDbContext _dbContext;

    public ClimaService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SalvarClimaAeroporto(ClimaAeroporto clima)
    {
        clima.CreatedAt = DateTime.Now;
        _dbContext.ClimaAeroporto.Add(clima);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SalvarClimaCidade(ClimaCidade clima)
    {
        clima.CreatedAt = DateTime.Now;
        _dbContext.ClimaCidade.Add(clima);
        await _dbContext.SaveChangesAsync();
    }

}
