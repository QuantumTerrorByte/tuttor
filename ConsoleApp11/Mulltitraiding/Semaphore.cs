using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp11.Mulltitraiding
{
    public class MySemaphore
    {
        public int Size { get; }
        private List<FlagHolder> _isThreadWorkingMarkers = new List<FlagHolder>();
        public List<Action> _callBacks = new List<Action>();

        public MySemaphore(int size)
        {
            Size = size;
            for (int i = 0; i < size; i++)
            {
                FlagHolder holder = new FlagHolder();
                holder.Value = true;
                _isThreadWorkingMarkers.Add(holder);
                new Thread(Work).Start(i);
                _callBacks.Add(() => { });
            }
        }

        public void Run(Action action)
        {
            while (true)
            {
                // Console.WriteLine("while run");
                lock (this)
                {
                    Console.WriteLine("run get monitor");
                    for (int index = 0; index < Size; index++)
                    {
                        var slot = _isThreadWorkingMarkers[index];
                        if (slot.Value != true) //cant be false before worker get this monitor
                        {
                            lock (slot)
                            {
                                Console.WriteLine("lock");
                                _callBacks[index] = action;
                                slot.Value = true;
                                Monitor.PulseAll(slot);
                            }

                            return;
                        }
                    }

                    Console.WriteLine("wait from run");
                    Monitor.Wait(this);
                }
            }
        }

        public void Run<T>(Action<T> action, T obj)
        {
            Action result = new Action(() => action(obj));
            Run(result);
        }


        private void Work(object? argInt) //todo action arg
        {
            if (argInt is int slot)
            {
                Console.WriteLine($"Thread {slot} started");
                while (true)
                {
                    lock (_isThreadWorkingMarkers[slot]) //just w8 for monitor from run
                    {
                        lock (this)
                        {
                            _isThreadWorkingMarkers[slot].Value = false;
                            Console.WriteLine($"pulse from{slot}");
                            Monitor.PulseAll(this);
                        }

                        Monitor.Wait(_isThreadWorkingMarkers[slot]);
                        Console.WriteLine($"Thread {slot} working");
                        _callBacks[slot]?.Invoke();
                    }
                }
            }

            throw new Exception("NOT INT EXCEPTION !!!");
        }
    }

    public class FlagHolder
    {
        public bool Value { get; set; }
    }
}