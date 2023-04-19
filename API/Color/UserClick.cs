using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClick : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //left click
        //cast a ray
        //detect a cube
        //aasign random color

        
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            //store anything that the ray hits
            RaycastHit hitInfo;
            //check if you hit a cube
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //check the collider of the object
                if (hitInfo.collider.tag == "Cube")
                {
                    //command execution
                    Debug.DrawLine(rayOrigin.origin, hitInfo.point, Color.red, 1f);
                    //Debug.Log(hitInfo.collider.gameObject.name);
                    
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject, new Color(Random.value, Random.value, Random.value));
                    click.Execute();
                    CommandManager._instance.AddCommand(click);
                    //hitInfo.collider.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
                    //hitInfo.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
        }
        
    }
     
}
