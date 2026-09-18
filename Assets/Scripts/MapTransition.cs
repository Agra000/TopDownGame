using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] float additivePos = 2;

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Awake()
    {
        confiner = Object.FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 playerPosition = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
                playerPosition.y += additivePos; // Move player up
                break;
            case Direction.Down:
                playerPosition.y -= additivePos; // Move player down
                break;
            case Direction.Left:
                playerPosition.x += additivePos; // Move player left
                break;
            case Direction.Right:
                playerPosition.x -= additivePos; // Move player right
                break;
        }
        player.transform.position = playerPosition;
    }
}
