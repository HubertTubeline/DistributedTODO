using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace DistributedToDo.Web.Models
{
    [Validator(typeof(TaskModelValidator))]
    public class TaskModel
    {
        public string Id { get; set; }

        public bool Checked { get; set; }

        public char Label { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string GeoLong { get; set; }
        public string GeoLat { get; set; }
    }
    public class TaskModelValidator : AbstractValidator<TaskModel>
    {
        public TaskModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(x => Resources.Resource.ErrorRequired);
            
        }
    }

}