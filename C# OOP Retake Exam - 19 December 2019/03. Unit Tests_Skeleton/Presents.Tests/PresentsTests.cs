namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Ctor_ShouldSetCorrect()
        {
            var bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Create_ShouldWorkCorrect()
        {
            var bag = new Bag();

            var pr = new Present("Name", 3.3);

            bag.Create(pr);

            Assert.AreEqual(1, bag.GetPresents().Count);

        }

        [Test]
        public void Create_ShouldThrowArgumentNullExceptionWithNullPresants()
        {
            var bag = new Bag();

            Present pr = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(pr));

        }

        [Test]
        public void Create_ShouldThrowInvalidOperationExceptionWithExistPresants()
        {
            var bag = new Bag();

            var pr = new Present("Name", 3.3);

            bag.Create(pr);
            
            Assert.Throws<InvalidOperationException>(() => bag.Create(pr));

        }

        [Test]
        public void Remove_ShuldWorkCorrect()
        {
            var bag = new Bag();

            var pr = new Present("Name", 3.3);

            bag.Create(pr);
            bag.Remove(pr);
            Assert.AreEqual(0, bag.GetPresents().Count);

        }

        [Test]
        public void GetPresentWithLeastMagic_ShouldWorkCorrect()
        {
            var bag = new Bag();

            var pr = new Present("Name", 3.3);
            var pr2 = new Present("Name2", 4.3);


            bag.Create(pr);
            bag.Create(pr2);

            var actual = bag.GetPresentWithLeastMagic();

            Assert.AreSame(pr, actual);
        }

        [Test]
        public void GetPresent_ShouldWorkCorrect()
        {
            var bag = new Bag();

            var pr = new Present("Name", 3.3);

            bag.Create(pr);

            var actual = bag.GetPresent(pr.Name);

            Assert.AreSame(pr, actual);
        }

        [Test]
        public void GetPresents_ShouldWorkCorrect()
        {
            var bag = new Bag();

            var pr = new Present("Name", 3.3);
            var pr2 = new Present("Name2", 4.3);

            bag.Create(pr);
            bag.Create(pr2);

            var actual = bag.GetPresents();


            CollectionAssert.AreEquivalent(bag.GetPresents(), actual);
        }
    }
}
