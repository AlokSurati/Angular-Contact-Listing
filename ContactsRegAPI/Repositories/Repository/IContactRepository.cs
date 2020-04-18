using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RepoViewModels;

namespace Repository
{

    public interface IContactRepository
    {
        Task<List<ContactDTO>> GetAllContacts();
        Task<bool> AddContact(ContactDTO contactDTO);
        Task<bool> UpdateContact(ContactDTO contactDTO);
        Task<bool> DeleteContact(string id);
    }
}
