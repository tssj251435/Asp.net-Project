using System.Linq;
using System.Threading.Tasks;
using FindGavenCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindGavenCore
{
    public class ProviderViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public ProviderViewComponent (ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var providers = await db.Provider.ToListAsync();
            return View(providers);
        }
    }
}