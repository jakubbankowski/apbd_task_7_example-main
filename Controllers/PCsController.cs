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

    [HttpGet("{id}/components")]
    public async Task<ActionResult<PCResponseDTO>> GetPC(int id)
    {
        var pcExists = await _context.Pcs.AnyAsync(p => p.Id == id);
        if (!pcExists) return NotFound();

        var components = await _context.PcComponents
            .Where(pc => pc.PCId == id)
            .Select(pc => new PCComponentsResponseDTO
            {
                ComponentCode = pc.ComponentCode,
                ComponentName = pc.Component.Name,
                Amount = pc.Amount
            })
            .ToListAsync();
        return Ok(components);

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

    [HttpPut("{id}")]
    public async Task<ActionResult<IActionResult>> UpdatePC(int id, UpdatePCRequestDTO request)
    {
        var pc = await _context.Pcs.FindAsync(id);
        if (pc == null) return NotFound();
        
        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        await _context.SaveChangesAsync();
        return Ok(pc);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePC(int id)
    {
        var pc = await _context.Pcs.FindAsync(id);
        if (pc == null) return NotFound();

        _context.Pcs.Remove(pc);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}
