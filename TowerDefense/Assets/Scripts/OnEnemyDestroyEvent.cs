using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    [Serializable]
    public class OnEnemyDestroyEvent : UnityEvent<Enemy>
    {

    }
}
