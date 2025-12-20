using UnityEngine;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    public List < ParticleSystem > explosionParticle;

    [SerializeField] private float minUpwardForce = 12f, maxUpwardForce = 16f;
    [SerializeField] private float minTorque = -5f, maxTorque = 5f;
    [SerializeField] private float minX = -4f, maxX = 4f;
    [SerializeField] private float lowerBound = -20f;
    public int scoreValue = 15;

    private Rigidbody targetRb;
    private float upForce;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent < Rigidbody > ();
        gameManager = GameObject.Find ( "Game Manager" ).GetComponent < GameManager > ();
        AddRandomUpwardForce ( targetRb, minUpwardForce, maxUpwardForce );
        AddRandomTorque ( targetRb, minTorque, maxTorque );
        SetRandomPosition ( minX, maxX );
    }

    //void OnMouseDown ()
    //{
    //    if ( !gameManager.isGameOver && !gameManager.isGamePaused )
    //    {
    //        if ( gameObject.CompareTag ( "Good" ) )
    //        {
    //            gameManager.GameOver ();
    //            Death ( 0 );
    //        }
    //        else
    //        {
    //            Death ( scoreValue );
    //        }
    //    }
    //}

    void OnTriggerEnter ( Collider trigger )
    {
        if ( gameObject.CompareTag ( "Bad" ) ) gameManager.DealDamage ( 1 );
        Death ( 0 );
    }

    void AddRandomUpwardForce ( Rigidbody rb, float minForce, float maxForce )
    {
        rb.AddForce ( Vector3.up * Random.Range ( minForce, maxForce ), ForceMode.Impulse );
    }

    void AddRandomTorque ( Rigidbody rb, float minForce, float maxForce )
    {
        rb.AddTorque ( Random.Range ( minForce, maxForce ),
                             Random.Range ( minForce, maxForce ),
                             Random.Range ( minForce, maxForce ),
                             ForceMode.Impulse );
    }

    void SetRandomPosition ( float minXCoord, float maxXCoord )
    {
        transform.position = new Vector3 ( Random.Range ( minXCoord, maxXCoord ), -6f, 0f );
    }

    // Update is called once per frame
    void Update()
    {
        CheckY ();
    }
    
    void CheckY ()
    {
        if ( transform.position.y < lowerBound )
        {
            if ( gameObject.CompareTag ( "Bad" ) ) gameManager.DealDamage ( 1 );
            Death ( 0 );
        }
    }

    public void Death ( int value )
    {
        gameManager.UpdateScore ( value );
        Instantiate ( explosionParticle [ Random.Range ( 0, explosionParticle.Count ) ],
                      transform.position,
                      explosionParticle [ Random.Range ( 0, explosionParticle.Count ) ].transform.rotation );
        Destroy ( gameObject );
    }
}
