using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerScripts : MonoBehaviour {

    private float speed;
    private Vector3 direction;

    public GameObject particleSystem;

    public static bool isDead;
    private bool onPlatform;

    private int collisions;

    public Text scoreText;

    void Start () {
        isDead = false;
        direction = Vector3.zero;
        speed = 12.0f;

        InvokeRepeating("IncreaseSpeed", 5.0f, 2.0f);   //crestem progresiv viteza de miscare, dupa 5 secunde, la fiecare 2 secunde
    }
	
	void Update () {
        

		if (Input.GetMouseButtonDown(0) && !isDead)     //getmousebuttondown(0)  se traduce in o atingere pe android
        {
            

            // Verificam daca se da click pe un element de UI
            
            if (!IsPointerOverUIObject())
            {

                if (UiManager.instance.started == false)
                {
                    UiManager.instance.GameStart();
                    ScoreManager.instance.NewGame();
                }


                ScoreManager.score++;                                   //la fiecare schimbare de directie crestem scorul cu 1

                scoreText.text = ScoreManager.score.ToString();
                if (direction == Vector3.forward)
                {
                    direction = Vector3.left;
                }
                else
                {
                    direction = Vector3.forward;
                }
            } 


           
        }

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(direction * amountToMove);

       
       
	}

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);                                      //dezactivam diamantul
            Instantiate(particleSystem, transform.position, Quaternion.identity);   //instantiem particulele
            ScoreManager.score +=3;                                                 //crestem scorul cu 3
            scoreText.text = ScoreManager.score.ToString();                         //afisam scorul in dreapta sus
            
        }
    }
    
    //folosind oncollisionenter si oncollisionexit verificam daca bila este pe platforma sau a cazut
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tile")
        {
            collisions++;
            print(collisions);
            onPlatform = true;
        }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "tile")
        {
            collisions--;
            print(collisions);
            if (collisions == 0)
            {
                onPlatform = false;

                //game over

                isDead = true;
                
                UiManager.instance.GameOver();
                Admanager.Instance.ShowVideo();


            }
        }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void IncreaseSpeed()
    {
        speed += 0.1f;
    }


    //detectam daca atingem un obiect de UI
    //dezactivam Raycast Target pentru a ignora un obiect de UI
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
