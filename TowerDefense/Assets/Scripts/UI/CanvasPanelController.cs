using TowerDefense;
using UnityEngine;

public class CanvasPanelController : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStart += HandleGameStart;
            GameManager.Instance.OnGameEnd += HandleGameEnd;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStart -= HandleGameStart;
            GameManager.Instance.OnGameEnd -= HandleGameEnd;
        }
    }

    private void HandleGameStart()
    {
        Debug.Log("Start");
    }

    private void HandleGameEnd()
    {
        Debug.Log("End");
    }
}
