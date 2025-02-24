using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawer : MonoBehaviour
{
    public float maxTime = 2;
    private float timer = 0;
    public GameObject pipe;
    public float minY = -1;
    public float maxY = 1;

    public bool enablePipeSpawer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        enablePipeSpawer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enablePipeSpawer == true)
        {
            if (timer > maxTime)
            {
                GameObject newpipe = Instantiate(pipe);
                newpipe.transform.position = transform.position + new Vector3(0, Random.Range(minY, maxY), 0);
                Destroy(newpipe, 15);

                timer = 0;
            }
            timer += Time.deltaTime;
        }
        
    }
}
