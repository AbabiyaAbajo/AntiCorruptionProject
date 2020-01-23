using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("Users")]
    public class User
    {

        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [NotMapped]
        public string newPassword { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("newPassword")]
        [NotMapped]
        public string confirmPassword { get; set; }


        [Column("roleid")]
        public int roleid
        {
            get;
            set;
        }

        [Column("ticketid")]
        public int ticketid
        {
            get;
            set;
        }

    }
}


/*@model ACWebsite.Models.User
@{
    ViewData["Title"] = "Register";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Register</h2><br /><br />

<form asp-controller="home" asp-action="RegisterAndRedirect">
    <div class="form-group">
        <label for="FirstName">First Name</label>
        <input id="FirstName" name="User.FirstName" class="form-control" asp-for="FirstName" required />
    </div>
    <div class="form-group">
        <label for="LastName">Last Name</label>
        <input id="LastName" name="User.LastName" class="form-control" asp-for="LastName" required />
    </div>
    <div class="form-group">
        <label for="EmailAddress">Email Address</label>
        <input id="EmailAddress" name="User.EmailAddress" type="email" class="form-control" asp-for="EmailAddress" required />
    </div>
    <div class="form-group">
        <label for="Password">Password</label>
        <input id="Password" name="User.Password" type="password" class="form-control" asp-for="Password" required />
    </div>
    <div class="form-group">
        <label for="RoleId">Role</label>
        <select name="User.RoleId" id="RoleId" class="form-control">
            <option selected="selected" value="1">General User</option>
            <option value="2">Admin</option>
        </select>
    </div>

    <button type="submit" class="btn btn-default" value="">Register Name</button>
</form>*/
