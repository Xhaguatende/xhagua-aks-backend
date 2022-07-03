using Microsoft.EntityFrameworkCore;
using Xhagua.Aks.Backend.Api.DataAccess;

namespace Xhagua.Aks.Backend.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BackController : ControllerBase
{
    #region Private Fields

    private readonly XhaguaContext _context;

    private readonly ILogger<BackController> _logger;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public BackController(ILogger<BackController> logger, XhaguaContext context)
    {
        _logger = logger;
        _context = context;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpDelete("mytable/{id:int}")]
    public async Task<IActionResult> DeleteMyTableAsync(int id)
    {
        var existingMyTable = await _context.MyTables.FirstOrDefaultAsync(x => x.Id == id);

        if (existingMyTable == null)
        {
            return NotFound($"Record not found for Id={id}!");
        }

        _context.Remove(existingMyTable);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("mytable/{id:int}")]
    public async Task<IActionResult> GetMyTableAsync(int id)
    {
        var myTable = await _context.MyTables.FirstOrDefaultAsync(x => x.Id == id);

        if (myTable == null)
        {
            return NotFound($"Record not found for Id={id}!");
        }

        return Ok(myTable);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpPost("mytable")]
    public async Task<IActionResult> InsertMyTableAsync(MyTable myTable)
    {
        _context.MyTables.Add(myTable);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMyTableAsync),
            new { id = myTable.Id },
            myTable);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        _logger.LogInformation("Pinging API...");

        var response = new { Message = "Hello World!", Date = DateTime.UtcNow };

        return Ok(response);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpPut("mytable")]
    public async Task<IActionResult> UpdateMyTableAsync(MyTable myTable)
    {
        var existingMyTable = await _context.MyTables.FirstOrDefaultAsync(x => x.Id == myTable.Id);

        if (existingMyTable == null)
        {
            return NotFound($"Record not found for Id={myTable.Id}!");
        }

        _context.Entry(existingMyTable).CurrentValues.SetValues(myTable);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    #endregion Public Methods
}