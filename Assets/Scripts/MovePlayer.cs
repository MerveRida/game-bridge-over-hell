using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    public int playerSpeed = 10;
    private float horizontal;
    private float vertical;
    static public int counter=0;
    public Text puanText;
    public Text hizText;
    public Text updateText;
    public AudioSource hoperlor;
    public AudioClip puanSes;
    public AudioClip eksiSes;
    public AudioClip hizlanSes;
    public AudioClip yavaslaSes;
    public string[] hasenatlar;
    public string[] haramlar;
    public int[] hasenatPuanlarArray;
    public int[] haramPuanlarArray;
    public int currentPuan;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puanText.text = "Hasenat Puan: " + counter;
        hizText.text = "Hiz: " + playerSpeed;
        updateText.text = " ";
        hasenatlar = new string[] { "Sadaka verdin ", "Namaz kildin ", "Oruc Tuttun ", "Akrabalarini ziyaret ettin ", "Bir yetimi sevindirdin ", "Tefekkur ettin", "Tebessum ettin", "Kuran okudun", "Sure ezberledin", "Agac diktin", "Hacca gittin", "Annene yardim ettin", "Camiye gittin" };
        hasenatPuanlarArray = new int[] { 100, 300, 150, 130, 170, 300, 100, 180,190, 115, 300, 120, 150};
        haramlar = new string[] { "Hirsizlik yaptin ", "Icki ictin ", "Kumar oynadin ", "Bir insanin kalbini kirdin ", "Insanlara zulmettin", "Yalan soyledin", "Dedikodu yaptin", "Inslanlari asagiladin", "Hayvanlara iskence ettin", "Kotu aliskanliklar edindin", "Isyan ettin" };
        haramPuanlarArray = new int[] { 150, 200, 200, 300, 500, 100, 150, 100, 100, 100, 300};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right") || Input.GetKey(KeyCode.Space))
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            movement = new Vector3(horizontal, 0.0f, vertical);

            rb.AddForce(movement * playerSpeed);
        }
        else
        {
            movement = new Vector3(0.0f, rb.velocity.y, 0.0f);
            rb.velocity = movement;
        }

        if(transform.position.y <= 0)
        {
            if (counter < 500)
            {
                counter=0;
                SceneManager.LoadScene("LostScene");
            }
            else
            {
                counter -= 500;
                SceneManager.LoadScene("RestartScene");
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("haramTag")){
            int random = Random.Range(0, (haramPuanlarArray.Length - 1));
            currentPuan = haramPuanlarArray[random];
            Debug.Log("Eyvah, gunah!");
            counter -= currentPuan;
            puanText.text = "Hasenat Puan: " + counter;
            hoperlor.PlayOneShot(eksiSes);
            //random.Next(min, max); returns a random number in between
            updateText.text = haramlar[random] +" -"+ currentPuan;
        }

        else if (other.gameObject.CompareTag("sevapTag"))
        {
            int random = Random.Range(0, (hasenatPuanlarArray.Length - 1));
            currentPuan = hasenatPuanlarArray[random];
            Debug.Log("Elhamdulillah Sevap!");
            other.gameObject.SetActive(false);
            counter += currentPuan;
            puanText.text = "Hasenat Puan: " + counter;
            hoperlor.PlayOneShot(puanSes);
            updateText.text = hasenatlar[random] + " +"+ currentPuan;
            Debug.Log(random);
            Debug.Log(hasenatlar[random]);

        }

        else if (other.gameObject.CompareTag("bosTag"))
        {
            Debug.Log("Zamani israf etme");
            other.gameObject.SetActive(false);
            playerSpeed = playerSpeed / 2;
            hizText.text = "Hiz: " + playerSpeed;
            hoperlor.PlayOneShot(yavaslaSes);
            updateText.text = "Zamanini israf ettigin icin yavasladin";
        }

        else if (other.gameObject.CompareTag("ilimTag"))
        {
            Debug.Log("Ilim berekettir");
            other.gameObject.SetActive(false);
            playerSpeed = playerSpeed * 2;
            hizText.text = "Hiz: " + playerSpeed;
            hoperlor.PlayOneShot(hizlanSes);
            updateText.text = "Ilim ogrendigin icin hizlandin";
        }

        else if (other.gameObject.CompareTag("cennetKapisi"))
        {
            counter = 0;
            SceneManager.LoadScene("Kazandin");
            
        }


    }

    static public int getCounter()
    {
        return counter;
    }

}
