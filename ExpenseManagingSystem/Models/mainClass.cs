using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Xunit;

namespace ExpenseManagingSystem.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Type
    {
        Food,
        Bill,
        Transportation,
        Grocery,
        MedicalExpenses,
        Rent,
        Travelling,
        PersonalCare
    }
    public class mainClass
    {
        [Key]
        [Required]
        [Display(Name = "User Id")]
        public String userId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String name { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? dob { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender gender { get; set; }

        [Required(ErrorMessage = "Email ID is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public String phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email ID is not valid")]
        [Display(Name = "Email")]
        public String email { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String password { get; set; }
    }

    public class Expense
    {
        [Key]
        [Required]
        [Display(Name = "Expense Id")]
        public String expenseId { get; set; }

        [Required]
        [ForeignKey("foreignId")]
        [Display(Name = "User Id")]
        public string userId { get; set; }
        public virtual mainClass foreignId { get; set; }

        [Required]
        [Display(Name = "Expense Name")]
        public String expenseName { get; set; }


        [Required]
        [Display(Name = "Expense Name")]
        public Type expenseType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Display Date")]
        public DateTime? expenseDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Expense Amount")]
        public String amount { get; set; }
    }
}