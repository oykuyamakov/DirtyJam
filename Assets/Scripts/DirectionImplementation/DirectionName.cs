using System;
using UnityEngine;

namespace DirectionImplementation
{
    [Flags]
    public enum DirectionName
    {
        W = 2,
        A = 4,
        S = 8,
        D = 16,
    }
}
