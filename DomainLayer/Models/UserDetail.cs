using System;
using System.Collections.Generic;

namespace DomainLayer.Models;

public class UserDetail:BaseEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? AddedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
