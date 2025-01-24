using UnityEngine;

public class circleScript : MonoBehaviour
{
    private float maxRadius;
    private float growSpeed;  
    private float duration;   
    private float timer = 0f;
    private void Start()
    {
       GetComponent<CapsuleCollider>().enabled = false;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        if (transform.localScale.x < maxRadius)
        {
            float scale = Mathf.Min(maxRadius, transform.localScale.x + growSpeed * Time.deltaTime);
            transform.localScale = new Vector3(scale, 1f, scale);
        }
        if (timer >= duration && gameObject.name!="Circle")
        {
            Destroy(gameObject);
        }
        
    }
    public void Initialize(float maxRadius, float growSpeed, float duration)
    {
        this.maxRadius = maxRadius;
        this.growSpeed = growSpeed;
        this.duration = duration;
        transform.localScale = Vector3.zero;
    }
}
