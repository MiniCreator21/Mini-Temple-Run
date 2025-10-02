using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunner : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float acceleration = 0.01f;
    private float proximityToMaxSpeed;
    [SerializeField] private float maxSpeed = 40f;
    [SerializeField] private float laneWidth = 2f;
    [SerializeField] int minLane = -1;
    [SerializeField] int maxLane = 1;
    [SerializeField] private float laneChangeSpeed = 12f;
    [SerializeField] private int currentLane = 0;

    void Start()
    {
        proximityToMaxSpeed = (maxSpeed - speed) / maxSpeed;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos += Vector3.forward * speed * Time.deltaTime;
        speed += acceleration * proximityToMaxSpeed;
        proximityToMaxSpeed = (maxSpeed - speed) / maxSpeed;

        float targetX = currentLane * laneWidth;
        pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * laneChangeSpeed);
        transform.position = pos;
    }

    public void HandleMovement(InputAction.CallbackContext inputData)
    {
        Vector2 inputVector = inputData.ReadValue<Vector2>();

        Debug.Log(inputVector.x);

        if (inputVector.x != 0)
        {
            currentLane = Mathf.Clamp(currentLane + Mathf.RoundToInt(inputVector.x), minLane, maxLane);
        }
    }

    //void OnMoveLeft()
    //{
    //    if (currentLane <= minLane) return;
    //    currentLane -= 1;
    //}
    //void OnMoveRight()
    //{
    //    if (currentLane >= maxLane) return;
    //    currentLane += 1;
    //}
}
