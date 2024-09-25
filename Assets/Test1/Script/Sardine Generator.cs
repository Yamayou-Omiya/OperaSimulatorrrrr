using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineGenerator : MonoBehaviour
{
    public Rigidbody rigidbody;
    public AreaController areaCnt;

    public GameObject sardinePrefab;
    public GameObject sardine;

    public int areaKey = 0;

    public float width = 4.5f;
    public float height = 2.3f;
    private float x = 0;  
    private float z = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        areaCnt = GameObject.Find("Controll Area").GetComponent<AreaController>();
        SardineSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if(areaCnt.sardineKey == 0)
        {
            SardineSpawner();
            areaKey = 1;
        }
        else
        {
            areaKey = 0;
        }
    }

    private void SardineSpawner()
    {
        sardine = Instantiate(sardinePrefab) as GameObject;

        x = Random.Range(- width + 0.5f, width - 0.5f);
        z = Random.Range(- height + 0.5f, height - 0.5f);

        sardine.transform.position = new Vector3(x, 0.5f, z);
    }

}
