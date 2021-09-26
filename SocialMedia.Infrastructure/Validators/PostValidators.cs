using FluentValidation;
using SocialMedia.Core.DTOs;
using System;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidators : AbstractValidator<PostDto>
    {
        public PostValidators()
        {
            //2 validaciones 
            RuleFor(post => post.Description).NotNull().Length(10, 15);

            RuleFor(post => post.Date).NotNull().LessThan(DateTime.Now);


        }
    }
}
