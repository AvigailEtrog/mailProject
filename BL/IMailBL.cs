using mailProject._Entities;

namespace BL
{
    public interface IMailBL
    {
        Task<MailDetails> createNewMailAsync(MailDetails mail);
        Task<IEnumerable<MailDetails>> getAllMailsAsync();
        Task<string> sendMails();
    }
}