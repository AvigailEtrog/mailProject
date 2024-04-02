using DAL;
using mailProject._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MailBL : IMailBL
    {
        IMailRepository _mailRepository;
        public MailBL(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }
        public async Task<MailDetails> createNewMailAsync(MailDetails mail)
        {
            MailDetails mailCreated = await _mailRepository.createNewMailAsync(mail);
            return mailCreated != null ? mailCreated : null;
        }

        public async Task<IEnumerable<MailDetails>> getAllMailsAsync()
        {
            IEnumerable<MailDetails> mails = await _mailRepository.getAllMailsAsync();
            return mails != null ? mails : null;
        }

        public async Task<string> sendMails()
        {
            string massage = await _mailRepository.sendMails();
            return massage;
        }
    }
}
