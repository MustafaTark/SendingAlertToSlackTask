using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SendingAlertToSlackTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlackController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ReceiveSpamNotification([FromBody] SpamNotificationPayload payload)
        {
            if (payload.Type!.ToLower().Contains("spam"))
            {
                // Send Slack alert
                await SendSlackAlert(payload);

                return Ok();
            }

            return BadRequest("Not a spam notification");
        }
        private async Task SendSlackAlert(SpamNotificationPayload spam)
        {
            var slackWebhookUrl = "https://hooks.slack.com/services/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";
            var httpClient = new HttpClient();

            var payload = new
            {
                RecordType = spam.RecordType,
                Type = spam.Type,
                TypeCode = spam.TypeCode,
                Name = spam.Name,
                Tag = spam.Tag,
                MessageStream = spam.MessageStream,
                Description = spam.Description,
                Email = spam.Email,
                from = spam.From,
                BouncedAt = spam.BouncedAt
           
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload.MessageStream), Encoding.UTF8, "application/json");
            await httpClient.PostAsync(slackWebhookUrl, content);

            
        }
    }
}
