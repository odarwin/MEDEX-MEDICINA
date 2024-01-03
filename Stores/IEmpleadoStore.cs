using ProyectoMedexcard.Entities;

namespace ProyectoMedexcard.Stores
{
    public interface IEmpleadoStore
    {
        Task<Persona> CreateAsync(Persona persona);
    }
}
