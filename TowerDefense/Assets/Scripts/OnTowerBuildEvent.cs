using System;
using TowerDefense;
using UnityEngine.Events;

namespace College
{
    [Serializable]
    public class OnTowerBuildEvent : UnityEvent<TowerController> { }
}