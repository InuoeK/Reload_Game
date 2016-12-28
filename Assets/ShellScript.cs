using UnityEngine;

public class ShellScript : MonoBehaviour {

    void OnEnable()
    {
        Invoke("Destroy", 2f);
        
        InvokeRepeating("ApplyRotation", 0.0f, Random.Range(0.01f, 0.03f));
        ApplyForce();


    }

 

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    private void ApplyForce()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2.0f,0.01f), Random.Range(-0.5f,2.0f));
    }

    private void ApplyRotation()
    {
        Vector3 angle = transform.eulerAngles;
        angle.z += 10.0f;
        transform.eulerAngles = angle;
    }

}
