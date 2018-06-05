using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Net.Mail;

namespace BL.Models
{
    public class EmailProcedures
    {
        //Method checks if valid email address
        public bool IsValidEmail(String email)
        {
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address == email)
            {
                //Email is valid
                return true;
            }
            //Email is invalid
            return false;
        }

        //Checks for if the email Address is valid,
        //Then will pass email address and an empty string to the DAL
        //Once information is returned then the SMTP sends an email to give the customer their password.
        //it then returns true
        //if not then it will return false
        // This procedure should not be usedin a regular setting as it is insecure to be able to access your users passwords
        public bool checkEmail(string Email)
        {
            string tempEmail = Email;

            if (IsValidEmail(tempEmail))
            {
                
                RetrieveAccount rA = new RetrieveAccount();
                String tempPassword = "";
                tempPassword = rA.getUserPassword(tempEmail, tempPassword);
                string message = "Hello! We are sending you this email to give you your password. Your password is " + tempPassword;
                MailMessage emailMessage = new MailMessage("Japallum@Japallum.com", tempEmail, "Your Password", message);
                SmtpClient mailClient = new SmtpClient();
                mailClient.Send(emailMessage);
                return true;
            }
            else{
                return false;
            }
        }

        public string sendValidation(string Email)
        {
            string custAddress = Email;
            string genCode = genRandom();
            if (IsValidEmail(custAddress))
            {
                string message = "Your Validation code is " + genCode + " Please input this in to proceed";
                MailMessage emailMessage = new MailMessage("Validation@Japallum.com", custAddress, "Validation Code", message);
                SmtpClient mailCLient = new SmtpClient();
                mailCLient.Send(emailMessage);
            }
            return genCode;
        }

        //Generates a random combination of 5 letters and numbers for the validation email
        public string genRandom()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string finalString;
            return finalString = new String(stringChars);
        }
    }
}