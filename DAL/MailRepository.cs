using mailProject._Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MailRepository : IMailRepository
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


        public async Task<IEnumerable<MailDetails>> getAllMailsAsync()
        {
            return await _mailContext.Mails.ToListAsync();
        }

        public async Task<string> sendMails()
        {
            string s="";
            IEnumerable<MailDetails> mails = await getAllMailsAsync();
            if (mails != null)
            {
                List<MailDetails> mailsList = mails.ToList();
                for (int i = 0; i <1350; i++)
                {
                    MailMessage mailMessage = new MailMessage();
                    //mailMessage.From = new MailAddress("37214338766@mby.co.il","אגישמאקע ווארט");
                    mailMessage.From = new MailAddress("YadBeyad2024@gmail.com", "אגישמאקע ווארט");

                    mailMessage.To.Add($"{mailsList[i].Mail}");
                    mailMessage.Subject = "Subject";
                    mailMessage.Body = $"{mailsList[i].Name}";
                    Attachment attachment = new Attachment(@"M:\\d.pdf");

                    //// Add the attachment to the MailMessage object
                    mailMessage.Attachments.Add(attachment);
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    //smtpClient.Host = "smtp.mywebsitedomain.com";
                    smtpClient.Port = 587;
                    //smtpClient.UseDefaultCredentials = false;
                    //smtpClient.Credentials = new NetworkCredential("37214338766@mby.co.il", "Student@264");
                    smtpClient.Credentials = new NetworkCredential("YadBeyad2024@gmail.com", "rldm vxiq taeh ccko");
                    smtpClient.EnableSsl = true;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        s += $"{mailsList[i].Mail}  ";
                        
                    }
                    catch (Exception ex)
                    {
                        
                        s+= ex.Message;
                    }

                }
            }

            return s+= "";
        }
    }
}
