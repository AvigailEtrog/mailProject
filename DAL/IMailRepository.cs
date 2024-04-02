using mailProject._Entities;

namespace DAL
{
    public interface IMailRepository
    {
        Task<MailDetails> createNewMailAsync(MailDetails mail);
        Task<IEnumerable<MailDetails>> getAllMailsAsync();
        Task<string> sendMails();
    }
}