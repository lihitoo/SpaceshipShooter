using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aesteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public int moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
    }
}
