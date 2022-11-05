using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal_API.Data;
using JobPortal_API.DTOs;
using JobPortal_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JobPortal_API.Controllers
{
    [Route("api/cv")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CVController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //todos os registros e detalhes das chaves sem o mapp
        [HttpGet]
        public async Task<IEnumerable<CV>> GetCv()
        {
            return await _context.CV.ToListAsync();
        }

        //trás todos os registros com mapp
        //[HttpGet]
        //public async Task<IEnumerable<CVDTO>> GetCv()
        //{
        //    return await _context.CV.ProjectTo<CVDTO>(_mapper.ConfigurationProvider).ToListAsync();
        //}

        //busca por ID CV
        [HttpGet("{id}")]
        public async Task<ActionResult<CVDTO>> GetCv(int id)
        {
            if (_context.CV == null)
            {
                return NotFound();
            }
            var cv = _context.CV.ProjectTo<CVDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdCV == id);
            if (cv == null)
            {
                return NotFound();
            }

            return await cv;
        }
        //busca por ID Candidato
        [HttpGet("IdCandidato")]
        public async Task<ActionResult<CVDTO>> GetCvCandidato(int idCandidato)
        {
            if (_context.CV == null)
            {
                return NotFound();
            }
            var cv = _context.CV.ProjectTo<CVDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdCandidatoCv == idCandidato);
            if (cv == null)
            {
                return NotFound();
            }

            return await cv;
        }
        //create CV
        [HttpPost]
        public async Task<ActionResult> PostCv(CVDTO cvDTO)
        {
            var cv = _mapper.Map<CV>(cvDTO);
            _context.CV.Add(cv);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Edit/Update id CD
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> PutCv(CVDTO cvDTO, int id)
        //{
        //    var cv = await _context.CV.FirstOrDefaultAsync(c => c.IdCV == id);
        //    if(cv == null)
        //    {
        //        return NotFound();
        //    }
        //    cv = _mapper.Map(cvDTO, cv);

        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}

        //Edit/Update id Candidato
        [HttpPut]
        public async Task<ActionResult> PutCv(CVDTO cvDTO, int idCandidato)
        {
            var cv = await _context.CV.FirstOrDefaultAsync(c => c.IdCandidatoCv == idCandidato);
            if (cv == null)
            {
                return NotFound();
            }
            cv = _mapper.Map(cvDTO, cv);

            await _context.SaveChangesAsync();
            return Ok();
        }

        //delete
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> DeleteCv(int id)
        //{
        //    var cv = await _context.CV.FirstOrDefaultAsync(c => c.IdCV == id);
        //    if (cv == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.CV.Remove(cv);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
