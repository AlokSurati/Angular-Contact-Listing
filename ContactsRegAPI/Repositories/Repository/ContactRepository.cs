using System.Collections.Generic;
using System.Linq;
using RepoViewModels;
using MongoDbGenericRepository;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Repository{

    public class ContactRepository : BaseMongoRepository, IContactRepository
    {
        private readonly IMongoDatabase oMongoDatabase;

        public ContactRepository(IMongoDatabase db) 
            : base(db)
        {
            oMongoDatabase = db;
        }


        public async Task<List<ContactDTO>> GetAllContacts()
        {
            List<ContactDTO> contactDTOs = new List<ContactDTO>();
            var contactDocs = await GetAllAsync<ContactDocument>(d => 1 == 1);
            contactDTOs = contactDocs.Select(d => d.AsContactDTO()).ToList();
            return contactDTOs;
        }

        public async Task<List<ContactDTO>> GetAllActiveContacts()
        {
            List<ContactDTO> contactDTOs = new List<ContactDTO>();
            var contactDocs = await GetAllAsync<ContactDocument>(d => d.Status == true);
            contactDTOs = contactDocs.Select(d => d.AsContactDTO()).ToList();
            return contactDTOs;
        }

        public async Task<bool> AddContact(ContactDTO contactDTO)
        {
            await AddOneAsync(contactDTO.AsContactDocument());
            return true;
        }

        public async Task<bool> UpdateContact(ContactDTO contactDTO)
        {
            await UpdateOneAsync(contactDTO.AsContactDocument());
            return true;
        }

        public async Task<bool> DeleteContact(string Id)
        {
            await DeleteOneAsync<ContactDocument>(d => d.Id == Guid.Parse(Id));
            return true;
        }
    }

    public static class ContactDocumentExtension
    {
        internal static ContactDTO AsContactDTO(this ContactDocument contactDoc)
        {
            return new ContactDTO()
            {
                ContactId = contactDoc.Id.ToString(),
                FirstName = contactDoc.FirstName,
                LastName = contactDoc.LastName,
                Email = contactDoc.Email,
                Phone = contactDoc.Phone,
                Status = contactDoc.Status,
                CreatedAt = contactDoc.AddedAtUtc,
            };
        }

        internal static ContactDocument AsContactDocument(this ContactDTO contactDTO)
        {
            return new ContactDocument()
            {
                Id = string.IsNullOrEmpty(contactDTO.ContactId) ? Guid.NewGuid() : Guid.Parse(contactDTO.ContactId),
                FirstName = contactDTO.FirstName,
                LastName = contactDTO.LastName,
                Email = contactDTO.Email,
                Phone = contactDTO.Phone,
                Status = contactDTO.Status,
            };
        }
    }
}
