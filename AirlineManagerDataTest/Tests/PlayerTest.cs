using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlineManager.Data;

namespace AirlineManagerDataTest {
	[TestClass]
	public class PlayerTest {
		[TestMethod]
		public void TestCorrectPlayerCreation() {
			Player p = new Player("Test Player");

			Assert.IsNotNull(p);
			Assert.IsTrue(p.Name == "Test Player");
			Assert.IsTrue(p.CarriedCargo == 0);
			Assert.IsTrue(p.CarriedPax == 0);
			Assert.IsTrue(p.OperatedFlights == 0);
			Assert.IsTrue(p.TotalDistanceFlown == 0);
		}

		[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
		public void TestPlayerCreationWithEmptyName() {
			Player p = new Player("");
		}
	}
}
