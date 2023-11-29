using CadastroDePessoa.Entity;
using CadastroDePessoa.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;


namespace CadastroDePessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioDbContext _context;

        public UsuariosController(UsuarioDbContext context)
        {
            _context = context;
        }

        // api/Usuarios [GET]
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _context.Usuarios.Where(u => !u.IsDeleted).ToList();

            return Ok(usuarios);
        }

        // api/Usuarios/{id} [GET]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

            if(usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // api/Usuarios [POST]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // api/Usuarios/{id} [PUT]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Usuario input)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Update(input.Name, input.Email, input.Password, input.CreatedAt, input.UpdatedAt);
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return NoContent();
        }

        // api/Usuario/{id} [DELETE]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Delete();
            _context.SaveChanges();

            return NoContent();
        }
    }
}
