namespace DemoEF8.Models;

public class Customer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<DateTime>? Visits { get; set; }
    public required DateOnly MemberSince { get; set; }
    public required CustomerDetails Details { get; set; }
}

public class CustomerDetails
{
   // public Guid Id { get; set; }
   public string? Region { get; set; }
   public List<string>? Notes { get; set; }
   public List<Address> Addresses { get; set; } = new();
   public List<Phone> Phones { get; set; } = new();
}

public class  Address { 
    // public Guid Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }   
    public required string PostCode { get; set; }
    public required string Country { get; set; }
    public bool IsPrimary { get; set; }
}

public class Phone
{
   // public Guid Id { get; set; }
   public required int CountryCode { get; set; }    
   public required string Number { get; set; }
   public bool IsPrimary { get; set; }
}