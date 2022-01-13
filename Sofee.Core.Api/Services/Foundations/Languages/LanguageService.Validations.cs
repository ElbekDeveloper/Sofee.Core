// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Sofee.Core.Api.Models.Languages;
using Sofee.Core.Api.Models.Languages.Exceptions;

namespace Sofee.Core.Api.Services.Foundations.Languages
{
    public partial class LanguageService
    {
        private void ValidateLanguageOnAdd(Language language)
        {
            ValidateLanguageIsNotNull(language);
        }

        private static void ValidateLanguageIsNotNull(Language language)
        {
            if (language is null)
            {
                throw new NullLanguageException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
{
            var invalidPostException = new InvalidLanguageException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidPostException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidPostException.ThrowIfContainsErrors();
        }
    }
}
