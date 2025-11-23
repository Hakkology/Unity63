using UnityEngine;

public class TakipObjesi : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private bool takipEt;

    public int speed = 6;

    private void Start()
    {
        player = GameObject.Find("Player");
        takipEt = false;
        Invoke(nameof(Takip), 6);
    }
    private void Update()
    {
        if (takipEt && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            Vector3 yon = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(yon);
        }
    }

    void Takip()
    {
        takipEt = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var controller = other.gameObject.GetComponent<PlayerRunnerController>();
            controller.PuanArtir(10);
            //Destroy(gameObject);

            float xKoordinati = Random.Range(-1, 2);
            xKoordinati *= 15;

            var konum = new Vector3(xKoordinati, 1, player.transform.position.z + 50);
            transform.position = konum;
            //transform.position
        }
    }

}
