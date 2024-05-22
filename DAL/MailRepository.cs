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
            string s = "";
            //IEnumerable<MailDetails> mails = await getAllMailsAsync();
            //if (mails != null)
            //{
            //    List<MailDetails> mailsList = mails.ToList();

            MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("37214338766@mby.co.il","אגישמאקע ווארט");
            mailMessage.From = new MailAddress("gishmakevort@gmail.com", "אגישמאקע ווארט");

            mailMessage.To.Add("37214338766@mby.co.il");
            mailMessage.Subject = "אגישמקע וורט פרשת צו";

            Attachment attachment = new Attachment(@"M:\\d.pdf");
            //// Add the attachment to the MailMessage object
            mailMessage.Attachments.Add(attachment);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<p>שבת שלום</p>" +
        " <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\">" +
        "<tbody><tr><td align=\"center\" style=\"padding:0 30px\"><table dir=\"ltr\" width=\"600\" " +
        "cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td style=\"padding-top:30px;" +
        "padding-bottom:25px;min-width:100%\"><table cellspacing=\"0\" " +
        "cellpadding=\"0\" border=\"0\" align=\"center\" width=\"100%\" " +
        "style=\"border-top:1px dashed #ccc;height:0;min-width:100%\" dir=\"rtl\"><tbody>" +
        "<tr><td style=\"font-size:0;line-height:0;min-width:100%\">&nbsp;</td></tr>" +
        "</tbody></table></td></tr><tr><td><table dir=\"rtl\" align=\"center\" cellspacing=\"0\" " +
        "cellpadding=\"0\" style=\"font-family:arial;font-size:12px;color:#707070;line-height:14pt\">" +
        "<tbody><tr><td align=\"center\">אם אינכם רואים מייל זה - " +
        "<a href=\"https://members.smoove.io/view.ashx?message=h51124219O125670141O171189O125650328&amp;r=1009\"" +
        " style=\"text-decoration:none;color:#707070\" target=\"_blank\" " +
        "data-saferedirecturl=\"https://www.google.com/url?q=https://members.smoove.io/view.ashx?message%3Dh51124219O125670141O171189O125650328%26r%3D1009&amp;" +
        "source=gmail&amp;ust=1712185127114000&amp;usg=AOvVaw0NP_IrneCvviS9KP0SZDvK\">לחצו כאן</a></td></tr><tr><td align=\"center\">" +
        "<a href=\"https://portal.smoove.io/n19dbqynbgz9nqentjb/profile/update/qb9o93chn3?c=he-IL\" style=\"text-decoration:none;color:#707070\" " +
        "target=\"_blank\" data-saferedirecturl=" +
        "\"https://www.google.com/url?q=https://portal.smoove.io/n19dbqynbgz9nqentjb/profile/update/qb9o93chn3?c%3Dhe-IL&amp;" +
        "source=gmail&amp;ust=1712185127114000&amp;usg=AOvVaw0AATSNniZ6LjoOqlb3TD2Q\">עדכון פרטים</a> |" +
        " <a href=\"http://localhost:3000/fdsg1hjk5g\" style=\"text-decoration:none;color:#707070\" target=\"_blank\" data-saferedirecturl=\"http://localhost:3000/1;\">הסרה</a> |" +
        " <a href=\"https://members.viplus.com/abuse,he-IL,51124219O125670141O171189O125650328.aspx?r=1009\" style=\"text-decoration:none;color:#707070\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://members.viplus.com/abuse,he-IL,51124219O125670141O171189O125650328.aspx?r%3D1009&amp;source=gmail&amp;ust=1712185127114000&amp;usg=AOvVaw10NEsknEvyIYdFVfMwTK5-\">דיווח כספאם</a></td></tr><tr><td align=\"center\"></td></tr><tr><td>&nbsp;</td></tr>" +
        "<tr><td align=\"center\"><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"font-family:arial;font-size:12px;color:#707070;line-height:14pt\"><tbody><tr><td valign=\"middle\" height=\"16\" style=\"vertical-align:middle\"> נשלח באמצעות <a style=\"color:#470e8b;text-decoration:none\" href=\"https://smoove.io/he\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://smoove.io/he&amp;source=gmail&amp;ust=1712185127114000&amp;usg=AOvVaw3gezw0YCRAaQeWsn9eMckA\">smoove&nbsp;</a></td><td valign=\"middle\" height=\"16\" width=\"18\" style=\"vertical-align:middle\">" +
        " <img src=\"https://ci3.googleusercontent.com/meips/ADKq_NZpjC4GG9csGa3d366pRtRqQPeaedRJiZVil8WouhshRGCz1OUil_udsNDP3e0HQAy0d9_kV65Eb_vh9rshTdbrTHwxGjJQK-w-1obnnwaUhYQ4qR9M2-Bh7mEH6WC7FcqQ-gNV75zUvhzbBwzX6VQ4FS_RWw=s0-d-e1-ft#http://content.smoove.io/51124219O125670141O171189O125650328O74535523/v/smoove.gif?v=1711584452\" width=\"16\" height=\"16\" style=\"vertical-align:bottom;display:block\" alt=\"\" class=\"CToWUd\" data-bit=\"iit\"></td></tr></tbody></table></td></tr><tr><td>&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td>" +
        "</tr></tbody>" +
        "</table>";


            //smtpClient.Host = "smtp.mywebsitedomain.com";
            smtpClient.Port = 587;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential("37214338766@mby.co.il", "Student@264");
            smtpClient.Credentials = new NetworkCredential("gishmakevort@gmail.com", "dujmllbtmvxjzfrs");
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mailMessage);
                s += "succfull";

            }
            catch (Exception ex)
            {

                s += ex.Message;
            }




            return s += "";
        }
    }
}
