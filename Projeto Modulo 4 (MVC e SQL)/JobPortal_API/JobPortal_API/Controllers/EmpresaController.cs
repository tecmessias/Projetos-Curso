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
    [Route("api/empresa")]
    public class EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmpresaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        //todos os registros
        [HttpGet]
        public async Task<IEnumerable<EmpresaDTO>> GetEmpresa()
        {
            return await _context.Empresa.ProjectTo<EmpresaDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        //busca por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDTO>> GetEmpresa(int id)
        {
            if ( _context.Empresa == null)
            {
                return NotFound();
            }
            var empresa = _context.Empresa.ProjectTo<EmpresaDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return await empresa;
        }
        //criar empresa
        [HttpPost]
        public async Task<ActionResult> PostEmpresa(EmpresaDTO empresaDTO)
        {
            var empresa = _mapper.Map<Empresa>(empresaDTO);
            _context.Add(empresa);
            await _context.SaveChangesAsync();
            return Ok();
        }
       
        //Edit/Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutEmpresa(EmpresaDTO empresaDTO, int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(c => c.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }
            empresa = _mapper.Map(empresaDTO, empresa);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(c => c.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
