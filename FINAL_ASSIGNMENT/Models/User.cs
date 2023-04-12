﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace FINAL_ASSIGNMENT.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string Avatar { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual Role Role { get; set; }
		//public IEnumerable<SelectListItem> RoleListItems { get; internal set; }
	}
}
