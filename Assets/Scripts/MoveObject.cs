using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : Operator
{
    private float moveSpeed = 1.0f;
    public Vector3 moveDirection = Vector3.left;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        moveSpeed = Operator.gameSpeed;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        moveSpeed = Operator.gameSpeed;
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
    }
}
