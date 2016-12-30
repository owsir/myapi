using System;
namespace WebAPI.ViewModels
{
    public static class MyEnums
    {
        public enum Sex
        {
            Mr,
            Ms
        }
        public enum TravelWithType
        {
            Solo = 1,
            TwoPeople,
            Family,
            Group
        }
        public enum HotelStyle
        {
            Star5 = 1,
            Star4,
            Star3,
            Customized
        }
        public enum TrainAndPlane
        {
            Flight = 1,
            FlightAndTrain,
            Train,
            Customized
        }
        public enum IAm
        {
            LookingForInspiration = 1,
            StartingToPlan,
            ComparingPrices,
            ReturningToChina
        }
        public enum GuideAndFreetime
        {
            EveryDayGuided = 1,
            MostDaysGuided,
            EssentialDaysGuided
        }
        public static string getSex(int value)
        {
            string result = string.Empty;
            if (value != 0)
            {
                if (value != 1)
                {
                    result = "No result";
                }
                else
                {
                    result = "Ms.";
                }
            }
            else
            {
                result = "Mr.";
            }
            return result;
        }
        public static string getTravelWith(int value)
        {
            string result = string.Empty;
            switch (value)
            {
                case 1:
                    result = "Solo";
                    break;
                case 2:
                    result = "Two People";
                    break;
                case 3:
                    result = "Family";
                    break;
                case 4:
                    result = "Group";
                    break;
                default:
                    result = "No result";
                    break;
            }
            return result;
        }
        public static string getHotelStyle(int value)
        {
            string result = string.Empty;
            switch (value)
            {
                case 1:
                    result = "5 Star Famous Chains ";
                    break;
                case 2:
                    result = "4 Star Best Deal & Location";
                    break;
                case 3:
                    result = "3 Star Value & Location";
                    break;
                case 4:
                    result = "Self Booking ";
                    break;
                default:
                    result = "No result";
                    break;
            }
            return result;
        }
        public static string getTrainAndPlane(int value)
        {
            string result = string.Empty;
            switch (value)
            {
                case 1:
                    result = "Flights Prefered";
                    break;
                case 2:
                    result = "Bullet Trains & Flights";
                    break;
                case 3:
                    result = "Bullet Trains Prefered";
                    break;
                case 4:
                    result = "Self Booking";
                    break;
                default:
                    result = "No result";
                    break;
            }
            return result;
        }
        public static string getIAm(int value)
        {
            string result = string.Empty;
            switch (value)
            {
                case 1:
                    result = "Looking for inspiration";
                    break;
                case 2:
                    result = "Starting to plan";
                    break;
                case 3:
                    result = "Comparing prices";
                    break;
                case 4:
                    result = "Returning to China";
                    break;
                default:
                    result = "No result";
                    break;
            }
            return result;
        }
        public static string getGuideAndFreetime(int value)
        {
            string result = string.Empty;
            switch (value)
            {
                case 1:
                    result = " Every Day Guided";
                    break;
                case 2:
                    result = "Most Days Guided";
                    break;
                case 3:
                    result = "Essential Days Guided";
                    break;
                default:
                    result = "No result";
                    break;
            }
            return result;
        }
    }
}
