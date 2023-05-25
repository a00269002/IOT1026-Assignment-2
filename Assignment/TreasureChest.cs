namespace Assignment
{
    public class TreasureChest
    {
        private State _state = State.Locked;
        private readonly Material _material;
        private readonly LockType _lockType;
        private readonly LootQuality _lootQuality;

        //Default constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TreasureChest"/> class with default properties.
        /// </summary>
        /// <remarks>
        /// The default properties for the new <see cref="TreasureChest"/> instance are:
        /// - Material: <see cref="Material.Iron"/>
        /// - Lock Type: <see cref="LockType.Expert"/>
        /// - Loot Quality: <see cref="LootQuality.Green"/>
        /// </remarks>
        public TreasureChest()
        {
            _material = Material.Iron;
            _lockType = LockType.Expert;
            _lootQuality = LootQuality.Green;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreasureChest"/> class with the specified state and default properties.
        /// </summary>
        /// <param name="state">The initial state of the treasure chest.</param>
        /// <remarks>
        /// This constructor initializes a new <see cref="TreasureChest"/> instance with the specified <paramref name="state"/> and default properties. The default properties for the new instance are:
        /// - Material: <see cref="Material.Iron"/>
        /// - Lock Type: <see cref="LockType.Expert"/>
        /// - Loot Quality: <see cref="LootQuality.Green"/>
        /// </remarks>
        public TreasureChest(State state) : this()
        {
            _state = state;
        }

        //Parametrized constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TreasureChest"/> class with the specified material, lock type, and loot quality.
        /// </summary>
        /// <param name="material">The material of the treasure chest.</param>
        /// <param name="lockType">The lock type of the treasure chest.</param>
        /// <param name="lootQuality">The loot quality of the treasure chest.</param>
        public TreasureChest(Material material, LockType lockType, LootQuality lootQuality)
        {
            _material = material;
            _lockType = lockType;
            _lootQuality = lootQuality;
        }

        /// <summary>
        /// Manipulates the treasure chest based on the specified action.
        /// </summary>
        /// <param name="action">The action to perform on the treasure chest.</param>
        /// <returns>The current state of the treasure chest after the manipulation.</returns>
        /// <remarks>
        /// The method takes an <see cref="Action"/> parameter, which represents the action to be performed on the treasure chest. 
        /// The available actions are:
        /// - <see cref="Action.Open"/>: Opens the treasure chest.
        /// - <see cref="Action.Close"/>: Closes the treasure chest.
        /// - <see cref="Action.Lock"/>: Locks the treasure chest.
        /// - <see cref="Action.Unlock"/>: Unlocks the treasure chest.
        /// 
        /// The method executes the corresponding operation based on the provided action and returns the current state of the treasure chest after the manipulation.
        /// </remarks>
        public State Manipulate(Action action)
        {
            switch (action)
            {
                case Action.Open:
                    Open();
                    break;
                case Action.Close:
                    Close();
                    break;
                case Action.Lock:
                    Lock();
                    break;
                case Action.Unlock:
                    Unlock();
                    break;
            }
            return _state;
        }

        //Method to return the state, to avoid change to public the state 
        /// <summary>
        /// Retrieves the current state of the treasure chest.
        /// </summary>
        /// <returns>The current state of the treasure chest.</returns>
        public State GetState()
        {
            return _state;
        }

        /// <summary>
        /// Unlocks the treasure chest.
        /// </summary>
        /// <remarks>
        /// If the treasure chest is currently locked, it will be unlocked and its state will change to <see cref="State.Closed"/>.
        /// If the treasure chest is already closed, a message will be printed to the console indicating that the chest cannot be unlocked because it is closed.
        /// If the treasure chest is open, a message will be printed to the console indicating that the chest cannot be unlocked because it is already open.
        /// </remarks>
        public void Unlock()
        {
            if (_state == State.Locked)
            {
                _state = State.Closed;
            }
            else if (_state == State.Closed)
            {
                Console.WriteLine("The chest cannot unlocked because it is closed.");
            }
            else if (_state == State.Open)
            {
                Console.WriteLine("The chest cannot be unlocked because it is open.");
            }
        }

        /// <summary>
        /// Locks the treasure chest.
        /// </summary>
        /// <remarks>
        /// If the treasure chest is currently closed, it will be locked and its state will change to <see cref="State.Locked"/>.
        /// If the treasure chest is already locked, a message will be printed to the console indicating that the chest is already locked.
        /// If the treasure chest is open, a message will be printed to the console indicating that the chest cannot be locked because it is open.
        /// </remarks>
        public void Lock()
        {
            if (_state == State.Closed)
            {
                _state = State.Locked;
            }
            else if (_state == State.Locked)
            {
                Console.WriteLine("The chest is already locked!");
            }
            else if (_state == State.Open)
            {
                Console.WriteLine("The chest cannot be locked because it is open.");
            }
        }

        /// <summary>
        /// Opens the treasure chest.
        /// </summary>
        /// <remarks>
        /// If the treasure chest is currently closed, it will be opened and its state will change to <see cref="State.Open"/>.
        /// If the treasure chest is already open, a message will be printed to the console indicating that the chest is already open.
        /// If the treasure chest is locked, a message will be printed to the console indicating that the chest cannot be opened because it is locked.
        /// </remarks>
        public void Open()
        {

            if (_state == State.Closed)
            {
                _state = State.Open;
            }
            else if (_state == State.Open)
            {
                Console.WriteLine("The chest is already open!");
            }
            else if (_state == State.Locked)
            {
                Console.WriteLine("The chest cannot be opened because it is locked.");
            }
        }

        /// <summary>
        /// Closes the treasure chest.
        /// </summary>
        /// <remarks>
        /// If the treasure chest is currently open, it will be closed and its state will change to <see cref="State.Closed"/>.
        /// If the treasure chest is already closed, a message will be printed to the console indicating that the chest is already closed.
        /// If the treasure chest is locked, a message will be printed to the console indicating that the chest cannot be closed because it is locked.
        /// </remarks>
        public void Close()
        {
            if (_state == State.Open)
            {
                _state = State.Closed;
            }
            else if (_state == State.Closed)
            {
                Console.WriteLine("The chest is already close!");
            }
            else if (_state == State.Locked)
            {
                Console.WriteLine("The chest cannot be close because it is locked.");
            }
        }

        public override string ToString()
        {
            return $"A {_state} chest with the following properties:\nMaterial: {_material}\nLock Type: {_lockType}\nLoot Quality: {_lootQuality}";
        }

        private static void ConsoleHelper(string prop1, string prop2, string prop3)
        {
            Console.WriteLine($"Choose from the following properties.\n1.{prop1}\n2.{prop2}\n3.{prop3}");
        }

        public enum State { Open, Closed, Locked };
        public enum Action { Open, Close, Lock, Unlock };
        public enum Material { Oak, RichMahogany, Iron };
        public enum LockType { Novice, Intermediate, Expert };
        public enum LootQuality { Grey, Green, Purple };
    }
}
