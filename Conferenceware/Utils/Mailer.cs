using System.Net;
using System.Net.Mail;
using Conferenceware.Models;

namespace Conferenceware.Utils
{
	/// <summary>
	/// Class for dealing with email
	/// </summary>
	public class Mailer
	{
		/// <summary>
		/// Sends the specified message; uses settings data for smtp server settings
		/// </summary>
		/// <param name="message">The message to send</param>
		public static void Send(MailMessage message)
		{
			SettingsData sd = SettingsData.Default;
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