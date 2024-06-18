using Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private ICharacterDto _characterDto;
        public CharacterController(ICharacterDto charDto)
        {
            _characterDto = charDto;
        }

        // GET: api/Character
        [HttpGet]
        public ActionResult<IEnumerable<Character>> GetCharacters()
        {
            return Ok(_characterDto.SearchCharacters(new CharacterSearchRequest()));
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(Guid id)
        {
            var character = _characterDto.GetRecordById(id);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // POST: api/Character
        [HttpPost]
        public ActionResult<Character> PostCharacter(Character character)
        {
            Guid newg = _characterDto.AddCharacter(character);
            return CreatedAtAction("PostCharacter", newg, newg);
        }

        // PUT: api/Character/5
        [HttpPut("{guid}")]
        public IActionResult PutCharacter(Guid guid, Character character)
        {
            bool IsGood = _characterDto.Update(guid, character);
            if (!IsGood) { return NotFound(); }

            return Ok();
        }

        // DELETE: api/Character/5
        [HttpDelete("{guid}")]
        public IActionResult DeleteCharacter(Guid guid)
        {
            bool IsGood = _characterDto.Delete(guid);
            if (!IsGood) { return NotFound(); }

            return NoContent();
        }

        [HttpGet("TryKeyedSingleton/big/{key}")]
        public IActionResult TryKeyedSingletonBig([FromKeyedServices("big")] ICache cache, string key)
        {
            return Ok(cache.GetData(key));
        }

        [HttpGet("TryKeyedSingleton/small/{key}")]
        public IActionResult TryKeyedSingletonSmall([FromKeyedServices("small")] ICache cache, string key)
        {
            return Ok(cache.GetData(key));
        }


        [HttpGet("SingletonFromParameter/{id}")]
        public IActionResult TrySingletonFromParameter([FromServices()] ICharacterDto cache, Guid id)
        {
            return Ok(cache.GetRecordById(id));
        }

        [HttpPost("Create/All")]
        public IActionResult CreateAllRecords()
        {
            _characterDto.AddRecords();
            return Ok();
        }
    }
}
