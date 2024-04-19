using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sound;
    public GameObject WinWindow;
    public Button ReplayButton;
    public int EnemyHp;
    private AudioSource playerBulletSound;
    void Start()
    {
        Time.timeScale = 1f;
        playerBulletSound = gameObject.AddComponent<AudioSource>();
        playerBulletSound.clip = sound;
        ReplayButton.onClick.AddListener(() => OnReplayButtonClicked());
        WinWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnReplayButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //Destroy(other.gameObject);
      
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Debug.Log("ban trung");
            playerBulletSound.Play();
            EnemyHp -= 10;
                if (EnemyHp <= 0)
            {
               // Destroy(gameObject);
                WinWindow.SetActive(true);
                Time.timeScale = 0f; // Tạm dừng thời gian
            }
        }
        
    }
    
}
