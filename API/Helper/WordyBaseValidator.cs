using FluentValidation;
using System.Collections.Generic;


public abstract class WordyBaseValidator<TModel> : AbstractValidator<TModel> where TModel : class
{
    #region Ctor

    public WordyBaseValidator()
    {
        PostInitialize();
    }

    #endregion Ctor

    #region Utilities

    protected virtual void PostInitialize()
    {
    }

    #endregion Utilities

    #region Extentions

    protected bool IsNotNullOrNotWhiteSpace(string str1)
    {
        var temp1 = !string.IsNullOrWhiteSpace(str1) ? str1.Trim() : null;
        return !string.IsNullOrWhiteSpace(temp1);
    }

    protected bool IsNotNull(object objectToCall)
    {
        return !objectToCall.IsNull();
    }

    protected bool IsNotNullOrEmpty<T>(IEnumerable<T> value)
    {
        return !value.IsNullOrEmpty();
    }

    #endregion Extentions
}
