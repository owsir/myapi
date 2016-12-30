using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI.Models
{
    public class Tourquery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id
        {
            get;
            set;
        }
        public int Sex
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string Nationality
        {
            get;
            set;
        }
        public int NumberOfPeople
        {
            get;
            set;
        }
        public string Ip
        {
            get;
            set;
        }
        public string Device
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public string FromUrl
        {
            get;
            set;
        }
        public string TourUrl
        {
            get;
            set;
        }
        public DateTime? ArrivalDate
        {
            get;
            set;
        }
    }
}
