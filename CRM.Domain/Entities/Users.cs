﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum Role { Administrator , Manager , Commercial}
    public class Users
    {
        [Key]
        private int UserId { get; set; }
        public NomComplet UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        [Compare("MotDePasse")]
        public string ConfirmMotDePasse { get; set; }
        public Role role { get; set; }
        public Companies company { get; set; }
        public int companyFK { get; set; }
    }
}
