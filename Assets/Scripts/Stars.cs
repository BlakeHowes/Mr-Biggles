using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    [SerializeField]
    private float amount;
    [SerializeField]
    public float timer;
    [SerializeField]
    public Vector3 startpos;
    void Start()
    {
        startpos = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 offset = new Vector3(amount, amount, amount);
        transform.position += offset;
        if(timer < 0.2)
        {
            transform.position = startpos + offset;
        }
        if (timer > 0.2)
        {
            transform.position = startpos - offset;
        }
        if(timer > 0.4)
        {
            timer = 0f;
        }

        if (Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("Street");
        }
    }
}
