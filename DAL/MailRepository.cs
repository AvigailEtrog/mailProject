using mailProject._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MailRepository
    {
        MailContext _mailContext;

        public MailRepository(MailContext mailContext)
        {
            _mailContext = mailContext;  
        }

        public async Task<MailDetails> createNewMailAsync(MailDetails mail)
        {
            await _mailContext.AddAsync(mail);
            await _mailContext.SaveChangesAsync();
            return mail;
        }
    }
}
