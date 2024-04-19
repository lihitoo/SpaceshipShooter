using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aesteroidPrefab;
    private float timer = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            Instantiate(aesteroidPrefab,
            new Vector3(UnityEngine.Random.Range(-GlobalVariables.screenWidth / 2f, GlobalVariables.screenWidth / 2f), 6f, 0),
            Quaternion.identity);
            timer = 0;
        }
    }
}
