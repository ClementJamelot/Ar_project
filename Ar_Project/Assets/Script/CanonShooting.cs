using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanonShooting : MonoBehaviour
{

    [SerializeField]
    private GameObject cannonBall;
    [SerializeField]
    private Transform muzzle;
    [SerializeField,Min(1)]
    private float cannonBallMass = 30;
    [SerializeField,Min(1)]
    private float shotForce = 30;
    [SerializeField]
    private float shootDelay = 1;
    private bool isWaiting = false;
    [SerializeField]
    private TrajectoryLine trajectoryLine;

    public UnityEvent Onshoot;
    

    //Montre la trajectoire
    void Update()
    {
        trajectoryLine.ShowTrajectoryLine(muzzle.position,muzzle.forward*shotForce/cannonBallMass);
        
    }
    //Attente entre les tire
    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(shootDelay);
        isWaiting=false;
    }
    //Tire si pas en recharge
    //On crée la munition on la positionnne, on lui donne une masse et une force qui sont les meme que la trajectoire
    public void Shot()
    {
        if(isWaiting == false)
        {
            GameObject ball = Instantiate(cannonBall);
            ball.transform.position = muzzle.position;
            Onshoot?.Invoke();
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.mass=cannonBallMass;
            rb.AddForce(muzzle.forward*shotForce,ForceMode.Impulse);
            isWaiting = true;
            
            StartCoroutine(DelayShooting());

        }
    }
}
