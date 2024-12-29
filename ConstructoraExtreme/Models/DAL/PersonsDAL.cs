using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class PersonsDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
        public PersonsDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear una nueva persona en la base de datos.
        public async Task<int> Create(Persons person)
        {
            _context.Persons.Add(person);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener una persona por su ID.
        public async Task<Persons> GetById(int id)
        {
            var person = await _context.Persons
                .Include(p => p.DocumentTypesCatalog)  // Incluir el tipo de documento relacionado
                .Include(p => p.EconomicActivitiesCatalog)  // Incluir la actividad económica relacionada
                .Include(p => p.DepartmentsCatalog)  // Incluir el departamento relacionado
                .Include(p => p.MunicipalitiesCatalog)  // Incluir el municipio relacionado
                .Include(p => p.Store)  // Incluir la tienda relacionada
                .FirstOrDefaultAsync(p => p.Id == id);

            return person ?? new Persons();
        }

        // Método para editar una persona existente en la base de datos.
        public async Task<int> Edit(Persons person)
        {
            int result = 0;
            var personUpdate = await GetById(person.Id);
            if (personUpdate.Id != 0)
            {
                // Actualiza los datos de la persona.
                personUpdate.Document_Type_Id = person.Document_Type_Id;
                personUpdate.Document_Number = person.Document_Number;
                personUpdate.Store_Id = person.Store_Id;
                personUpdate.Is_Natural_Person = person.Is_Natural_Person;
                personUpdate.First_Name = person.First_Name;
                personUpdate.Middle_Name = person.Middle_Name;
                personUpdate.First_Surname = person.First_Surname;
                personUpdate.Second_Surname = person.Second_Surname;
                personUpdate.Business_Name = person.Business_Name;
                personUpdate.Trade_Name = person.Trade_Name;
                personUpdate.NRC = person.NRC;
                personUpdate.Economic_Activity_Id = person.Economic_Activity_Id;
                personUpdate.Email = person.Email;
                personUpdate.Phone = person.Phone;
                personUpdate.Country = person.Country;
                personUpdate.Department_Id = person.Department_Id;
                personUpdate.Municipality_Id = person.Municipality_Id;
                personUpdate.Address_Details = person.Address_Details;
                personUpdate.Active = person.Active;
                personUpdate.Updated_At = person.Updated_At;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar una persona de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var personDelete = await GetById(id);
            if (personDelete.Id != 0)
            {
                // Elimina la persona de la base de datos.
                _context.Persons.Remove(personDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable con filtros.
        private IQueryable<Persons> Query(Persons person)
        {
            var query = _context.Persons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(person.First_Name))
                query = query.Where(p => p.First_Name.Contains(person.First_Name));

            if (!string.IsNullOrWhiteSpace(person.First_Surname))
                query = query.Where(p => p.First_Surname.Contains(person.First_Surname));

            if (!string.IsNullOrWhiteSpace(person.Document_Number))
                query = query.Where(p => p.Document_Number.Contains(person.Document_Number));

            if (person.Store_Id > 0)
                query = query.Where(p => p.Store_Id == person.Store_Id);

            if (person.Active)
                query = query.Where(p => p.Active == person.Active);

            return query;
        }

        // Método para contar el número de personas que cumplen con los filtros.
        public async Task<int> CountSearch(Persons person)
        {
            return await Query(person).CountAsync();
        }

        // Método para buscar personas con filtros, paginación y ordenamiento.
        public async Task<List<Persons>> Search(Persons person, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(person);
            query = query.OrderByDescending(p => p.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
