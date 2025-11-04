namespace System;

public sealed class HResultException : Exception
{
    //Ctor
    public HResultException(int hresult)
    {
        HResult = hresult;
    }
}
