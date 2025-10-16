namespace Models.Application.Handlers.AppCode.Base;

public abstract class HandlerAppCode
{
    protected HandlerAppCode(int codeNumber)
    {
        CodeNumber = codeNumber;
    }

    protected abstract string AppCodePrefix { get; }

    protected int CodeNumber { get; }

    public string Code
    {
        get
        {
            return $"{AppCodePrefix}.{CodeNumber}";
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is not HandlerAppCode comparedAppCode)
        {
            return false;
        }

        return CodeNumber == comparedAppCode.CodeNumber
            && AppCodePrefix.Equals(comparedAppCode.AppCodePrefix, System.StringComparison.OrdinalIgnoreCase);
    }
}