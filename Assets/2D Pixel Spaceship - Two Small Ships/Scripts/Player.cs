using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;
    // Start is called before the first frame update
    public AudioClip audioSource;
    public AudioClip BulletSound;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    public int HP = 100;
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    private Renderer myRendererLine;
    private Renderer myRendererFlame;
    private float timer = 0f;
    public GameObject WinWindow;
    public Button ReplayButton;
    //public AudioClip collisionSound;
    public GameObject flame;
    public GameObject line;
    void Start()
    {
        ReplayButton.onClick.AddListener(() => OnReplayButtonClicked());
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource1.clip = audioSource;
        audioSource2.clip = BulletSound;
        myRendererFlame = flame.GetComponent<Renderer>();
        myRendererFlame.enabled = false;
        myRendererLine = line.GetComponent<Renderer>();
        myRendererLine.enabled = false;
        // Thiết lập âm thanh cho AudioSource
        //audioSource.clip = collisionSound;
        WinWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnReplayButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, -(GlobalVariables.screenWidth / 2f), (GlobalVariables.screenWidth / 2f));
        temp.y = Mathf.Clamp(temp.y, -(GlobalVariables.screenHeight / 2f), (GlobalVariables.screenHeight / 2f));
        transform.position = temp;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        if (timer > 0.2f)
        {
            myRendererFlame.enabled = false;
            myRendererLine.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject playerBullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
            Rigidbody2D rb = playerBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
            timer = 0;
            myRendererFlame.enabled = true;
            myRendererLine.enabled = true;
            /*while (true)
            {
                timer += Time.deltaTime;
                if(timer>=0.1f)
                {
                    timer = 0;
                    myRendererFlame.enabled = false;
                    myRendererLine.enabled = false;
                    break;
                }
            }*/

            audioSource2.Play();
        }
        
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Aesteroid") HP -= 10;
        if (other.gameObject.tag == "PlayerBullet") HP -= 5;
        Destroy(other.gameObject);
        if(HP<=0)
        {
            WinWindow.SetActive(true);
            Time.timeScale = 0f; // Tạm dừng thời gian
        }
        audioSource1.Play();
           
        
    }



}
