using APBD_TASK_7.Data;
using APBD_TASK_7.DTOs;
using APBD_TASK_7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_TASK_7.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PCsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<PCResponseDTO>>> GetPCs()
    {
        var pcs = await _context.Pcs
            .Select(p => new PCResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
        return Ok(pcs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PCResponseDTO>> GetPC(int id)
    {
        var pc = await _context.Pcs.Select(
            p => new PCResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            }).Where(p => p.Id == id).FirstOrDefaultAsync();
        return Ok(pc);
    }

    [HttpPost]
    public async Task<ActionResult<PC>> CreatePC(CreatePCRequestDTO request)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock,
        };
        _context.Pcs.Add(pc);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPCs), new { id = pc.Id }, pc);
    }
}