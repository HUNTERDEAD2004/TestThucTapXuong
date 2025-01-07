using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TestDauVaoXuong.Models
{
    public class Staff
    {
        [Key]
        public Guid Id { get; set; }

        public byte? Status { get; set; } 

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string AccountFe { get; set; }

        public string AccountFpt { get; set; }

        public string Name { get; set; }

        public string StaffCode { get; set; }

        public ICollection<DepartmentFacility> DepartmentFacilities { get; set; }

        public ICollection<StaffMajorFacility> StaffMajorFacilities { get; set; }

        public bool ValidateStaff()
        { 
            // Check email suffixes
            if (!AccountFe.EndsWith("@fe.edu.vn") || !AccountFpt.EndsWith("@fpt.edu.vn")) 
            { 
                return false; 
            } 
            // Check unique constraints
            if (AccountFe.Equals(AccountFpt) || StaffCode.Equals(AccountFpt) || StaffCode.Equals(AccountFe)) 
            { 
                return false; 
            } 
            // Check for spaces and Vietnamese characters
            Regex whiteSpaceRegex = new Regex(@"\s"); 
            Regex vietnameseCharRegex = new Regex(@"[\p{IsCombiningDiacriticalMarks}\p{IsCombiningMarksForSymbols}\p{IsCombiningHalfMarks}]"); 

            if (whiteSpaceRegex.IsMatch(AccountFe) || whiteSpaceRegex.IsMatch(AccountFpt) || vietnameseCharRegex.IsMatch(AccountFe) || vietnameseCharRegex.IsMatch(AccountFpt)) 
            { 
                return false; 
            }

            return true;
        }
    }
}
