using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class PersonReferencesDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
        public PersonReferencesDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear una nueva referencia de persona en la base de datos.
        public async Task<int> Create(PersonReferences personReference)
        {
            _context.PersonReferences.Add(personReference);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener una referencia de persona por su ID.
        public async Task<PersonReferences> GetById(int id)
        {
            var personReference = await _context.PersonReferences
                .Include(pr => pr.Persons)  // Incluir la persona relacionada
                .Include(pr => pr.Store)    // Incluir la tienda relacionada
                .FirstOrDefaultAsync(pr => pr.Id == id);

            return personReference ?? new PersonReferences();
        }

        // Método para editar una referencia de persona existente en la base de datos.
        public async Task<int> Edit(PersonReferences personReference)
        {
            int result = 0;
            var personReferenceUpdate = await GetById(personReference.Id);
            if (personReferenceUpdate.Id != 0)
            {
                // Actualiza los datos de la referencia de persona.
                personReferenceUpdate.First_Name = personReference.First_Name;
                personReferenceUpdate.Middle_Name = personReference.Middle_Name;
                personReferenceUpdate.First_Surname = personReference.First_Surname;
                personReferenceUpdate.Second_Surname = personReference.Second_Surname;
                personReferenceUpdate.Phone = personReference.Phone;
                personReferenceUpdate.Store_Id = personReference.Store_Id;
                personReferenceUpdate.Person_Id = personReference.Person_Id;
                personReferenceUpdate.Active = personReference.Active;
                personReferenceUpdate.Updated_At = personReference.Updated_At;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar una referencia de persona de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var personReferenceDelete = await GetById(id);
            if (personReferenceDelete.Id != 0)
            {
                // Elimina la referencia de persona de la base de datos.
                _context.PersonReferences.Remove(personReferenceDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable con filtros.
        private IQueryable<PersonReferences> Query(PersonReferences personReference)
        {
            var query = _context.PersonReferences.AsQueryable();

            if (!string.IsNullOrWhiteSpace(personReference.First_Name))
                query = query.Where(pr => pr.First_Name.Contains(personReference.First_Name));

            if (!string.IsNullOrWhiteSpace(personReference.First_Surname))
                query = query.Where(pr => pr.First_Surname.Contains(personReference.First_Surname));

            if (!string.IsNullOrWhiteSpace(personReference.Phone))
                query = query.Where(pr => pr.Phone.Contains(personReference.Phone));

            if (personReference.Store_Id > 0)
                query = query.Where(pr => pr.Store_Id == personReference.Store_Id);

            if (personReference.Active)
                query = query.Where(pr => pr.Active == personReference.Active);

            return query;
        }

        // Método para contar el número de referencias de persona que cumplen con los filtros.
        public async Task<int> CountSearch(PersonReferences personReference)
        {
            return await Query(personReference).CountAsync();
        }

        // Método para buscar referencias de personas con filtros, paginación y ordenamiento.
        public async Task<List<PersonReferences>> Search(PersonReferences personReference, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(personReference);
            query = query.OrderByDescending(pr => pr.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}

