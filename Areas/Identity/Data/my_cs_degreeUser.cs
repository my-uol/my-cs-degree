using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace my_cs_degree.Areas.Identity.Data;

// Add profile data for application users by adding properties to the my_cs_degreeUser class
public class my_cs_degreeUser : IdentityUser
{
    [PersonalData]  
    [Column(TypeName ="nvarchar(100)")]  
    public string Firstname { get; set; }  
    [PersonalData]  
    [Column(TypeName = "nvarchar(100)")]  
    public string LastName { get; set; }  
}

