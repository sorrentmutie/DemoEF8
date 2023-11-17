﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
await using(var context = new CustomersDbContext())
{
    //await context.Database.EnsureDeletedAsync();
    //await context.Database.EnsureCreatedAsync();

    //foreach (var item in FeedData())
    //{
    //    context.Customers.Add(item);
    //}
    //await context.SaveChangesAsync();

    //var c = await context.Set<Customer>().ToListAsync();
    //Console.WriteLine($"Numero di clienti: {c.Count}");
    //foreach (var item in c)
    //{
    //    item.Details.Region = "Campania";
    //}
    //await context.SaveChangesAsync(); 
    //Console.WriteLine("Fine");


    #region Query speciale 1
        var customers = await context.Customers
            .Where(c => c.Details.Region == "Campania")
            .ToListAsync();

        Console.WriteLine(customers.Count);

    #endregion
}

List<Customer> FeedData()
{
    var customers = new List<Customer>();
    for (int i = 0; i < 100; i++)
    {
        var nuovoUser = new Customer
        {
            Id = Guid.NewGuid(),
            Name = $"{i}Mario Rossi",
            Visits = new List<DateTime> { DateTime.UtcNow },
            MemberSince = new DateOnly(2020, 1, 1),
            Details = new CustomerDetails
            {
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Street = "Via Roma",
                        City = "Roma",
                        PostCode = "00100",
                        Country = "Italia",
                        IsPrimary = true
                    }
                },
                Phones = new List<Phone>
                {
                    new Phone
                    {
                        CountryCode = 39,
                        Number = "123456789",
                        IsPrimary = true
                    }
                },
                Region = "Lazio",
                Notes = new List<string> { "Note 1", "Note 2" }
            }
        };
        customers.Add(nuovoUser);
    }
    return customers;
}