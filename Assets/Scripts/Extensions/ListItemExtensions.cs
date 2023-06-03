using System.Collections.Generic;
using UnityEngine;

namespace QueueGame.Extensions
{
    public static class ListItemExtensions
    {
        public static T GetRandom<T>(this IReadOnlyList<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list[index];
        }
    }
}
