using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Evil : MonoBehaviour {

    private Transform _Player;
    public float _UpdateAI = 0.0f;
    public const float _UpdateAIPeriod = 0.3f;

    private bool _Run = false;
    public float _AttackDistance = 1.5f;
    private bool _CanAttack = false;

    public float Life = 100.0f;

    public Transform DeathEffect;

    // Use this for initialization
    void Start () {
        _Player = GameObject.FindWithTag("Player").transform;
        _UpdateAI = Random.value;
    }

    // Update is called once per frame
    void Update () {
        if (Life <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            return;
        }
            

        _UpdateAI += Time.deltaTime;
        if(_UpdateAI > _UpdateAIPeriod)
        {
            _UpdateAI = 0.0f;
            NavMeshAgent na = GetComponent<NavMeshAgent>();
            na.SetDestination(_Player.position);

            _Run = na.desiredVelocity.magnitude > 0.5f;
            GetComponentInChildren<Animator>().SetBool("Run", _Run);

            Vector3 vecToPlayer = _Player.position - transform.position;
            float distToPlayer = vecToPlayer.magnitude;
            _CanAttack = distToPlayer < _AttackDistance;
            GetComponentInChildren<Animator>().SetBool("Attack", _CanAttack);
        }
        
    }


    public void OnCollisionEnter(Collision c)
    {
        Harmful h = c.transform.GetComponent<Harmful>();
        if(h != null)
        {
            Life -= h.Damages;
        }
    }
}
