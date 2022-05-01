using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private int stackBlueResources;

    private int stackYellowResources;

    private int stackGreenResources;

    bool isStackBlueResources = false;
    bool isStackYellowResources = false;
    bool isSpawn = true;
    public Joystick joystick;
    [SerializeField] private BlueTower newblueTower;
    [SerializeField] private YellowTower newYellowTower;

    [SerializeField] private GreenTower newGreenTower;

     
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform spawnerPoint;

    [SerializeField] private GameObject SpawnerBlueResources;

    [SerializeField] private GameObject SpawnerYellowResources;

    [SerializeField] private Text YellowResourcText;
    [SerializeField] private Text BlueResourcText;
    [SerializeField] private Text  YellowBlueResourcText;

    
    private    GameObject new_gameObject;
    AudioSource audioSource;

    public float speed = 7f;
    private float vertical;
    private float horizontal;
   
    private Rigidbody _rigidbody;
    void Start()
    {
        Inventory inventory = new Inventory();
        audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vertical = joystick.Vertical;

        horizontal = joystick.Horizontal;
        MoveCharacter(new Vector3(horizontal,0,vertical));
        RotateCharacter(new Vector3(horizontal,0,vertical));
        
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        Vector3 offset = moveDirection* speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    
     

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection)>0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotationSpeed * Time.deltaTime,0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "BlueResourc":
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                if (stackBlueResources ==0 && !isStackYellowResources)
                {
                    newblueTower. giveBlueResourc(ref stackBlueResources);
                    if (isSpawn && stackBlueResources !=0)
                    {
                        new_gameObject = Instantiate(SpawnerBlueResources,spawnerPoint.position, Quaternion.identity,spawnerPoint);
                        isSpawn = false;
                    }
                    
                    isStackBlueResources = true;
                }
               
                break;
            case "GreenResourc":
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                if ( stackYellowResources !=0 )
                {
                    inventory.newYellowInventar(stackYellowResources);
                    YellowResourcText.text = inventory.getYellowResourcCount();
                    stackYellowResources = 0;
                    isStackYellowResources = false;
                    if(!isSpawn)
                    {
                        
                        Destroy(new_gameObject);
                        isSpawn = true;
                    }
                }else if (stackBlueResources !=0)
                {
                    inventory.newBlueInventar(stackBlueResources);
                    BlueResourcText.text = inventory.getBlueResourcCount(); 
                    stackBlueResources = 0;
                    isStackBlueResources = false;
                    if(!isSpawn)
                    {
                        
                        Destroy(new_gameObject);
                        isSpawn = true;
                    }
                }
                else if (inventory.BlueResourc !=0 && inventory.YellowResourc !=0)
                {
                    stackGreenResources = inventory.BlueResourc + inventory.YellowResourc; 
                    inventory.getemptyBlueResourcCount(); 
                    inventory.getemptyYellowResourcCount(); 
                    newGreenTower.newGreenResourcProduction(stackGreenResources);
                }

                break;
            case "YellowResourc":
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                if (stackYellowResources ==0 && !isStackBlueResources)
                {

                    newYellowTower.giveYellowResourc(ref stackYellowResources);
                    if (isSpawn && stackYellowResources !=0)
                    {
                        new_gameObject = Instantiate(SpawnerYellowResources,spawnerPoint.position, Quaternion.identity,spawnerPoint);
                        isSpawn = false;
                    }
                    isStackYellowResources = true;
                }

                if (stackBlueResources !=0)
                {
                     YellowBlueResourcText.text = stackBlueResources.ToString();
                    newYellowTower.newYellowResourcProduction(stackBlueResources);
                    if(!isSpawn)
                    {
                        
                        Destroy(new_gameObject);
                        isSpawn = true;
                    }
                    
                    stackBlueResources=0;
                    isStackBlueResources = false;
                }
                break;
            default :
                audioSource.Pause();
                break;
        }
        

    }

  
}
