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
    


    void Update()
    {
        trajectoryLine.ShowTrajectoryLine(muzzle.position,muzzle.forward*shotForce/cannonBallMass);
        if(Input.GetKeyDown(KeyCode.Space) && isWaiting == false)
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

    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(shootDelay);
        isWaiting=false;
    }
}
