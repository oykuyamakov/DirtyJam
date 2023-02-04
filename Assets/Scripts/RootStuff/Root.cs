using BeatStuff;
using Pooling;
using UnityEngine;

namespace RootStuff
{
    [RequireComponent(typeof(MoveToTheBeat))]
    public class Root : MonoBehaviour, IPoolable<Root>
    {
        public Root Return(Transform parent = null)
        {
            return this;
        }

        public Root Get()
        {
            return this;
        }
    }
}