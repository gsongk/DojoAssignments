using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System;
namespace TheWall.Models
{
    public class FieldExistsAttribute : ValidationAttribute
    {
        private string _fieldName;
        public FieldExistsAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            return DbConnector.Query($"SELECT id FROM users WHERE {_fieldName} = '{value}'").Count > 0 ? new ValidationResult("Email in use") : ValidationResult.Success;
        }
    }
}