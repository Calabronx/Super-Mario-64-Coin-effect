using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCoin : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] float xAngle, yAngle, zAngle;
    private const float MAX_UP_LIMIT = 0.650f;
    private const float MAX_DOWN_LIMIT = 0.600f;
    private bool maxLimit = false;

    private void Awake()
    {
        coin.transform.position = new Vector3(0.0f, MAX_DOWN_LIMIT, 0.0f);
    }
    void Update()
    {
        rotationEffect();
    }

    void rotationEffect()
    {
        const float velocity = 0.05f;
        const float rotationSpeed = 1.0f;

        coin.transform.Rotate(new Vector3(xAngle, yAngle, zAngle) * Time.deltaTime * rotationSpeed);

        if (!maxLimit)
        {
            coin.transform.Translate(Vector3.up * Time.deltaTime * velocity, Space.World);
            if (coin.transform.position.y >= MAX_UP_LIMIT)
                maxLimit = true;
        }
        else if (maxLimit)
        {
            coin.transform.Translate(Vector3.down * Time.deltaTime * velocity, Space.World);
            if (coin.transform.position.y <= MAX_DOWN_LIMIT)
                maxLimit = false;
        }
    }
}
