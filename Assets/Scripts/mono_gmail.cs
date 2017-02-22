using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class mono_gmail : MonoBehaviour
{
    MailMessage mail = new MailMessage();

    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

    public void sendAlert(string target, string mailBody)
    {

        mail.From = new MailAddress("hf30159@gmail.com");
        mail.To.Add("e0005485@u.nus.edu");
        mail.Subject = "Request for attention to ";
        mail.Subject += target;
        mail.Body = mailBody;


        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");

    }
}