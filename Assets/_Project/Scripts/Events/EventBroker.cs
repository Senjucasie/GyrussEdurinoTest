using System;
using UnityEngine;

namespace Gynuss.Events
{
    public class EventBroker
    {
        public static event Action<Vector3> FireBullet;
        public static event Action<int> AddScore;

        public static void CallFireBullet(Vector3 position) => FireBullet?.Invoke(position);
        public static void CallAdScore(int score) => AddScore?.Invoke(score);
    }
}

