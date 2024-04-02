using mailProject._Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class MailContext : DbContext
{
    public MailContext(DbContextOptions options) : base(options) { }
    public DbSet<MailDetails> Mails
    {
        get;
        set;
    }
}
