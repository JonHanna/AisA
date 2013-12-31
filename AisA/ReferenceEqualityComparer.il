// ReferenceEqualityComparer.il
//
// Author:
//     Jon Hanna <jon@hackcraft.net>
//
// © 2013 Jon Hanna
//
// Licensed under the EUPL, Version 1.1 only (the “Licence”).
// You may not use, modify or distribute this work except in compliance with the Licence.
// You may obtain a copy of the Licence at:
// <http://joinup.ec.europa.eu/software/page/eupl/licence-eupl>
// A copy is also distributed with this source code.
// Unless required by applicable law or agreed to in writing, software distributed under the
// Licence is distributed on an “AS IS” basis, without warranties or conditions of any kind.

.assembly extern mscorlib
{
    .publickeytoken = (
        b7 7a 5c 56 19 34 e0 89
    )
    .ver 2:0:0:0
}
.namespace AisA
{
    .class public auto ansi sealed beforefieldinit ReferenceEqualityComparer
        extends [mscorlib]System.Object
        implements [mscorlib]System.Collections.IEqualityComparer
    {
        .method public final hidebysig newslot virtual 
            instance bool Equals (
                object x,
                object y
            ) cil managed 
        {
            .maxstack 2
            ldarg.1
            ldarg.2
            ceq
            ret
        }
        .method public final hidebysig newslot virtual 
            instance int32 GetHashCode (
                object obj
            ) cil managed 
        {
            .maxstack 1
            ldarg.1
            call instance int32 [mscorlib]System.Object::GetHashCode()
            ret
        }
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 1
            ldarg.0
            call instance void [mscorlib]System.Object::.ctor()
            ret
        }
    }
    .class public auto ansi sealed beforefieldinit ReferenceEqualityComparer`1<class T>
        extends [mscorlib]System.Object
        implements class [mscorlib]System.Collections.Generic.IEqualityComparer`1<!T>
    {
        .method public final hidebysig newslot virtual 
            instance bool Equals (
                !T x,
                !T y
            ) cil managed 
        {
            .maxstack 2
            ldarg.1
            ldarg.2
            ceq
            ret
        }
        .method public final hidebysig newslot virtual 
            instance int32 GetHashCode (
                !T obj
            ) cil managed 
        {
            .maxstack 1
            ldarg.1
            call instance int32 [mscorlib]System.Object::GetHashCode()
            ret
        }
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            .maxstack 1
            ldarg.0
            call instance void [mscorlib]System.Object::.ctor()
            ret
        }
    }
}