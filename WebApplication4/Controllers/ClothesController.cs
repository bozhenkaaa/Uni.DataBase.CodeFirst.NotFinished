using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.models;
using WebApplication4.Models.DTO;


namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly WebApplication4Context _context;

        public ClothesController(WebApplication4Context context)
        {
            _context = context;
        }

        // GET: api/Clothes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDtoRead>>> GetClothess()
        {
            var clDtoRead = new List<SubjectDtoRead>();
            var clothes = await _context.Clothess.ToListAsync();
            foreach (var clot in clothes)
            {
                var category = await _context.Categories.FindAsync(clot.Cl_Category);
                var location = await _context.Locations.FindAsync(clot.Cl_Location);
                var producer = await _context.Producers.FindAsync(clot.Cl_Producer);
                var seller = await _context.Sellers.FindAsync(clot.Cl_Seller);
                clDtoRead.Add(new SubjectDtoRead()
                {
                    Cl_Id = clot.Cl_Id,
                    Category = category!.Cat_Name,
                    Location = location!.L_Name,
                    Producer = producer!.Pr_Name,
                    Seller = seller!.S_Name,
                    Cl_Category = clot.Cl_Category,
                    Cl_Location = clot.Cl_Location,
                    Cl_Producer = clot.Cl_Producer,
                    Cl_Seller = clot.Cl_Seller,
                    Cl_Fabric = clot.Cl_Fabric,
                    Cl_Color =  clot.Cl_Color,
                    Cl_Quantity = clot.Cl_Quantity,
                    Price = clot.Price


                });
            }
            return clDtoRead;
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDtoRead>> GetClothes(int id)
        {
            var cl = await _context.Clothess.FindAsync(id);
            if (cl == null) return NotFound();
            var category = await _context.Categories.FindAsync(cl.Cl_Category);
            var location = await _context.Locations.FindAsync(cl.Cl_Location);
            var producer = await _context.Producers.FindAsync(cl.Cl_Producer);
            var seller = await _context.Sellers.FindAsync(cl.Cl_Seller);
            var clDtoRead = new SubjectDtoRead()
            {
                Cl_Id = cl.Cl_Id,
                Category = category!.Cat_Name,
                Location = location!.L_Name,
                Producer = producer!.Pr_Name,
                Seller = seller!.S_Name,
                Cl_Category = cl.Cl_Category,
                Cl_Location = cl.Cl_Location,
                Cl_Producer = cl.Cl_Producer,
                Cl_Seller = cl.Cl_Seller,
                Cl_Fabric = cl.Cl_Fabric,
                Cl_Color = cl.Cl_Color,
                Cl_Quantity = cl.Cl_Quantity
            };
            
            return clDtoRead;
            
        }

        

        // PUT: api/Clothes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothes(int? id, SubjectDtoWrite clothes)
        {
            if (id is null) return BadRequest("No id");
            var category = await _context.Categories.Where(e => e.Cat_Id == clothes.Cl_Category).ToListAsync();
            if (category.Count == 0) return BadRequest("Bad Category Id");
            var location = await _context.Locations.Where(e => e.L_Id == clothes.Cl_Location).ToListAsync();
            if (location.Count == 0) return BadRequest("Bad Category Id");
            var producer = await _context.Producers.Where(e => e.Pr_Id == clothes.Cl_Producer).ToListAsync();
            if (producer.Count == 0) return BadRequest("Bad Category Id");
            var seller = await _context.Sellers.Where(e => e.S_Id == clothes.Cl_Seller).ToListAsync();
            if (seller.Count == 0) return BadRequest("Bad Category Id");
            var s = await _context.Clothess.FindAsync(id);
            if (s is null) return BadRequest("Bad id");
            s.Cl_Category = clothes.Cl_Category;
            s.Category = category.First();
            s.Cl_Color = clothes.Cl_Color;
            s.Cl_Fabric = clothes.Cl_Fabric;
            s.Location = location.First();
            s.Price = clothes.Price;
            s.Producer = producer.First();
            s.Seller = seller.First();
            s.Cl_Seller = clothes.Cl_Seller;
            s.Cl_Quantity = clothes.Cl_Quantity;
            s.Cl_Location = clothes.Cl_Location;
            s.Cl_Producer = clothes.Cl_Producer;
            _context.Entry(s).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
            return RedirectToAction("GetClothess");


        }

        // POST: api/Clothes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clothes>> PostClothes(SubjectDtoWrite clDtoWrite)
        {
            var category = await _context.Categories.FindAsync(clDtoWrite.Cl_Category);
            if (category is null) return NotFound("Bad category Id");
            var location = await _context.Locations.FindAsync(clDtoWrite.Cl_Location);
            if (location is null) return NotFound("Bad location Id");
            var producer = await _context.Producers.FindAsync(clDtoWrite.Cl_Producer);
            if (producer is null) return NotFound("Bad producer Id");
            var seller = await _context.Sellers.FindAsync(clDtoWrite.Cl_Seller);
            if (seller is null) return NotFound("Bad seller Id");

            var clothes = new Clothes()
            {
                Category = category,
                Location = location,
                Producer = producer,
                Seller = seller,
                Cl_Category = clDtoWrite.Cl_Category,
                Cl_Location = clDtoWrite.Cl_Location,
                Cl_Producer = clDtoWrite.Cl_Producer,
                Cl_Seller = clDtoWrite.Cl_Seller,
                Cl_Fabric = clDtoWrite.Cl_Fabric,
                Cl_Color = clDtoWrite.Cl_Color,
                Cl_Quantity = clDtoWrite.Cl_Quantity
                
            };
            
            _context.Clothess.Add(clothes);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetClothess", new { id = clothes.Cl_Id });
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothes(int id)
        {
            if (_context.Clothess == null)
            {
                return NotFound();
            }
            var clothes = await _context.Clothess.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }

            _context.Clothess.Remove(clothes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothesExists(int id)
        {
            return (_context.Clothess?.Any(e => e.Cl_Id == id)).GetValueOrDefault();
        }
    }
}
