using Application.Services.Dto;
using Domain;

namespace Application.Services.Interface;

public interface IContactService
{
    Task<List<Contact>> GetAllContacts();
    Task<Contact> GetContact(int id);
    Task CreateContact(CreateContactDto dto);
    Task UpdateContact(int id, UpdateContactDto dto);
    Task DeleteContact(int id);
}