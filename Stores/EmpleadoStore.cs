using Microsoft.EntityFrameworkCore;
using ProyectoMedexcard.Entities;

namespace ProyectoMedexcard.Stores
{
    public class EmpleadoStore : IEmpleadoStore
    {
        private readonly ApplicationDbContext _dbContext;
        public EmpleadoStore(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Persona> CreateAsync(Persona persona)
        {
            try
            {
                _dbContext.Personas.Add(persona);
                await _dbContext.SaveChangesAsync();

                return persona;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la operación
                throw new ApplicationException("Ocurrió un error inesperado al crear la persona: " + ex.Message);
            }
        }
    }
}
