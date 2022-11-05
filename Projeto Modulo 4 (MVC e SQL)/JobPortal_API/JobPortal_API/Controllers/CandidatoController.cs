using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal_API.Data;
using JobPortal_API.DTOs;
using JobPortal_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_API.Controllers
{
    [ApiController]
    [Route("api/candidato")]
    public class CandidatoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CandidatoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<CandidatoDTO>> GetCandidato()
        {
            return await _context.Candidato.ProjectTo<CandidatoDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatoDTO>> GetCandidato(int id)
        {
            if ( _context.Candidato == null)
            {
                return NotFound();
            }
            var candidato = _context.Candidato.ProjectTo<CandidatoDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return await candidato;
        }

        ////busca por nome 
        //[HttpGet("{filter}")]
        //public async Task<IEnumerable<Candidato>> Filter(string nome)
        //{
        //    return await _context.Candidato.Where(m => m.Nome.Contains(nome)).ToListAsync();
           
        //}
        //Criar candidato
        [HttpPost]
        public async Task<ActionResult> PostCandidato(CandidatoDTO candidatoDTO)
        {
            var candidato = _mapper.Map<Candidato>(candidatoDTO);
            _context.Add(candidato);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //editar candidato
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutCandidato(CandidatoDTO candidatoDTO, int id)
        {
            var candidato = await _context.Candidato.FirstOrDefaultAsync(c => c.IdCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }
            candidato = _mapper.Map(candidatoDTO, candidato);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCandidato(int id)
        {
            var candidato = await _context.Candidato.FirstOrDefaultAsync(c => c.IdCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }
            _context.Candidato.Remove(candidato);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
