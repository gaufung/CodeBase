﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Sequence;

namespace CharSequenceTest
{
    [TestFixture]
    public class RunCharSequence
    {
        private IString _sequece;

        public RunCharSequence()
        {
            _sequece=new Strings(new char[]
            {
                'g','a','u','f','u','n','g'
            });
        }

        [Test]
        public void TestLength()
        {
            Assert.AreEqual(7,_sequece.Length);
            Assert.AreEqual('g',_sequece.CharAt(0));
        }

        [Test]
        public void TestEqual()
        {
            IString other=new Strings(
                new char[]
                {
                    'g','a','u','f','u','n','g'
                });

            Assert.AreEqual(true,_sequece.Equals(other));          
        }

        [Test]
        public void TestSubstr()
        {
            IString other=new Strings(
                new char[]
                {
                    'g','a','u'
                });
            Assert.AreEqual('g',_sequece.Prefix(3).CharAt(0));
        }

        [Test]
        public void TestIndexOf()
        {
            IString other=new Strings(new char[]
            {
                'a','u'
            });
            Assert.AreEqual(1,_sequece.IndexOf(other));
            other=new Strings(new char[]
            {
                'f','g'
            });
            Assert.AreEqual(-1,_sequece.IndexOf(other));
        }

        [Test]
        public void TestAction()
        {
            Assert.AreEqual(false,_sequece.Any(item=>item=='z'));
            Assert.AreEqual(0,_sequece.First(item=>item=='g'));
            Assert.AreEqual(-1,_sequece.First(item=>item=='z'));
        }
    }
}
