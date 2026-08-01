using System;

namespace PaintStore.Models.Models;

public class User
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public User(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }


}
