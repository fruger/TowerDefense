using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static TowerManager _instance;

    public static TowerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TowerManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<TowerManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
