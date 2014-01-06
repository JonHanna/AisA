# A is A

Implementations of `IEqualityComparer` and `IEqualityComparer<T>` which ignore all overridden definitions of equality and compare based on identity alone.  
This deliberate usurpation of defined concepts of equality is normally counter-productive. It is however useful in the following cases:

1. A hash-based structure such as a `Dictionary<TKey, TValue>` is used to associate objects with an object objects which may be equivalent to another using the same dictionary.
2. A hash-based structure such as a `Dictionary<TKey, TValue>` is used to associate objects with an object which may mutate in such a way as to change the hash code based on its defined concept of equality.
3. As a (risky) optimisation, when it is known that no other equivalent objects exist, and therefore this object is the only one that would return true for an equality check. E.g. this would be the case with strings that had all been interned with string.Intern().

# License

> Licensed under the EUPL, Version 1.1 only (the “Licence”).  
> You may not use, modify or distribute this work except in compliance with the Licence.  
> You may obtain a copy of the Licence at:  
> <http://joinup.ec.europa.eu/software/page/eupl/licence-eupl>  
> A copy is also distributed with this source code.  
> Unless required by applicable law or agreed to in writing, software distributed under the  
> Licence is distributed on an “AS IS” basis, without warranties or conditions of any kind.

# How it Works.

Performing a reference-only equality-comparison is easy in all .NET languages, with `ReferenceEquals()` and the `==` operator applied to `object` references both performing such a comparison.  

While most cases could work with the `GetHashCode()` override as sub-optimal but workable, the same hash-code being produced for objects we are no longer considering equal can lead to excessive hash-collisions. It may also change on mutations we should ignore (because identity never mutates). For this reason we want to call back to the implementation of `GetHashCode()` defined on `object`, bypassing the virtual call mechanism. This is impossible to do directly in C# and most other .NET languages, but is trivial in CIL; we just use `call` where one would normally use `callvirt`.  

This can be done in C# with the use of reflection:

    :::c#
    private static readonly Func<T, int> RootHashCode = CreateRootHashCode();
    private static Func<T, int> CreateRootHashCode()
    {
      var dynM = new DynamicMethod(
        "",
        MethodAttributes.Final | MethodAttributes.Static,
        CallingConventions.Standard,
        typeof(int),
        new []{ typeof(T) },
        typeof(ReferenceEqualityComparer<T>),
        true);
      var ilGen = dynM.GetILGenerator(7);
      ilGen.Emit(OpCodes.Ldarg_0);
      ilGen.Emit(OpCodes.Call, typeof(object).GetMethod("GetHashCode"));
      ilGen.Emit(OpCodes.Ret);
      return (Func<T, int>)dynM.CreateDelegate(typeof(Func<T, int>));
    }
    public int GetHashCode(T obj)
    {
      return RootHashCode(obj);
    }

However, with the four methods necessary to override all being among the few cases where CIL is actually simpler than C#, it's handier just to write the whole library in CIL, though the NUnit tests are written in C#.  

# Building Notes

The project can be built with MonoDevelop or SharpDevelop with the [ILAsmBinding add-in](https://github.com/icsharpcode/SharpDevelop/tree/master/samples/ILAsmBinding).  

FIXME: Add notes on other IDEs (or versions thereof).  

The NUnit project references the DLL in the output directory rather than the project, as at least one IDE has problems between different bindings, resulting in build errors if the whole project is built when one project references the other. The first build will need the *AisA* project to be manually built first, but after that this will not be necessary.  

You cannot port the code directly to C#, VB.NET or most other .NET languages. When examined in most assembly browsers like ILSpy, dotPeek, etc. the code will appear to be a normal call to `GetHashCode()` which would then compile to `callvirt` rather than `call`.
