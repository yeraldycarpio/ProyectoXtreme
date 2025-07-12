using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructoraExtreme.Models.DAL
{
    public class ImagesDAL
    {
        private readonly XtremeContext _context;

        public ImagesDAL(XtremeContext context)
        {
            _context = context;
        }

        public async Task CreateImagesAsync(Images images)
        {

            _context.Images.Add(images);
            await _context.SaveChangesAsync();
        }

    }
}
