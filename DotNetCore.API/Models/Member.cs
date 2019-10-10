using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.API.Models
{
    public class Member
    {
        public Member()
        {
                
        }

        public Member(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
        public int CommunityID { get; set; }
        public int FamilyID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public short EmailPrivacy { get; set; }
        public string Password { get; set; }
        public string MobileNumCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public bool IsMobileNumberlVerified { get; set; }
        public short MobileNumberPrivacy { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<int> BloodGroup { get; set; }
        public string EmailVerificationCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFamilyResposible { get; set; }
        public short ProfileCreatedBy { get; set; }
        public string ExternalId { get; set; }
        public Nullable<short> Income { get; set; }
        public Nullable<int> BirthCountry { get; set; }
        public Nullable<int> BirthState { get; set; }
        public string BirthPlace { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<short> Weight { get; set; }
        public string Gotra { get; set; }
        public Nullable<short> Zodiac { get; set; }
        public string Star { get; set; }
        public bool Manglik { get; set; }
        public bool ShaniDosh { get; set; }
        public bool PhysicalDefect { get; set; }
        public string PhysicalDefectDescription { get; set; }
        public bool EatingHabit { get; set; }
        public bool DrinkingHabit { get; set; }
        public bool SmokingHabit { get; set; }
        public string Interests { get; set; }
        public string Activities { get; set; }
        public string AboutMe { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string GooglePlus { get; set; }
        public string Skype { get; set; }
        public Nullable<short> MarriedBrother { get; set; }
        public Nullable<short> UnmarriedBrother { get; set; }
        public Nullable<short> MarriedSister { get; set; }
        public Nullable<short> UnmarriedSister { get; set; }
        public Nullable<int> LifeStyle { get; set; }
        public Nullable<int> Diet { get; set; }
        public Nullable<int> BodyStyle { get; set; }
        public Nullable<int> BodyComplexion { get; set; }
        public string FatherFullName { get; set; }
        public string FatherOccupation { get; set; }
        public Nullable<short> FatherIncomeFormat { get; set; }
        public string FatherIncome { get; set; }
        public string FatherNativePlace { get; set; }
        public string MotherFullName { get; set; }
        public string MotherOccupation { get; set; }
        public Nullable<short> MotherIncomeFormat { get; set; }
        public string MotherIncome { get; set; }
        public string MotherNativePlace { get; set; }
        public bool IsMatrimonialActive { get; set; }
        public bool IsMatrimonialDeleted { get; set; }
        public Nullable<System.DateTimeOffset> MatrimonialActiveOnUTC { get; set; }
        public string MatrimonialActiveBy { get; set; }
        public Nullable<System.DateTimeOffset> MatrimonialExpireOnUTC { get; set; }
        public string MatrimonialDeactivateBy { get; set; }
        public System.DateTimeOffset CreatedOnUTC { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTimeOffset ModifiedOnUTC { get; set; }
        public string ModifiedBy { get; set; }
    }
}
