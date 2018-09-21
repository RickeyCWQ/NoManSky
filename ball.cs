using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ball : MonoBehaviour 
{
    Rigidbody rb;
    Rigidbody rb2;


    public float speed;
    public float rotateSpeed;
    public Material boostMaterial;
    public Material oldMaterial;
    public Material defaultMaterial;

	//Audio Part
	AudioSource BounceSound;
	public AudioClip Bounce;
	AudioSource IceSound;
	public AudioClip Ice;

	//Text
    public Text Text;
    public Text Text1;

    public GameObject Sphere01;
    int count;
    // Use this for initialization
    void Start () 
	{
        rb = GetComponent<Rigidbody>();
		BounceSound = GetComponent<AudioSource>();
		IceSound = GetComponent<AudioSource>();
        //rb2 = Sphere01.GetComponent<Rigidbody>();
        //Sphere01.SetActive(false);
        Text.text = "no color";
        count = 0;
    }
	
	// Update is called once per frame
	void Update () 
	{
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0, v);
            float y = Camera.main.transform.rotation.eulerAngles.y;
            targetDirection = Quaternion.Euler(0, y, 0) * targetDirection;

            rb.AddForce(targetDirection*speed/2);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotateSpeed);
        }

        Vector3 startpoint = new Vector3(0, 3, 0);
        Vector3 startspeed = new Vector3(0, 0, 0);
        if ((transform.position - startpoint).sqrMagnitude >= 10000)
        {
            GetComponent<Transform>().position = startpoint;
            rb.velocity = startspeed;
        }
        //Vector3 movement;
        //movement.x = Input.GetAxis("Horizontal");
        //movement.y = 0;
        //movement.z = Input.GetAxis("Vertical");
        //rb.AddForce(movement * speed);

        Text.text = GetComponent<Renderer>().material.ToString();
        Text1.text = count.ToString();
        //Text.text = rb2.velocity.ToString();
        if (speed>=15)
        {
            count++;
        }
        if (count >=100)
        {
            //oldMaterial.CopyPropertiesFromMaterial(defaultMaterial);
            count = 0;speed = 5;
        }

    }

    private void OnTriggerEnter(Collider tag)
    {
        if (tag.gameObject.CompareTag("boost")){
            //oldMaterial = GetComponent<Renderer>().material;
            //oldMaterial.CopyPropertiesFromMaterial(boostMaterial);
            //speed +=300;
            rb.AddForce(0, 1200f, 0);
            //rb.AddForce(300f, 100f, 0);
        }

        if (tag.gameObject.CompareTag("jump"))
        {
            rb.AddForce(0, 500f, 0);
        }

        if (tag.gameObject.CompareTag("gravity"))
        {
            //Physics.gravity = new Vector3(-3f, 0, 0);
        }
        if (tag.gameObject.CompareTag("endding"))
        {
            SceneManager.LoadScene("endscenen");
        }

		//Audio
		if (tag.gameObject.CompareTag("wall"))
		{
			BounceSound.PlayOneShot(Bounce,1f);
		}

		if (tag.gameObject.CompareTag("Ice"))
		{
			IceSound.PlayOneShot(Ice,1f);
		}
    }

}



