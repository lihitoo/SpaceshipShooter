using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public static int EnemyHP;
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    private float timer = 0f;
    private float leftBound ;
    private float rightBound ;
    private float direction=-1f;
    //public static bool check = false;
    public GameObject flame;
    public GameObject line;
    private Renderer myRendererLine;
    private Renderer myRendererFlame;
    private AudioSource audioSource;
    void Start()
    {
        myRendererFlame = flame.GetComponent<Renderer>();
        myRendererFlame.enabled = false;
        myRendererLine = line.GetComponent<Renderer>();
        myRendererLine.enabled = false;

        audioSource = GetComponent<AudioSource>();
        leftBound = UnityEngine.Random.Range(-2.4f, -1f);
        rightBound = UnityEngine.Random.Range(1f, 2.4f);
    }
    void Update()
    {
        transform.position += new Vector3(direction * Time.deltaTime * 3f, 0, 0);
        
        if (transform.position.x <= leftBound)
        {
            direction = 1;
        }
        else if (transform.position.x > rightBound) direction = -1;
        timer += Time.deltaTime;
        if(timer>=1f)
        {
            leftBound = UnityEngine.Random.Range(-(GlobalVariables.screenWidth / 2f), 0f);
            rightBound = UnityEngine.Random.Range(0f, (GlobalVariables.screenWidth / 2f));
        }
        if(timer>=0.2f)
        {
            myRendererFlame.enabled = false;
            myRendererLine.enabled = false;
        }
        if (timer >= UnityEngine.Random.Range(2f,4f))
        {
            GameObject bullet= Instantiate(bulletPrefab,bulletPosition.position,Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, -10f), ForceMode2D.Impulse);
            timer = 0;
            myRendererFlame.enabled = true;
            myRendererLine.enabled = true;
            audioSource.Play();


        }
        



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //HP -= 50;
        //Destroy(other.gameObject);
        Debug.Log("ban trung");



    }

}
