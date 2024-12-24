using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using Microsoft.AspNetCore;
namespace RestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApiDbContext _context;
    private readonly ILogger<UsersController> _logger;

    public UsersController(ApiDbContext context, ILogger<UsersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        try
        {
            _logger.LogInformation("Getting all users");
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting users");
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            _logger.LogInformation("Getting user with ID: {Id}", id);
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                _logger.LogWarning("User not found with ID: {Id}", id);
                return NotFound(new { message = $"User with ID {id} not found" });
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting user {Id}", id);
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            _logger.LogInformation("Creating new user");
            user.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating user");
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest(new { message = "ID mismatch" });
        }

        try
        {
            _logger.LogInformation("Updating user with ID: {Id}", id);
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user).Property(x => x.CreatedAt).IsModified = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await UserExists(id))
            {
                return NotFound(new { message = $"User with ID {id} not found" });
            }
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating user {Id}", id);
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            _logger.LogInformation("Deleting user with ID: {Id}", id);
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting user {Id}", id);
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    private async Task<bool> UserExists(int id)
    {
        return await _context.Users.AnyAsync(e => e.Id == id);
    }
}

