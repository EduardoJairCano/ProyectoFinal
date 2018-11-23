using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour {

    public float speed = 5f;
    public Text countText;
    public Text winText;

    private Transform cam;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private float mouseSensitivity = 205f;
    private float verticalLookRotation;
    private int count;

    public AudioClip collect;
    public AudioClip win;
    AudioSource audio;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        count = 0;
        setCountText();
        winText.text = "";

        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * yMov;
        Vector3 movUp = transform.up * zMov;
        velocity = (movHor + movVer + movUp).normalized * speed;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cam.localEulerAngles = Vector3.left * verticalLookRotation;

        
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottles"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();

            audio.clip = collect;
            audio.Play();

            if (count >= 13)
            {
                winText.text = "¡GANASTE!\n";
                audio.clip = win;
                audio.Play();
            }
        }
    }

    void setCountText()
    {
        countText.text = "PUNTUACION " + count.ToString();
    }
}
