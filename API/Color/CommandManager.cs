using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public static CommandManager _instance;
    public static CommandManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The Command Manager is NULL. ");
            }
            return _instance;
        }
    }

    private List<ICommand> commandBuffer = new List<ICommand>();
  
    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create a method to add comand to the command buffer
    public void AddCommand(ICommand command)
    {
        commandBuffer.Add(command);
    }
    //create a play routine triggered by a play button that's going to play back all the commands
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    //1 seconds delay
    IEnumerator PlayRoutine()
    {
        foreach(var command in commandBuffer)
        {
            command.Execute();
            yield return new WaitForSeconds(1);
        }
        
    }
    

    //create a rewind routine that's going to play in reveres, with 1 second delay
    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine()
    {
        foreach(var command in Enumerable.Reverse(commandBuffer))
        {
            command.Execute();
            
            yield return new WaitForSeconds(1);
        }
        
    }

    //done - finished with changing color, turn them all white
    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach(var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    //reset - clear the command buffer
    public void Reset()
    {
        commandBuffer.Clear();
    }
}
