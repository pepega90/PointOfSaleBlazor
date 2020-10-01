using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.RepositoryInterface;
using PointOfSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private readonly IBarangRepository barangRepository;

        public BarangController(IBarangRepository barangRepository)
        {
            this.barangRepository = barangRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetBarangs()
        {
            try
            {
                return Ok(await barangRepository.GetAllBarang());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error saat fetch seluruh barang");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Barang>> GetBarang(int id)
        {
            try
            {
                var findBarang = await barangRepository.GetBarang(id);

                if (findBarang == null) return NotFound($"Barang dengan id = {id} tidak ditemukan");

                return findBarang;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    , $"Error saat fetch single barang dengan id = {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Barang>> TambahBarang(Barang barang)
        {
            try
            {
                if (barang == null) return NotFound($"Barang yang ingin dibuat tidak ditemukan");

                var createdBarang = await barangRepository.AddBarang(barang);

                return CreatedAtAction(nameof(GetBarang), new { id = createdBarang.Id }, createdBarang);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                       , $"Error saat buat barang");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Barang>> UpdateBarang(Barang barang)
        {
            try
            {
                var updateBarang = await barangRepository.GetBarang(barang.Id);

                if (updateBarang == null) return NotFound($"barang dengan id = {barang.Id} tidak ditemukan");

                return await barangRepository.EditBarang(barang);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                       , $"Error saat update barang");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Barang>> HapusBarang(int id)
        {
            try
            {
                var findBarang = await barangRepository.GetBarang(id);

                if (findBarang == null) return NotFound($"barang dengan id = {id} tidak ditemukan");

                return await barangRepository.DeleteBarang(findBarang.Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                       , $"Error saat menghapus barang dengan id = {id}");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Barang>>> SearchBarang(string namaProduk)
        {
            try
            {
                var searchingBarang = await barangRepository.CariBarang(namaProduk);

                if (searchingBarang.Any())
                    return Ok(searchingBarang);

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                $"Error saat sedang mencari post");
            }
        }
    }
}
