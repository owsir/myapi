using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI.Models
{
    public class TailorMake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id
        {
            get;
            set;
        }
        public string TourCode
        {
            get;
            set;
        }
        public string TourDetail
        {
            get;
            set;
        }
        public string TourUrl
        {
            get;
            set;
        }
        public int NumbersOfMyGroupAdult
        {
            get;
            set;
        }
        public int NumbersOfMyGroupChild
        {
            get;
            set;
        }
        public int NumbersOfMyGroupBaby
        {
            get;
            set;
        }
        public DateTime? ArrivalDate
        {
            get;
            set;
        }
        public int DatesFlexible
        {
            get;
            set;
        }
        public int HotelStyle
        {
            get;
            set;
        }
        public int TrainAndPlane
        {
            get;
            set;
        }
        public string IdealTrip
        {
            get;
            set;
        }
        public int Sex
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public string Nationnality
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string PhoneNumber
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
        public string Remark
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public int TravelWithType
        {
            get;
            set;
        }
        public int TourLengthAround
        {
            get;
            set;
        }
        public string TripCities
        {
            get;
            set;
        }
        public int TripPurpose
        {
            get;
            set;
        }
        public int GuideAndFreetime
        {
            get;
            set;
        }
    }
}
