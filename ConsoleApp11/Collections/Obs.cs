using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ConsoleApp11.Collections
{
    public class Obs
    {
        public void Observing(object? sender, NotifyCollectionChangedEventArgs args)
        {
            ObservableCollection<Human> temp = (ObservableCollection<Human>) sender!;
            
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Action ADD");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Action REMOVE");
                    temp.Add(new Human(){FirstName = "Obs child"});
                    break;
                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine($"Action MOVE");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine($"Action REPLACE");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine($"Action RESET");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }
    }
}