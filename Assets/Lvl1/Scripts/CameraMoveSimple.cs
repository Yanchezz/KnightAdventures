using UnityEngine;
public class CameraMoveSimple : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, -10);
    }
}