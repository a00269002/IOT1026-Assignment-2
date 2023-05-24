using Assignment;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        //Unit test cases for Open method
        //1. Try to open an opened chest
        //2. Try to open a closed chest
        //3. Try to open a locked chest
        //Chest starts in locked state

        [TestMethod]
        public void OpenLockedTest()
        {
            TreasureChest chest = new TreasureChest(TreasureChest.State.Locked);//Creating a new chest in state Locked
            //Try to open the chest
            //Verify chest is still locked
            chest.Open();
            Assert.AreEqual(chest.GetState(), TreasureChest.State.Locked);
        }
        [TestMethod]
        public void OpenClosedTest()
        {
            TreasureChest chest = new TreasureChest(TreasureChest.State.Closed);//Creating a new chest in state Closed
            chest.Open();
            Assert.AreEqual(chest.GetState(), TreasureChest.State.Open);
        }

        [TestMethod]
        public void OpenOpenTest()
        {
            TreasureChest chest = new TreasureChest(TreasureChest.State.Open);//Creating a new chest in state Open
            chest.Open();
            Assert.AreEqual(chest.GetState(), TreasureChest.State.Open);
        }

        //Unit test cases for Close method
        //1. Try to close a closed chest
        //2. Try to close a opened chest
        //3. Try to close a locked chest
        //Chest starts in locked state

        [TestMethod]
        public void CloseLockedTest()
        {
            TreasureChest chest = new TreasureChest(TreasureChest.State.Locked);//Creating a new chest in state Locked
            chest.Close();
            Assert.AreEqual(chest.GetState(), TreasureChest.State.Locked);
        }
        [TestMethod]
        public void CloseClosedTest()
        {
            TreasureChest chest = new TreasureChest(TreasureChest.State.Closed);//Creating a new chest in state Closed
            chest.Close();
            Assert.AreEqual(chest.GetState(), TreasureChest.State.Closed);
        }

        [TestMethod]
        public void CloseOpenTest()
        {
            TreasureChest chest = new TreasureChest(TreasureChest.State.Open);//Creating a new chest in state Open
            chest.Close();
            Assert.AreEqual(chest.GetState(), TreasureChest.State.Closed);
        }
    }
}
