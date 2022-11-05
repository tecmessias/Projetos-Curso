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
    [Route("api/aplicacao")]
    public class AplicacaoTrabalhoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AplicacaoTrabalhoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<AplicacaoTrabalhoDTO>> GetAplicacaoTrabalho()
        {
            return await _context.AplicacaoTrabalho.ProjectTo<AplicacaoTrabalhoDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AplicacaoTrabalhoDTO>> GetAplicacaoTrabalho(int id)
        {
            if ( _context.AplicacaoTrabalho == null)
            {
                return NotFound();
            }
            var aplicacao = _context.AplicacaoTrabalho.ProjectTo<AplicacaoTrabalhoDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdAplicacao == id);
            if (aplicacao == null)
            {
                return NotFound();
            }

            return await aplicacao;
        }
        //get empresa
        [HttpGet("idEmpresa")]
        public async Task<ActionResult<AplicacaoTrabalhoDTO>> GetAplicacaoEmpresa(int idEmpresa)
        {
            if (_context.AplicacaoTrabalho == null)
            {
                return NotFound();
            }
            List<AplicacaoTrabalhoDTO> Listanova = (from a in _context.AplicacaoTrabalho
                                                    join b in _context.OfertaEmprego on a.IdOferta equals b.IdOferta
  
                                                    where b.IdEmpresa == idEmpresa 

                                                select new AplicacaoTrabalhoDTO
                                                {
                                                    IdAplicacao = a.IdAplicacao,
                                                    IdOferta = (int) a.IdOferta,
                                                    IdCandidato = (int)a.IdCandidato,

                                                }).ToList();

            return Ok(Listanova);
        }
        //get candidato
        [HttpGet("idCandidato")]
        public async Task<ActionResult<AplicacaoTrabalhoDTO>> GetAplicacaoCandidato(int idCandidato)
        {
            if (_context.AplicacaoTrabalho == null)
            {
                return NotFound();
            }
            List<AplicacaoTrabalhoDTO> Listanova = (from a in _context.AplicacaoTrabalho
                                                    join b in _context.Candidato on a.IdCandidato equals b.IdCandidato

                                                    where a.IdCandidato == idCandidato

                                                    select new AplicacaoTrabalhoDTO
                                                    {

                                                        IdAplicacao = a.IdAplicacao,
                                                        IdOferta = (int)a.IdOferta,
                                                        IdCandidato = (int)a.IdCandidato,

                                                    }).ToList();

            return Ok(Listanova);
        }


        //Criar aplicacao
        [HttpPost]
        public async Task<ActionResult> PostAplicacaoTrabalho(AplicacaoTrabalhoDTO aplicacaoDTO)
        {
            var aplicacao = _mapper.Map<AplicacaoTrabalho>(aplicacaoDTO);
            _context.Add(aplicacao);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAplicacaoTrabalho(AplicacaoTrabalhoDTO aplicacaoDTO, int id)
        {
            var aplicacao = await _context.AplicacaoTrabalho.FirstOrDefaultAsync(c => c.IdAplicacao == id);
            if (aplicacao == null)
            {
                return NotFound();
            }
            aplicacao = _mapper.Map(aplicacaoDTO, aplicacao);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAplicacaoTrabalho(int id)
        {
            var aplicacao = await _context.AplicacaoTrabalho.FirstOrDefaultAsync(c => c.IdAplicacao == id);
            if (aplicacao == null)
            {
                return NotFound();
            }
            _context.AplicacaoTrabalho.Remove(aplicacao);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
