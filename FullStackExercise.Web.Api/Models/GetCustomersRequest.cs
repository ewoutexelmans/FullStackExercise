using System.ComponentModel.DataAnnotations;

namespace FullStackExercise.Web.Api.Models
{
    public class GetCustomersRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = "PageIndex needs to be 0 or higher.")]
        public int PageIndex { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PageSize needs to be higher than 0.")]
        public int PageSize { get; set; }
    }
}