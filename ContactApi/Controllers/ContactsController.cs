using Application.Services.Dto;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts(int pageIndex = 1, int pageSize = 10)
    {
        try
        {
            var contacts = await _contactService.GetAllContacts(pageIndex, pageSize);
            return Ok(contacts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        try
        {
            var contact = await _contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound($"Contact with id {id} not found");
            }

            return Ok(contact);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] CreateContactDto dto)
    {
        try
        {
            await _contactService.CreateContact(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactDto dto)
    {
        try
        {
            await _contactService.UpdateContact(id, dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        try
        {
            await _contactService.DeleteContact(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}