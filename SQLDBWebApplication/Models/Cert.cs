using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DotnetMirror.SQLDBWebApplication.Models
{
    public class Cert
    {
        public string? Code { get; set; }
        public string? Description { get; set; }

        [DisplayName("Exam Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExamDate { get; set; }
    }
}



