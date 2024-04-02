using BL;
using mailProject._Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mailProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mailController : ControllerBase
    {
        IMailBL _mailBL;
        public mailController(IMailBL mailBL)
        {
            _mailBL = mailBL; 
        }
        // GET: api/<mailController>
        [HttpGet]
        public async Task<ActionResult< IEnumerable<MailDetails>>> Get()
        {
            IEnumerable<MailDetails> mails = await _mailBL.getAllMailsAsync();
            return mails != null ? Ok(mails) : NotFound();
        }

        // GET api/<mailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<mailController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MailDetails mail)
        {
            MailDetails newMail = await _mailBL.createNewMailAsync(mail);
            return newMail != null ? CreatedAtAction(nameof(Get), new { id = newMail.Id }, newMail) : NoContent();
             
        }

        // PUT api/<mailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<mailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/<mailController>
        [HttpGet]
        [Route("sendMail")]
        public async Task<ActionResult<string>> SendMail()
        {
            string massage = await _mailBL.sendMails();
            return Ok(massage);
           
        }
    }
}
