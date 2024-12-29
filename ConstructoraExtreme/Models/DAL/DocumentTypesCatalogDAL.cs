using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class DocumentTypesCatalogDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
        public DocumentTypesCatalogDAL(XtremeContext XtremeContext)
        {
            _context = XtremeContext;
        }

        // Método para crear un nuevo tipo de documento en la base de datos.
        public async Task<int> Create(DocumentTypesCatalog documentType)
        {
            _context.Add(documentType);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un tipo de documento por su ID.
        public async Task<DocumentTypesCatalog> GetById(int id)
        {
            var documentType = await _context.DocumentTypesCatalogs.FirstOrDefaultAsync(d => d.Id == id);
            return documentType ?? new DocumentTypesCatalog();
        }

        // Método para editar un tipo de documento existente en la base de datos.
        public async Task<int> Edit(DocumentTypesCatalog documentType)
        {
            int result = 0;
            var documentTypeUpdate = await GetById(documentType.Id);
            if (documentTypeUpdate.Id != 0)
            {
                // Actualiza los datos del tipo de documento.
                documentTypeUpdate.Code = documentType.Code;
                documentTypeUpdate.Name = documentType.Name;
                documentTypeUpdate.IsNaturalPerson = documentType.IsNaturalPerson;
                documentTypeUpdate.Active = documentType.Active;
                documentTypeUpdate.CreatedAt = documentType.CreatedAt;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un tipo de documento de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var documentTypeDelete = await GetById(id);
            if (documentTypeDelete.Id > 0)
            {
                // Elimina el tipo de documento de la base de datos.
                _context.DocumentTypesCatalogs.Remove(documentTypeDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable para buscar tipos de documento con filtros.
        private IQueryable<DocumentTypesCatalog> Query(DocumentTypesCatalog documentType)
        {
            var query = _context.DocumentTypesCatalogs.AsQueryable();
            if (!string.IsNullOrWhiteSpace(documentType.Code))
                query = query.Where(d => d.Code.Contains(documentType.Code));
            if (!string.IsNullOrWhiteSpace(documentType.Name))
                query = query.Where(d => d.Name.Contains(documentType.Name));
            if (documentType.IsNaturalPerson)
                query = query.Where(d => d.IsNaturalPerson == documentType.IsNaturalPerson);
            if (documentType.Active)
                query = query.Where(d => d.Active == documentType.Active);

            return query;
        }

        // Método para contar la cantidad de resultados de búsqueda con filtros.
        public async Task<int> CountSearch(DocumentTypesCatalog documentType)
        {
            return await Query(documentType).CountAsync();
        }

        // Método para buscar tipos de documento con filtros, paginación y ordenamiento.
        public async Task<List<DocumentTypesCatalog>> Search(DocumentTypesCatalog documentType, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(documentType);
            query = query.OrderByDescending(d => d.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }

}
