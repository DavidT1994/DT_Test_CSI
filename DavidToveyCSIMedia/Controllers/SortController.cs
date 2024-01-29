using DavidToveyCSIMedia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DavidToveyCSIMedia.Controllers
{
    public class SortController:Controller
    {
        private readonly AppDbContext _context;

        public SortController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Create()
        {
            return View(new Sort());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sort sort)
        {
            if (ModelState.IsValid)
            {
                //get current time
                DateTime dt= DateTime.Now;
                //sort the numbers
                int[] numbers= sort.Sequence.Split(",").Select(x=>Convert.ToInt32(x)).ToArray();
                List<int> sorted = new List<int>();
                if (sort.Direction == "Asc")
                {
                    sorted=numbers.OrderBy(x=>x).ToList();
                }
                else
                {
                    sorted = numbers.OrderByDescending(x => x).ToList();
                }
                sort.Sequence = string.Join(",", sorted);
                
                //get current time
                DateTime dt1 = DateTime.Now;

                int ms = Convert.ToInt32((dt1 - dt).TotalMilliseconds);
                sort.Time = ms;
                await _context.Sort.AddAsync(sort);
                await _context.SaveChangesAsync();
                return View("Complete", sort);
            }

            return View(sort);
        }

        public async Task<IActionResult> Index()
        {
            return _context.Sort != null ?
                View(await _context.Sort.ToListAsync()) :
                Problem("Entity set 'AppDbContext.Sort'  is null.");
        }
    }
}
