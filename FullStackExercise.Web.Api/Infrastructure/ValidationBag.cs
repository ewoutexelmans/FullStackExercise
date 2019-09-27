using System.Text;

namespace FullStackExercise.Web.Api.Infrastructure
{
    public class ValidationBag
    {
        private readonly StringBuilder _builder;
        public bool IsValid => _builder.Length == 0;
        public string ErrorMessage => _builder.ToString();

        public ValidationBag()
        {
            _builder = new StringBuilder();
        }

        public void AddError(string error)
        {
            _builder.AppendLine(error);
        }
    }
}
