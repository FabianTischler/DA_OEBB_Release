using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OEBB_Pruefstand.Core.Contracts;
using Microsoft.AspNetCore.Http;
using OEBB_Pruefstand.Core.Entities;

namespace OEBB_Pruefstand.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrueferController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PrueferController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPruefer()
        {
            return Ok(await this._uow.PrueferRepository.GetAllAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<OEBBPruefer>> CreatePruefer(OEBBPruefer pruefer)
        {
            await this._uow.PrueferRepository.AddAsync(pruefer);
            await this._uow.SaveChangesAsync();
            return CreatedAtAction("GetPrueferById", new { id = pruefer.Id }, pruefer);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePruefer(int id)
        {
            return await this._uow.PrueferRepository.DeleteAsync(id) ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OEBBPruefer>> GetPrueferById(int id)
        {
            return Ok(await this._uow.PrueferRepository.GetPrueferById(id));
        }
    }
}
