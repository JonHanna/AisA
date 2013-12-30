// AssemblyInfo.cs
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

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle ("A is A Testing")]
[assembly: AssemblyDescription ("NUnit Tests for the A is A Assembly")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyProduct ("A is A Testing")]
[assembly: AssemblyCopyright ("Jon Hanna")]
[assembly: AssemblyCulture ("")]
[assembly: AssemblyVersion ("1.0.*")]