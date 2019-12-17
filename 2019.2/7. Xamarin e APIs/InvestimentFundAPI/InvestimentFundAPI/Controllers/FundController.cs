using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestimentFundAPI.Data;
using InvestimentFundAPI.Model;

namespace InvestimentFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundController : ControllerBase
    {
        private readonly DataContext _context;

        public FundController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Fund
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fund>>> GetFund()
        {
            return await _context.Funds.ToListAsync();
        }

        // GET: api/Fund/5
        [HttpGet("{name}")]
        public async Task<List<Fund>> GetFund(string name)
        {
            var fund = await _context.Funds.Where(f => f.Name.Equals(name)).ToListAsync();
            return fund;
        }

        // POST: api/Fund
        [HttpPost]
        public async Task<ActionResult<Fund>> PostFund(Fund fund)
        {
            fund.Date = DateTime.Now;
            _context.Funds.Add(fund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFund", new { Name = fund.Name }, fund);
        }
    }
}
