// Tests.cs
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

using AisA;
using NUnit.Framework;

// Analysis disable CheckNamespace
namespace AisATesting
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void IgnoresEquivalence()
        {
            string x = new string(new []{ 'a', 'b', 'c', 'd' });
            string y = new string(new []{ 'a', 'b', 'c', 'd' });
            if(!Equals(x, y))
                Assert.Inconclusive("Compiler has optimised x and y to one object. Change test!");
            var req = new ReferenceEqualityComparer<string>();
            Assert.False(req.Equals(x, y));
            Assert.True(req.Equals(x, x));
            var reqo = new ReferenceEqualityComparer();
            Assert.False(reqo.Equals(x, y));
            Assert.True(reqo.Equals(x, x));
            if(req.GetHashCode(x) == req.GetHashCode(y))
                Assert.Inconclusive
                    ("Same hashcode could happen rarely, but if more than once in a blue moon, this is a bug");
            if(reqo.GetHashCode(x) == req.GetHashCode(y))
                Assert.Inconclusive
                    ("Same hashcode could happen rarely, but if more than once in a blue moon, this is a bug");
            if(req.GetHashCode(x) == x.GetHashCode())
                Assert.Inconclusive
                ("Same hashcode could happen rarely, but if more than once in a blue moon, this is a bug");
            Assert.AreEqual(reqo.GetHashCode(x), req.GetHashCode(x));
        }
        [Test]
        public void NullSafe()
        {
            var req = new ReferenceEqualityComparer<string>();
            Assert.AreEqual(0, req.GetHashCode(null));
            Assert.True(req.Equals(null, null));
            Assert.False(req.Equals(null, "abc"));
            var reqo = new ReferenceEqualityComparer();
            Assert.AreEqual(0, reqo.GetHashCode(null));
            Assert.True(reqo.Equals(null, null));
            Assert.False(reqo.Equals(null, "abc"));
        }
    }
}