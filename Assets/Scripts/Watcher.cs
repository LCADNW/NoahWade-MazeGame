using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    Transform targ { get => PlayerSingleton.Instance.transform; }
    bool alreadyAttacking = false;
    [ShowInInspector] bool watching = true;
    [SerializeField] bool canAttack = false;
    [SerializeField] float coolDownTime = 2f;
    [SerializeField] float watchTime = 5f;
    [SerializeField] private float speed = 1.2f;

    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(!alreadyAttacking || watching)
            transform.LookAt(targ);

        if (!alreadyAttacking && canAttack)
            StartCoroutine(routine: Attack());

    }

    IEnumerator Watch()
    {
        watching = true;
        yield return new WaitForSeconds(watchTime + Random.Range(4, 10));
        alreadyAttacking = false;
        watching = false;
    }

    IEnumerator Attack()
    {
        alreadyAttacking = true;
        AttackFunctionality();
        yield return new WaitForSeconds(coolDownTime);
        StartCoroutine(Watch());
    }

    void AttackFunctionality()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
