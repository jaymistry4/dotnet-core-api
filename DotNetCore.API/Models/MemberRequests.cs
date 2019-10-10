using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore.API.Models
{
#pragma warning disable CS1591
    public class PostMembersRequest
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
    }

    public class PutMembersRequest
    {
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
    }

    public static class MemberExtensions
    {
        public static Member ToEntity(this PostMembersRequest request)
            => new Member
            {
                ID = request.ID
            };
    }
#pragma warning restore CS1591
}
