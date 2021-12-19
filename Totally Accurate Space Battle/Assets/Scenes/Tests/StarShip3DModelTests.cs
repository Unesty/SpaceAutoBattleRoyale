using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.Scripts
{
    public class StarShip3DModelTests
    {
        


        // A Test behaves as an ordinary method
        [Test]
        public void StarShip3DModelTestsSimplePasses()
        {
            // Use the Assert class to test conditions
            GameObject ShipModel;

            //Assert.IsNotNull(ShipModel);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator StarShip3DModelTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}