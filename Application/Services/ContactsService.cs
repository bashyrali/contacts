using Application.Services.Dto;
using Application.Services.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services;
//Реализация интерфейса для сервиса контактов
public class ContactsService : IContactService
{
    private readonly DataContext _context;

    public ContactsService(DataContext context)
    {
        _context = context;
    }


    public async Task<PaginatedList<Contact>> GetAllContacts(int pageIndex, int pageSize)
    {
        var contacts = await _context.Contacts.OrderBy(c => c.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var count = await _context.Contacts.CountAsync();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);
        return new PaginatedList<Contact>(contacts, pageIndex,totalPages);
    }

    public async Task<Contact> GetContact(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        if (contact == null)
        {
            return null;
        }
        return contact;
    }

    public async Task CreateContact(CreateContactDto dto)
    {
        var newContact = new Contact()
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
        };
        _context.Add(newContact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContact(int id, UpdateContactDto dto)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        if (contact == null)
        {
            return;
        }

        contact.FirstName = dto.FirstName;
        contact.SecondName = dto.SecondName;
        contact.Email = dto.Email;
        contact.PhoneNumber = dto.PhoneNumber;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteContact(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        if (contact == null)
        {
            return;
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
    }
}