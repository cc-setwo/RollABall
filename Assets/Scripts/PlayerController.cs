using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float MooveSpeed = 0.1f;
    private Rigidbody rb;
    private float count;

    public Text CountText;
    public Text WinText;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 m=new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(m* MooveSpeed);
        
    }
    void OnTriggerEnter(Collider cl)
    {
        if (cl.gameObject.CompareTag("Coin"))
        {
             cl.gameObject.SetActive(false);
            count+=0.5f;
            SetCountText();
        }
            
    }
    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You win!";
        }
    }
}
