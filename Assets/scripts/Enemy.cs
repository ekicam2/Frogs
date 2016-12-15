using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public float health;
    public float armor;
    public float speed;
    public float damage;
    public AnimationClip[] animations;
    public Graph graph;
    public uint price;

    private Animation animation;
    private TextMesh textMesh;
    private Player target;
    private bool isWalking;
    private bool isTargeting;
    private bool isAttacking;
    private bool isDying;
    private List<Vector3> path;
    private int currentPathNode;

    void Start()
    {
        animation       = GetComponent<Animation>();
        textMesh        = GetComponentInChildren<TextMesh>();
        textMesh.text   = health.ToString();
        target          = GodObject.Player;
        path            = graph.getPath();
        isWalking       = true;
        isAttacking     = false;
        isTargeting     = false;
        isDying         = false;
        currentPathNode = 0;
        lookAtNextNode();
    }

    void Update() {
        if (health <= 0)
        {
            die();
            return;
        }

        if (checkIfReachedNode())
        {
            //check if enemy has reached last point
            if (currentPathNode == path.Count - 1)
            {
                isWalking   = false;
                isTargeting = true;
                //transform.LookAt(target.transform);
            }
            else
                ++currentPathNode;

            lookAtNextNode();
        }

        //walk only if we are animating walking
        if (isWalking)
            moveToNextNode();

        if (isTargeting)
            StartCoroutine(attack());
    }


    public void takeDamage(float dmg)
    {
        if (health > 0)
        {
            //play "Take Damage" animation
            animation.Play(animations[0].name, PlayMode.StopAll);
            isWalking = false;

            health -= (dmg - armor) < 0 ? 0 : dmg - armor;
            textMesh.text = health.ToString();

            //play walk/run animation again
            StartCoroutine(delay(animations[0].length));
            animation.Play(animations[1].name);
            isWalking = true;
        }
    }

    IEnumerator delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    void die()
    {
        if (!isDying)
        {
            health = 0;
            isDying = true;
            isWalking = false;
            animation.Play(animations[2].name, PlayMode.StopAll);
            target.increaseMoney(price);
            Destroy(gameObject, animations[2].length);
        }
    }

    void moveToNextNode()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    bool checkIfReachedNode()
    {
        var distanceVec = path[currentPathNode] - transform.position;
        return distanceVec.magnitude <= 1f;
    }

    void lookAtNextNode()
    {
        transform.LookAt(path[currentPathNode]);
    }

    IEnumerator attack()
    {
        if(!isAttacking)
        {
            isWalking = false;
            isAttacking = true;
            animation.Play(animations[3].name);
            target.takeDamage(damage);
            yield return new WaitForSeconds(animations[3].length);
            isAttacking = false;
        }
    }
}
