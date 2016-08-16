using System;

public class Base : IBase
{
}

public class Derived : Base, IDerived
{
}

public interface IBase
{
}

public interface IDerived : IBase
{
}
