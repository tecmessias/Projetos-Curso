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
    [Route("api/oferta")]
    public class OfertaEmpregoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OfertaEmpregoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<OfertaEmpregoDTO>> GetOfertaEmprego()
        {
            return await _context.OfertaEmprego.ProjectTo<OfertaEmpregoDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        //busca por ID Oferta
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OfertaEmpregoDTO>> GetOfertaEmprego(int id)
        {
            if (_context.OfertaEmprego == null)
            {
                return NotFound();
            }
            var oferta = _context.OfertaEmprego.ProjectTo<OfertaEmpregoDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdOferta == id);
            if (oferta == null)
            {
                return NotFound();
            }
            return await oferta;
        }



        //busca por ID Empresa *carregar na home*
      
        [HttpGet("idEmpresa")]
        public async Task<ActionResult<OfertaEmpregoDTO>> GetOfertaEmpresa(int idEmpresa)
        {
            if (_context.OfertaEmprego == null)
            {
                return NotFound();
            }
            List<OfertaEmpregoDTO> Listanova = (from a in _context.OfertaEmprego
                                                where a.IdEmpresa == idEmpresa
                                                select new OfertaEmpregoDTO
                                                {
                                                    IdOferta = a.IdOferta,
                                                    IdEmpresa = a.IdEmpresa,

                                                }).ToList();

             return Ok(Listanova);
        }

        //Criar 
        [HttpPost]
        public async Task<ActionResult> PostOfertaEmprego(OfertaEmpregoDTO ofertaDTO)
        {
            var oferta = _mapper.Map<OfertaEmprego>(ofertaDTO);
            _context.Add(oferta);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutOfertaEmprego(OfertaEmpregoDTO ofertaDTO, int id)
        {
            var oferta = await _context.OfertaEmprego.FirstOrDefaultAsync(c => c.IdOferta == id);
            if (oferta == null)
            {
                return NotFound();
            }
            oferta = _mapper.Map(ofertaDTO, oferta);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteOfertaEmprego(int id)
        {
            var oferta = await _context.OfertaEmprego.FirstOrDefaultAsync(c => c.IdOferta == id);
            if (oferta == null)
            {
                return NotFound();
            }
            _context.OfertaEmprego.Remove(oferta);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
