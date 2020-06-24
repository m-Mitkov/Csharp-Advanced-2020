using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(params int[] input)
        {
            this.stones = input.ToList();
        }

        private List<int> FroggyGump(List<int> stones)
        {
            List<int> sortedStonesLake = new List<int>();

            for (int i = 0; i < stones.Count; i += 2)
            {
                sortedStonesLake.Add(stones[i]);
            }

            var buffer = stones.Count % 2 != 0
                ? 2
                : 1;

            for (int i = stones.Count - buffer; i >= 0; i -= 2)
            {
                sortedStonesLake.Add(stones[i]);
            }

            stones = sortedStonesLake;
            return stones;
        }
        public IEnumerator<int> GetEnumerator()
        {
            stones = FroggyGump(stones);

            foreach (var item in stones)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
