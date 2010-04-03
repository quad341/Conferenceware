using System.Net;
using System.Net.Mail;
using Conferenceware.Models;

namespace Conferenceware.Utils
{
	public class Mailer
	{
		public static void Send(MailMessage message)
		{
			var sd = SettingsData.FromCurrent(
				SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR);
			var smtpClient = new SmtpClient(sd.SmtpHostname, sd.SmtpPort);
			if (sd.SmtpNeedsAuthentication)
			{
				var credential = new NetworkCredential(sd.SmtpAuthenticationUserName,
													   sd.SmtpAuthenticationPassword);
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = credential;
			}
			smtpClient.Send(message);
		}
	}
}