using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ConstructoraExtreme.Models.DAL
{
    public class XtremeContext : DbContext
    {
        public XtremeContext(DbContextOptions<XtremeContext> options) : base(options)
        {
        }
    }

}
