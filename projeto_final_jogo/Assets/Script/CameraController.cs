using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float time;
    public float minX, maxX;
    public float minY, maxY;

    private void FixedUpdate()
    {
        Vector3 newPosition = Player.position + new Vector3(0, 0, -10);
        newPosition.y = Player.position.y;
        newPosition = Vector3.Lerp(transform.position, newPosition, time);
        transform.position = newPosition;

        transform.position = new Vector3(math.clamp(transform.position.x, minX, maxX), math.clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}