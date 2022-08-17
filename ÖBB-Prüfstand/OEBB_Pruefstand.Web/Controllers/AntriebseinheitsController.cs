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
    public class AntriebseinheitsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AntriebseinheitsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAntriebseinheiten()
        {
            return Ok(await this._uow.AntriebseinheitsRepository.GetAllAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OEBBAntriebseinheit>> CreateAntriebseinheit(OEBBAntriebseinheit antriebseinheit)
        {
            await this._uow.AntriebseinheitsRepository.AddAsync(antriebseinheit);
            await this._uow.SaveChangesAsync();
            return CreatedAtAction("GetAntriebseinheitByNummer", new {nummer = antriebseinheit.Nummer },  antriebseinheit);
        }

        [HttpGet("{nummer}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAntriebseinheitByNummer(string nummer)
        {
            return Ok(await this._uow.AntriebseinheitsRepository.GetByNummerAsync(nummer));
        }

        [HttpGet("/komponenten/{nummer}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAntriebskomponenten(string nummer)
        {
            return Ok(await this._uow.AntriebseinheitsRepository.GetAntriebskomponentenAsync(nummer));
        }

        [HttpDelete("{nummer}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAntriebseinheit(string nummer)
        {
            return await this._uow.AntriebseinheitsRepository.DeleteAsync(nummer) ? NoContent() : NotFound();
        }
    }
}
