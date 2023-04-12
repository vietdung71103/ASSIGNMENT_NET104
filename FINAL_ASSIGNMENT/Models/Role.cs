﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace FINAL_ASSIGNMENT.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual List<User> Users { get; set; }
		//public IEnumerable<SelectListItem> RoleListItems { get; internal set; }
	}
}
