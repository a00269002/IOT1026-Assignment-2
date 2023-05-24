namespace Assignment
{
    class TreasureChest
    {
        private State _state = State.Locked;
        private readonly Material _material;
        private readonly LockType _lockType;
        private readonly LootQuality _lootQuality;

        public TreasureChest()
        {
            _material = Material.Iron;
            _lockType = LockType.Expert;
            _lootQuality = LootQuality.Green;
        }

        public TreasureChest(Material material, LockType lockType, LootQuality lootQuality)
        {
            _material = material;
            _lockType = lockType;
            _lootQuality = lootQuality;
        }

        public State? Manipulate(Action action)
        {
            switch (action)
            {
                case Action.Open:
                    if (_state == State.Closed)
                    {
                        Open();
                        _state = State.Open;
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid action: Open is only valid for a closed chest.");
                    }
                    break;
                case Action.Close:
                    if (_state == State.Open)
                    {
                        Close();
                        _state = State.Closed;
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid action: Close is only valid for an opened chest.");
                    }
                    break;
                case Action.Lock:
                    if (_state == State.Closed)
                    {
                        Lock();
                        _state = State.Locked;
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid action: Unlock is only valid for a locked chest.");
                    }
                    break;
                case Action.Unlock:
                    if (_state == State.Locked)
                    {
                        Unlock();
                        _state = State.Closed;
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid action: Unlock is only valid for a locked chest.");
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid action: The provided action is not supported.");
            }
            return _state;
        }


        private void Unlock()
        {
            Console.WriteLine("Unlocked");
            _state = State.Closed;
        }

        private void Lock()
        {
            Console.WriteLine("Locked");
            _state = State.Locked;
        }

        private void Open()
        {
            Console.WriteLine("Opened");
            _state = State.Open;
        }

        private void Close()
        {
            Console.WriteLine("Closed");
            _state = State.Closed;
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
