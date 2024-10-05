using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : Operator
{
    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Operator.gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Operator.gameSpeed;
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
