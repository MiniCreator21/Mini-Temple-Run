using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 8f;
    [SerializeField] private float speedIncrease = 0.01f;
    [SerializeField] private float laneWidth = 2f;
    [SerializeField] int minLane = -1;
    [SerializeField] int maxLane = 1;
    [SerializeField] private float laneChangeSpeed = 12f;
    [SerializeField] private int currentLane = 0;
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        forwardSpeed += speedIncrease;

        Vector3 pos = transform.position;
        float targetX = currentLane * laneWidth;
        pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * laneChangeSpeed);
        transform.position = pos;
    }

    void OnMoveLeft()
    {
        if (currentLane <= minLane) return;
        currentLane -= 1;
    }
    void OnMoveRight()
    {
        if (currentLane >= maxLane) return;
        currentLane += 1;
    }
}
