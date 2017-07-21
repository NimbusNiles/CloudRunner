using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.TestTools;
using NUnit.Framework;

public class SpeedManagerTester : MonoBehaviour {

	[Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01GetFirstRange() {
        float[] speedRanges = { 0, 5};
        float currentSpeed = 1;
        Assert.AreEqual(0, SpeedManager.GetCurrentSpeedRange(speedRanges.ToList(), currentSpeed));
    }

    [Test]
    public void T02GetSecondRange() {
        float[] speedRanges = { 0, 5, 10 };
        float currentSpeed = 6;
        Assert.AreEqual(1, SpeedManager.GetCurrentSpeedRange(speedRanges.ToList(), currentSpeed));
    }

    [Test]
    public void T03GetLastRange() {
        float[] speedRanges = { 0, 5, 10, 20 };
        float currentSpeed = 20;
        Assert.AreEqual(4, SpeedManager.GetCurrentSpeedRange(speedRanges.ToList(), currentSpeed));
    }

}
