// RootHashCodes.il
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
.assembly extern System.Core
{
    .publickeytoken = (
        b7 7a 5c 56 19 34 e0 89
    )
    .ver 3:5:0:0
}
.namespace AisA
{
    .class public auto ansi abstract sealed beforefieldinit RootHashCodes
        extends [mscorlib]System.Object
    {
        .custom instance void [System.Core]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = (
            01 00 00 00
        )
        .method public hidebysig static 
            int32 RootHashCode<class T> (
                !!T obj
            ) cil managed 
        {
            .custom instance void [System.Core]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = (
                01 00 00 00
            )
            .maxstack 8
            ldarg.0
            call instance int32 [mscorlib]System.Object::GetHashCode()
            ret
        }
    }
}