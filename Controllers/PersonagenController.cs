using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Personagens{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagenController : ControllerBase{
        private readonly Data _context;

        public PersonagenController(Data context){
            this._context=context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personagen>>> GetAll(){
            return Ok(await _context.personagens.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Personagen>>> Post(Personagen personagem){
            _context.personagens.Add(personagem);
            await _context.SaveChangesAsync();
            return Ok(await _context.personagens.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Personagen>>> Put(Personagen personagem){
            Personagen? p = await _context.personagens.FindAsync(personagem.Id);
            if(p == null){
                return BadRequest("Personagem não encontrado");
            }
            p.name = personagem.name;
            p.Descricao = personagem.Descricao;
            p.Id = personagem.Id;
            await _context.SaveChangesAsync();
            return Ok(await _context.personagens.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            Personagen? personagen = await _context.personagens.FindAsync(id);
            if(personagen == null){
                return BadRequest("Personagem não encontrado");
            }
            _context.personagens.Remove(personagen);
            await _context.SaveChangesAsync();
            return Ok(_context.personagens.ToListAsync());
        }
    }
}