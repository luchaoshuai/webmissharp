using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class TABLE:Attribute
{
    public TABLE() { }
    public string Name
    {
        get;
        set;
    }

    public string AutoID
    {
        get;
        set;
    }
}