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
    [Route("api/foto")]
    public class FotoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FotoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<FotoDTO>> GetFoto()
        {
            return await _context.Foto.ProjectTo<FotoDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<FotoDTO>> GetFotoId(int id)
        {
            if ( _context.Foto == null)
            {
                return NotFound();
            }
            var foto = await _context.Foto.ProjectTo<FotoDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdCandidatoFoto == id);
            if (foto == null)
            {
                return NotFound();
            }

            return foto;
        }
       
        //Criar foto
        [HttpPost]
        public async Task<ActionResult<FotoDTO>> PostFoto(FotoDTO fotoDTO)
        {
            var foto = _mapper.Map<Foto>(fotoDTO);
            _context.Add(foto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAplicacaoTrabalho(FotoDTO fotoDTO, int id)
        {
            var foto = await _context.Foto.FirstOrDefaultAsync(c => c.IdCandidatoFoto == id);
            if (foto == null)
            {
                return NotFound();
            }
            foto = _mapper.Map(fotoDTO, foto);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAplicacaoTrabalho(int id)
        {
            var foto = await _context.Foto.FirstOrDefaultAsync(c => c.IdCandidatoFoto == id);
            if (foto == null)
            {
                return NotFound();
            }
            _context.Foto.Remove(foto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
