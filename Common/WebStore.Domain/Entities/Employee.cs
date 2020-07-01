using System;
using System.ComponentModel.DataAnnotations;

using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Employee entity model
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// FirstName
        /// </summary>
        [Required]
        [MinLength(2), MaxLength(200)]
        public string Firstname { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        [Required]
        [MinLength(2), MaxLength(200)]
        public string Surname { get; set; }

        /// <summary>
        /// Path to Employee Avatar image
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        [Range(18, 75)]
        public int Age { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime BirthdayDate { get; set; }
    }
}
