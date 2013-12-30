using System;
using AisA;
using NUnit.Framework;

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