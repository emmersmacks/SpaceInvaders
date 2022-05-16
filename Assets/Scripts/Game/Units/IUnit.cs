using System;
using UnityEngine;

namespace SpaceInvaders.Game.Units
{
    public class IUnit : MonoBehaviour
    {
        public Action IsHit = default;
        public Action IsDamage = default;

    }
}

