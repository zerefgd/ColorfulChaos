using UnityEngine;

public class Player : MonoBehaviour
{
    public int ColorId;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = GameplayManager.Instance.Colors[ColorId];
    }
}
