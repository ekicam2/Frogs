using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float damage;
    public float speed;

    private Rigidbody rigidbody;

    //DEBUG
    private Vector3 debugStartPos;

	void OnCollisionEnter(Collision collision)
    {
        var other = collision.gameObject;
        Destroy(gameObject);
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.DrawLine(debugStartPos, transform.position, Color.magenta);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
