using Microsoft.AspNetCore.Mvc;
using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.DTOs;
using OEBB_Pruefstand.Core.Entities;
using OEBB_Pruefstand.Logic;
using OEBB_Pruefstand.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        public FunctionRepository functionRepository;
        public KriterienRepository kriterienRepository;
        public ImportController ic = new ImportController();
        public Statistic statistic = new Statistic();

        public FunctionController(IUnitOfWork uow)
        {
            this.functionRepository = FunctionRepository.Instance;
            this.kriterienRepository = KriterienRepository.Instance;
        }


        [HttpGet("/{Zustand}/{FileName}")]
        public async Task<ActionResult<IEnumerable<OEBBFunktion>>> GetFunctions(string Zustand, string FileName)
        {
            ic.start(Zustand, FileName);
            return this.functionRepository.GetFunktionen();
        }

        [HttpGet("/criteria/{Zustand}/{FileName}")]
        public async Task<ActionResult<IEnumerable<Kriterium>>> GetKriterien(string Zustand, string FileName)
        {
            ic.start(Zustand, FileName);
            return this.kriterienRepository.Kriterien;
        }

        [HttpGet("errors/{Zustand}/{Year?}/{Month?}/{Day?}")]
        public async Task<ActionResult<IEnumerable<StatisticFehlerDTO>>> GetErrors(string Zustand, string Year = "", string Month = "", string Day = "")
        {
            return statistic.Analysis(Zustand, Year, Month, Day);
        }

    }
}
