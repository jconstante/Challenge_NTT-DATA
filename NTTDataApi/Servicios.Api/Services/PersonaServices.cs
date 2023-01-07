using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly IPersonasRepository _personasRepository;

        public PersonaServices(IPersonasRepository personasRepository)
        {
            _personasRepository = personasRepository;
        }

        public Task<IEnumerable<Persona>> GetAll()
        {
            return _personasRepository.GetAll();
        }

        public Task<Persona> GetId(int id)
        {
            return _personasRepository.GetId(id);
        }

        public Task<bool> Save(Persona model)
        {
            return _personasRepository.Save(model);
        }

        public Task<bool> Update(Persona model)
        {
            return _personasRepository.Update(model);
        }

        public Task<bool> Delete(int id)
        {
            return _personasRepository.Delete(id);
        }

    }
}
