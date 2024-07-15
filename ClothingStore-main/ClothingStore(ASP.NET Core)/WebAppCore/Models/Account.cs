﻿using System;
using System.Collections.Generic;

namespace WebAppCore.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? PassWord { get; set; }

    public string? Salt { get; set; }

    public bool? Active { get; set; }

    public string? FullName { get; set; }

    public int? RoleId { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreateDate { get; set; }
}
