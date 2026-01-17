
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask barrier;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform playerMovePoint;
    [SerializeField] private Transform playerDirection;
    private InputAction _movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovePoint.parent = null; 
        _movement = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);
        if (!Mathf.Approximately(Vector3.Distance(transform.position, playerMovePoint.position), 0f)) return;
        if (!_movement.inProgress) return;
        Vector2 direction = _movement.ReadValue<Vector2>();
        
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            Vector3 xDirection = new Vector3(Mathf.RoundToInt(direction.x), 0f, 0f);
            if (Physics2D.OverlapCircle(playerMovePoint.position + xDirection, .9f, barrier)) return;
            playerMovePoint.position += xDirection;
            playerDirection.position = transform.position + xDirection;
        }
        else
        {
            Vector3 yDirection = new Vector3(0f, Mathf.RoundToInt(direction.y), 0f);
            if (Physics2D.OverlapCircle(playerMovePoint.position + yDirection, .9f, barrier)) return;
            playerMovePoint.position += yDirection;
            playerDirection.position = transform.position + yDirection;
        }
    }
}
