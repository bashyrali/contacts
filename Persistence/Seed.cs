using Domain;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (context.Contacts.Any()) return;
        var contacts = new List<Contact>
        {
            new Contact
            {
                FirstName = "FirstName1",
                SecondName = "SecondName1",
                Email = "okay1@Email.com",
                PhoneNumber = "87771231212"
            },
            new Contact
            {
                FirstName = "FirstName2",
                SecondName = "SecondName2",
                Email = "okay2@Email.com",
                PhoneNumber = "87771231212"
            },
            new Contact
            {
                FirstName = "FirstName3",
                SecondName = "SecondName3",
                Email = "okay3@Email.com",
                PhoneNumber = "87771231212"
            },
            new Contact
            {
                FirstName = "FirstName4",
                SecondName = "SecondName4",
                Email = "okay4@Email.com",
                PhoneNumber = "87771231212"
            },
            new Contact
            {
                FirstName = "FirstName5",
                SecondName = "SecondName5",
                Email = "okay5@Email.com",
                PhoneNumber = "87771231212"
            },
            new Contact
            {
                FirstName = "FirstName6",
                SecondName = "SecondName6",
                Email = "okay6@Email.com",
                PhoneNumber = "87771231212"
            },
        };
        await context.Contacts.AddRangeAsync(contacts);
        await context.SaveChangesAsync();
    }
}