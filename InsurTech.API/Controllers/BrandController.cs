using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsurTech.Data.Model;
using InsurTech.Repository.Interfaces;

namespace InsurTech.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Brand>> GetBrand()
        {
            return await brandRepository.GetBrands();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brands = await brandRepository.GetBrands();
            var brand = brands.SingleOrDefault(m => m.BrandId == id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brand/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBrand([FromRoute] int id, [FromBody] Brand brand)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != brand.BrandId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(brand).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BrandExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        /// <summary>
        /// To Insert a new brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostBrand([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await brandRepository.AddBrand(brand);

            return CreatedAtAction("GetBrand", new { id = brand.BrandId }, brand);
        }

        // DELETE: api/Brand/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBrand([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var brand = await _context.Brand.SingleOrDefaultAsync(m => m.BrandId == id);
        //    if (brand == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Brand.Remove(brand);
        //    await _context.SaveChangesAsync();

        //    return Ok(brand);
        //}

        //private bool BrandExists(int id)
        //{
        //    return _context.Brand.Any(e => e.BrandId == id);
        //}
    }
}