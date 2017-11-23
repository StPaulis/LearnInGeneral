using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWebAspBooks.Extensions.Calculations
{
    //TODO: extract Interfaces
    public interface ICounterService<T>
    {
        void Increment();
        T GetValue();
    }

    public interface ICounterStore<T>
    {
        T Value { get; set; }
    }

    public class CounterService : ICounterService<int>
    {
        private readonly ICounterStore<int> _counterStore;

        public CounterService(ICounterStore<int> counterStore)
        {
            _counterStore = counterStore;
        }

        public void Increment() => _counterStore.Value++;

        public int GetValue() => _counterStore.Value;
    }
 
    public class CounterStore : ICounterStore<int>
    {
        public int Value { get; set; }
    }
}
