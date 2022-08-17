using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AntriebskomponentenController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AntriebskomponentenController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("{nummer}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetKomponenteByNummer(string nummer)
        {
            return Ok(await this._uow.AntriebskomponentenRepository.GetKomponenteByNummer(nummer));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllKomponenten()
        {
            return Ok(await this._uow.AntriebskomponentenRepository.GetAllAsync());
        }

        [HttpDelete("{nummer}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteKomponente(string nummer)
        {
            return await this._uow.AntriebskomponentenRepository.DeleteAsync(nummer) ? NoContent() : NotFound();  
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateKomponente(OEBBAntriebskomponenten antriebskomponente)
        {
            await this._uow.AntriebskomponentenRepository.AddAsync(antriebskomponente);
            await this._uow.SaveChangesAsync();
            return CreatedAtAction("GetKomponenteByNummer", new { nummer = antriebskomponente.Nummer}, antriebskomponente);
        }
    }
}
