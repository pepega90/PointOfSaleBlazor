using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointOfSale.Api.RepositoryInterface;
using Microsoft.AspNetCore.Http;
using PointOfSale.Model;

namespace PointOfSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangPembeliController : ControllerBase
    {
        private readonly IBarangPembeliRepository barangPembeliRepository;
        private readonly IBarangRepository barangRepository;

        public BarangPembeliController(IBarangPembeliRepository barangPembeliRepository,
                                        IBarangRepository barangRepository)
        {
            this.barangPembeliRepository = barangPembeliRepository;
            this.barangRepository = barangRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBarangPembeli()
        {
            try
            {
                return Ok(await barangPembeliRepository.GetBarangPembelis());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    , "Error while fetch all barang pembeli");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BarangPembeli>> GetBarangPembeli(int id)
        {
            try
            {
                var barang = await barangPembeliRepository.GetBarangPembeli(id);

                if (barang == null) return NotFound($"Barang pembeli dengan id = {id} tidak ditemukan");

                return barang;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    , $"Error saat mengambil barang pembeli dengan id = {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<BarangPembeli>> BeliBarang(BarangPembeliData barangPembeliData)
        {
            try
            {
                var selectedBarang = await barangRepository.GetBarang(barangPembeliData.Id);

                if (selectedBarang == null) return NotFound($"barang yang ingin dibeli tidak ditemukan");

                var barangPembeli = await barangPembeliRepository.BeliBarang(selectedBarang, barangPembeliData.Qyt);

                return CreatedAtAction(nameof(GetBarangPembeli), new { id = barangPembeli.Id }, barangPembeli);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    , $"Error saat membeli barang pembeli dengan id = {barangPembeliData.Id}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BarangPembeli>> HapusBarangPembeli(int id)
        {
            try
            {
                var barangPembeli = await barangPembeliRepository.GetBarangPembeli(id);

                if (barangPembeli == null) return NotFound($"Barang pembeli dengan id = {id} tidak ditemukan");

                return await barangPembeliRepository.HapusBarang(barangPembeli.Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error saat menghapus barang pembeli dengan id = {id}");
            }
        }
    }
}
