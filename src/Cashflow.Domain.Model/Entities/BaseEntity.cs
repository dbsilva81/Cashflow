using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cashflow.Domain.Model.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }
        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}