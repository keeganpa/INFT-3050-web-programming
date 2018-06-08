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
        UserActions uA = new UserActions();
        AddressActions aA = new AddressActions();
        //Method checks if valid email address
        // checks if the string is empty or a null
        //if its not then it will see if it can convert it to Email context
        // if it cant then it returns false
        public bool IsValidEmail(String email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            //tries to convert
            try
            {
                MailAddress to = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        //Checks for if the email Address is valid,
        //Then will pass email address and an empty string to the DAL
        //Once information is returned and checked then it is converted into HTML and plain text
        //then SMTP sends an email to give the customer their password.
        //it then returns true
        //if not then it will return false
        // This procedure should not be used in a regular setting as it is insecure to be able to access your users passwords
        public bool checkEmail(string Email)
        {
            string tempEmail = Email;

            if (IsValidEmail(tempEmail))
            {
                String tempPassword = "";
                tempPassword = uA.getUserPassword(tempEmail, tempPassword);
                if(String.IsNullOrEmpty(tempPassword)){
                    return false;
                }
                else
                {
                    MailMessage emailMessage = new MailMessage("Japallum@Japallum.com", tempEmail);
                    emailMessage.Subject = "Password";
                    emailMessage.Body = getPasswordEmail(tempPassword, false);

                    string html = getPasswordEmail(tempPassword, true);
                    AlternateView view = AlternateView.CreateAlternateViewFromString(html, null, "text/html");

                    emailMessage.AlternateViews.Add(view);
                    SmtpClient mailClient = new SmtpClient();
                    mailClient.Send(emailMessage);
                    return true;
                }
                
            }
            else{
                return false;
            }
        }
        //takes the parsed Email address
        // Generates a code for validation
        // then sends it off to be converted into html
        // which is then sent off as an email for the customer
        public string sendValidation(string Email)
        {
            string custAddress = Email;
            string genCode = genRandom();
            if (IsValidEmail(custAddress))
            {
                MailMessage emailMessage = new MailMessage("Validation@Japallum.com", custAddress);
                emailMessage.Subject = "Validation Code";
                emailMessage.Body = getValidationEmail(genCode, false);

                string html = getValidationEmail(genCode, true);
                AlternateView view = AlternateView.CreateAlternateViewFromString(html, null, "text/html");

                emailMessage.AlternateViews.Add(view);
                SmtpClient mailClient = new SmtpClient();
                mailClient.Send(emailMessage);
            }
            return genCode;
        }
        //Takes Given values
        // Converts the ones it needs into string and retreives others through DAL methods
        // then sends them to OrderEmail to be converted into email format and sent away
        public void getOrderDetails(DateTime date, double subTotal, double total, int customerID, int customerAddress, double tax)
        {
            string emailDate = Convert.ToString(date);
            string emailSub = Convert.ToString(subTotal);
            string emailTotal = Convert.ToString(total);
            string emailTax = Convert.ToString(tax);
            string emailAddress = uA.getUserEmail(customerID);
            string streetNum = "";
            string streetName = "";
            string suburb = "";
            string state = "";
            string postCode = "";
            aA.getUserAddress(customerAddress,ref streetNum,ref streetName,ref suburb,ref state,ref postCode);

            if (IsValidEmail(emailAddress))
            {
                MailMessage emailMessage = new MailMessage("Orders@Japallum.com", emailAddress);
                emailMessage.Subject = "Your Order";
                emailMessage.Body = getOrderEmail(emailDate, emailSub, emailTotal, emailTax, streetNum, streetName, suburb, state, postCode, false);

                string html = getOrderEmail(emailDate, emailSub, emailTotal, emailTax, streetNum, streetName, suburb, state, postCode, true);
                AlternateView view = AlternateView.CreateAlternateViewFromString(html, null, "text/html");

                emailMessage.AlternateViews.Add(view);
                SmtpClient mailClient = new SmtpClient();
                mailClient.Send(emailMessage);
            }
        }

        //Generates a random combination of 5 letters and numbers for the validation email
        public string genRandom()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string finalString;
            return finalString = new String(stringChars);
        }

    // the Following methods generate the emails for the three function by using the similar technique.
    // Take the parsed information as well as the boolean which desides wether it is the plain text or html version and generates the message around the information
       public string getValidationEmail(string Code, bool isHtml)
        {
            if (isHtml)
            {
                return "<html><head><title>Validation Code</title></head>"
                    + "<body><p>Your Validation Code is:</p>"
                    + "<h2>" + Code + "</h2>"
                    + "<p> Please enter this before proceeding with your Registration</p></body></html>";
            }
            else
            {
                return "Your Code is \n" + Code + "\nEnjoy";
            }
        }

        public string getPasswordEmail(string password, bool isHtml)
        {
            if (isHtml)
            {
                return "<html><head><title>Password</title></head>" +
                    "<body><p>Your Password is:</p>" +
                    "<h2>" + password + "</h2>" +
                    "<p> Let it be noted this way of doing it is not meant to be done professionally</p></body></html>";
            }
            else
            {
                return "Your Password is \n" + password + "\n This sort of practice is not meant to be done in a regular case.";
            }
        }


        //Uses base address HTML elements as well ads a liottle bit of formatting to make it look good.
        public string getOrderEmail(string date, string subTotal,string total, string tax,string streetNum,string streetName,string suburb,string state,string postCode,Boolean isHtml)
        {
            if (isHtml)
            {
                return "<html><head><title>Your Order</title></head>" +
                    "<body><p>Here is the information for your recent Order with us on" + date + "<br />" +
                    "It Cost: $" + subTotal + "<br /> Before the included tax of " + tax + "<br /> with an overall cost of: $" + total +
                    "</p>"+
                    "<p> Sent To: </p>" +
                    "<address>" + streetNum +" "+ streetName + "<br>" + suburb + "<br>" + state + "<br>" + postCode + "</address>"+
                    "<p> If you wish to see you Order in full or wish to speak with us,<br /> Please visit us at Japallum Apparel.</p>";
            }
            else
            {
                return "Order Placed on: " + date + "\n Subtotal: $" + subTotal + "\n Tax: " + tax + "\n Total: $" + total + "\n \n" +
                    "It is being sent to: \n" + streetNum + " " + streetName + "\n" + suburb + "\n" + state + " \n" + postCode + "\n \n" +
                    "Please visit us at Japallum Appaarel for more information";
            }
        }
    }
}