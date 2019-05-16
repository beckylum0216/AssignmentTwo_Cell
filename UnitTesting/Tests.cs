using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace JourneyToTheCenterOfTheCell.Tests
{

    public enum TestTypes
    {
        None, 
        UnitTesting,
        IntegrationTesting
        //FlyByTheSeatOfYourPantsTesting
    }

    [TestFixture]
    public class Tester
    {
        //This file is set up to conduct Unit tests on classes quickly and effectively based on classes - Abstracts cannot be unit tested

        public Structure test;
        //public Actor test; //Abstract Class

        public Tester()
        {

        }

        //[SetUp()]
        //public void Init()
        //{
        //    test = new Structure(* add stuff here to run correctly*); /*Content Manager, ...,  etc*/
        //}

        //[Test()]
        //public void /*function to test ()*/
        //{
        //    Assert.AreEqual(*ExpectedOutcome*, *test.function name*);
        //}


        [Test()]
        public void TestingFunctionality()
        {
            //Arrage/Act
            var actual = TestTypes.UnitTesting.ToString();

            //Assert
            Assert.That(actual, Is.EqualTo("UnitTesting"));
           
        }
    }
}

/*
* Asserts List:
* Assert.That(actual, Is.Not.Null.And.EqualTo(..)
* Assert.NotNull(actual)
* Assert.AreEqual(*expected outcome*, actual)
*/
