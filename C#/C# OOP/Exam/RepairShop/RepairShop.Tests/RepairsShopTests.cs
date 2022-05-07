using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage garageWith1Mechanic;
            private Garage garageWith0Mechanics;
            private Garage garageWith4Mechanics;
            private Car car;

            [SetUp]
            public void InitialTest()
            {
                garageWith0Mechanics = new Garage("Garash22", 1);
                garageWith1Mechanic = new Garage("Garash21", 1);
                garageWith4Mechanics = new Garage("Garash21", 4);

                car = new Car("model1", 2);
                car.NumberOfIssues = 0;

                garageWith4Mechanics.AddCar(car);
                garageWith4Mechanics.AddCar(new Car("model2", 2));
            }

            [Test]
            public void GarageNameCantBeNull()
            {
                Assert.Throws(typeof(ArgumentNullException), () => garageWith1Mechanic = new Garage(null, 1));
            }

            [Test]
            public void MechanicsCountCantBeLessThan0()
            {
                Assert.Throws(typeof(ArgumentException), () => garageWith1Mechanic = new Garage("Garash21", -1));
            }

            [Test]
            public void MechanicsCountCantBe0()
            {
                Assert.Throws(typeof(ArgumentException), () => garageWith1Mechanic = new Garage("Garash21", 0));
            }

            [Test]
            public void CreateNewGarageTestName()
            {
                Assert.That(garageWith1Mechanic.Name, Is.EqualTo("Garash21"));
            }

            [Test]
            public void CreateNewGarageTestMechanicsCount()
            {
                Assert.That(garageWith1Mechanic.MechanicsAvailable, Is.EqualTo(1));
            }

            [Test]
            public void AddCarNoAvailableMechanics()
            {
                Assert.Throws(typeof(InvalidOperationException), () =>
                {
                    garageWith1Mechanic.AddCar(new Car("model1", 2));
                    garageWith1Mechanic.AddCar(new Car("model2", 1));
                });
            }

            [Test]
            public void AddCarCheckIfCountOfCarsIsOk()
            {
                Assert.That(garageWith4Mechanics.CarsInGarage, Is.EqualTo(2));
            }

            [Test]
            public void FixCarThrowsNullExeption()
            {
                Assert.Throws(typeof(InvalidOperationException), () => garageWith4Mechanics.FixCar("modeln0"));
            }

            [Test]
            public void FixCarReturnsCarWith0Issues()
            {
                Assert.That(garageWith4Mechanics.FixCar(car.CarModel).NumberOfIssues, Is.EqualTo(0));
            }

            [Test]
            public void RemoveFixedCarThrowsNullExeption()
            {
                Assert.Throws(typeof(InvalidOperationException), () => garageWith0Mechanics.RemoveFixedCar());
            }

            [Test]
            public void RemoveFixedCarReturns1()
            {
                Assert.That(garageWith4Mechanics.RemoveFixedCar(), Is.EqualTo(1));
            }

            [Test]
            public void ReportReturnsString()
            {
                Assert.That(garageWith4Mechanics.Report, Is.EqualTo("There are 1 which are not fixed: model2."));
            }

            [Test]
            public void CarSatusChangesNoIssues()
            {
                car.NumberOfIssues = 0;
                Assert.That(car.IsFixed, Is.EqualTo(true));
            }

            [Test]
            public void CarSatusChangesIssues()
            {
                car = new Car("model1", 2);
                Assert.That(car.IsFixed, Is.EqualTo(false));
            }

        }
    }
}