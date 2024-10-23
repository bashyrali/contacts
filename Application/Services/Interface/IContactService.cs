using Application.Services.Dto;
using Domain;

namespace Application.Services.Interface;

public interface IContactService
{
    //Интерфейс для сервиса Конатктов
    Task<PaginatedList<Contact>> GetAllContacts(int pageIndex, int pageSize);
    Task<Contact> GetContact(int id);
    Task CreateContact(CreateContactDto dto);
    Task UpdateContact(int id, UpdateContactDto dto);
    Task DeleteContact(int id);
}