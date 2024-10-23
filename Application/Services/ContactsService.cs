using Application.Services.Dto;
using Application.Services.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services;

public class ContactsService : IContactService
{
    private readonly DataContext _context;

    public ContactsService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<Contact>> GetAllContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact> GetContact(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
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