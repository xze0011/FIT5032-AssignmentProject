//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_AssignmentProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Enrolment
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime EnrolmentDate { get; set; }
        public decimal Grade { get; set; }
        public string UserId { get; set; }
        public int StudentId { get; set; }
        public int UnitId { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
