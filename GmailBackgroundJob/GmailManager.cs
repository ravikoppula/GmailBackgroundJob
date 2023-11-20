using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Linq;

namespace GmailBackgroundJob
{
    public class GmailManager
    {
        private readonly GmailService _gmailService;

        public GmailManager(GmailService gmailService)
        {
            _gmailService = gmailService;
        }

        public void ReadAndDeleteEmails()
        {
            // Specify your Gmail query to filter emails
            string query = "from:ravikoppula92@gmail.com subject:(4) Deals for Your Thailand Trip";

            var listRequest = _gmailService.Users.Messages.List("me");
            listRequest.Q = query;

            var messages = listRequest.Execute().Messages;

            if (messages != null && messages.Any())
            {
                foreach (var message in messages)
                {
                    // Get the email
                    var email = _gmailService.Users.Messages.Get("me", message.Id).Execute();

                    // Process the email content
                    //Console.WriteLine($"Subject: {email.Subject}");
                    Console.WriteLine($"Body: {email.Snippet}");

                    // Delete the email
                    _gmailService.Users.Messages.Delete("me", message.Id).Execute();
                    Console.WriteLine("Email deleted.");
                }
            }
            else
            {
                Console.WriteLine("No emails found.");
            }
        }
    }
}
