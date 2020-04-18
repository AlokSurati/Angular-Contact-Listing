using Repository;
using RepoViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsRegAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactRegController : Controller
    {
        private readonly IContactRepository _contactRegRepository;

        public ContactRegController(IContactRepository contactRegRepository)
        {
            _contactRegRepository = contactRegRepository;
        }

        [HttpGet("GetAllContacts")]
        public async Task<List<ContactDTO>> GetAllContacts()
        {
            return await _contactRegRepository.GetAllContacts();
        }

        [HttpPost("AddContact")]
        public async Task<bool> AddContact([FromBody] ContactDTO model)
        {
            return await _contactRegRepository.AddContact(model);

        }

        [HttpPut("UpdateContact/{id}")]
        public async Task<bool> UpdateContact(int id, [FromBody] ContactDTO model)
        {
            return await _contactRegRepository.UpdateContact(model);

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteContact(string id)
        {
            return await _contactRegRepository.DeleteContact(id);
        }
    }
}
