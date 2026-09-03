using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Member:Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new HashSet<Borrowing>();

        public static Member Create()
        {
            Member member = new Member();
            member.UpdateName();
            member.UpdateEmail();
            member.UpdatePhone();
            return member;
        }
        public void UpdateName()
        {
            while (true)
            {
                Console.Write("Enter Member Name: ");
                ValidationResult validationResult = SetName(Console.ReadLine()!);
                if (validationResult.IsSuccess)
                    return;
                Console.WriteLine(validationResult.Message);
            }
        }
        public void UpdatePhone()
        {
            while (true)
            {
                Console.Write("Enter Member Phone: ");
                ValidationResult validationResult = SetPhone(Console.ReadLine()!);
                if (validationResult.IsSuccess)
                    return;
                Console.WriteLine(validationResult.Message);
            }
        }
        public void UpdateEmail()
        {
            while (true)
            {
                Console.Write("Enter Member Email: ");
                ValidationResult validationResult = SetEmail(Console.ReadLine()!);
                if (validationResult.IsSuccess)
                    return;
                Console.WriteLine(validationResult.Message);
            }
        }

        public ValidationResult SetName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return ValidationResult.Fail("The Name should not be null or whiteSpace only");
            newName = newName.Trim();
            if (newName.Length > Constants.MaxNameLength)
                return ValidationResult.Fail($"The Name Length should be less that {Constants.MaxNameLength}");
            Name = newName;
            return ValidationResult.Success("the Name is valid");
        }
        public ValidationResult SetPhone(string newPhone)
        {
            if (string.IsNullOrWhiteSpace(newPhone))
                return ValidationResult.Fail("The Phone should not be null or whiteSpace only");
            newPhone = newPhone.Trim();
            if (newPhone.Length != Constants.PhoneLength)
                return ValidationResult.Fail($"The Phone Length should be equal {Constants.PhoneLength}");
          
            if(!long.TryParse(newPhone,out long x))
                return ValidationResult.Fail($"The Phone Should be Numbers Only");

            Phone = newPhone;
            return ValidationResult.Success("the Phone is valid");
        }
        public ValidationResult SetEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                return ValidationResult.Fail("The Phone should not be null or whiteSpace only");
            newEmail = newEmail.Trim();

            if (newEmail.Length > Constants.MaxEmailLength)
                return ValidationResult.Fail($"The Email Length should be less than {Constants.MaxEmailLength}");
            MailAddress mailAddress = new MailAddress(newEmail);
            if (!IsValidEmail(newEmail))
                return ValidationResult.Fail($"The Email Format is Invalid it should be like that `example@gmail.com`");

            Phone = newEmail;
            return ValidationResult.Success("the Email is valid");
        }
        private bool IsValidEmail(string email)
        {

            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email && email.Contains(".");
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"[ID: {Id}] Name: {Name} | Email: {Email} | Phone: {Phone}");
            Console.WriteLine("Borrowing History:");

            if (Borrowings.IsNullOrEmpty())
                builder.AppendLine("\tNo borrowing history found for this member.");
            else
                foreach (var borrowing in Borrowings)
                    builder.AppendLine($"\t[Borrowing ID: {borrowing.Id}] Book ID: {borrowing.BookId} | Title: {borrowing.Book.Title} | Author: {borrowing.Book.Author} | Year: {borrowing.Book.PublishedYear} | Price: {borrowing.Book.Price} | Borrowed: {borrowing.BorrowDate.ToShortDateString()} | Return Date: {(borrowing.ReturnDate.HasValue? borrowing.ReturnDate.Value.ToShortDateString():"Not return yet")}");
            return builder.ToString();
        }
    }
}
