﻿using System.Text;

namespace FullStackExercise.Business.Infrastructure
{
    public class ValidationBag
    {
        private readonly StringBuilder _builder;

        public ValidationBag()
        {
            _builder = new StringBuilder();
        }

        public bool IsValid => _builder.Length == 0;
        public string ErrorMessage => _builder.ToString();

        public void AddError(string error)
        {
            _builder.AppendLine(error);
        }
    }
}
