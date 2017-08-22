using System;
using System.Collections.Generic;
using System.Numerics;


namespace Fibonacci
{
    public class FibonacciGenerator
    {
        private Dictionary<uint, BigInteger> _cache = new Dictionary<uint, BigInteger>();

        private BigInteger Fib(uint n) => n < 2 ? new BigInteger(n) : BigInteger.Add(FibValue(n - 1), FibValue(n - 2));

        private BigInteger FibValue(uint n)
        {
            if (!_cache.ContainsKey(n))
            {
                _cache.Add(n, Fib(n));
            }

            return _cache[n];
        }

        public IEnumerable<BigInteger> Generate(uint n)
        {
            for (uint i = 0; i < n; i++)
            {
                yield return FibValue(i);
            }
        }
    }
}
