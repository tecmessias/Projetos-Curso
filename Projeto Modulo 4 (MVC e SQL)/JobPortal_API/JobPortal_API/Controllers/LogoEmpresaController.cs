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
    [Route("api/logo")]
    public class LogoEmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LogoEmpresaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<LogoEmpresaDTO>> GetLogo()
        {
            return await _context.LogoEmpresa.ProjectTo<LogoEmpresaDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<LogoEmpresaDTO>> GetFotoId(int id)
        {
            if ( _context.LogoEmpresa == null)
            {
                return NotFound();
            }
            var foto = await _context.Foto.ProjectTo<LogoEmpresaDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdEmpresaFoto == id);
            if (foto == null)
            {
                return NotFound();
            }

            return foto;
        }
       
        //Criar foto
        [HttpPost]
        public async Task<ActionResult<LogoEmpresaDTO>> PostFoto(LogoEmpresaDTO logoDTO)
        {
            var logo = _mapper.Map<Foto>(logoDTO);
            _context.Add(logo);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAplicacaoTrabalho(LogoEmpresaDTO logoDTO, int id)
        {
            var logo = await _context.LogoEmpresa.FirstOrDefaultAsync(c => c.IdEmpresaFoto == id);
            if (logo == null)
            {
                return NotFound();
            }
            logo = _mapper.Map(logoDTO, logo);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAplicacaoTrabalho(int id)
        {
            var logo = await _context.LogoEmpresa.FirstOrDefaultAsync(c => c.IdEmpresaFoto == id);
            if (logo == null)
            {
                return NotFound();
            }
            _context.LogoEmpresa.Remove(logo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
