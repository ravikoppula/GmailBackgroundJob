using System;

namespace GmailBackgroundJob
{
    class Program
    {
        static void Main()
        {
            try
            {
                var gmailService = GmailServiceInitializer.GetGmailService();
                var gmailManager = new GmailManager(gmailService);

                // Execute the background job
                gmailManager.ReadAndDeleteEmails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
