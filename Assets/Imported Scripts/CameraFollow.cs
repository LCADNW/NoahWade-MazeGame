using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 PlayerLoc { get => PlayerSingleton.Instance.gameObject.transform.position; }
    public float zOffset = -5f;
    public Transform lookAtPoint;
    public float hiehgt = 10;

    private void LateUpdate()
    {
        transform.position = new Vector3(PlayerLoc.x, PlayerLoc.y + hiehgt, PlayerLoc.z + zOffset);
        transform.LookAt(lookAtPoint);
    }
}
