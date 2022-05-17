using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlueTower : ResourcesTower
{
    [SerializeField] protected int blueResourc;
     [SerializeField] protected int _newResources;

     [SerializeField] private Text BlueResourcText;
     [SerializeField] private GameObject SpawnerBlueResources;
     [SerializeField] private Transform spawnerPoint;
     [SerializeField] private Transform _endPoint ;
     private int countBlueResourc;

    bool isDone = false;
    bool  isSpawn = false;

    private Stack<GameObject> _newblueResourceses  = new Stack<GameObject>();

    void Start ()
    {
        BlueResourcText.text = "Нет готового сырья  BlueResourc";
        isDone = true;
        if(isDone)
        {
            Invoke("newblueResourcProduction", 3f);
        }
    }

//ПРАИЗВОТСТВА РЕСУРСА ОТ СЫРЯ
    protected override void ProductionResourc()
    {

      
           if(maxResources !=0 && blueResourc !=1)
           {
                maxResources -= SpeedProduction;
                blueResourc ++;
                countBlueResourc ++;
                BlueResourcText.text = countBlueResourc.ToString();
                Vector3 newSpawnerPosition = (_endPoint == null) ? spawnerPoint.position:_endPoint.Find("EndPoint").position;
                GameObject newBlueResourc = Instantiate(SpawnerBlueResources,newSpawnerPosition, Quaternion.identity,spawnerPoint);
                _endPoint = newBlueResourc.transform;
                _newblueResourceses.Push(newBlueResourc);
               print("newblueResourcProduction Stack" + _newblueResourceses);
                Invoke("newblueResourcProduction", 10f);
            }
            else
            {
                stopProduction();
                isDone = true;
            }
      
        
    }
//ПЕРЕДАЧА ГОТОВОГО РЕСУРСА ИГРАКУ
    public void giveBlueResourc(ref int giveBlueRes)
    {
        if (countBlueResourc >= 1 )
        {
            giveBlueRes ++;
            countBlueResourc -= 1;
            
            Destroy ( _newblueResourceses.Pop());
            if(_newblueResourceses.Count != 0)
            {
                GameObject lastRes = _newblueResourceses.Peek();
                _endPoint = lastRes.transform;
            }
            
            
            
            
            BlueResourcText.text = countBlueResourc.ToString();
        }
        else
        {
            BlueResourcText.text = "Нет готового сырья  BlueResourc";
        }
    }
// ПРАИЗВОДСТВА НОВОГО РЕСУРСА   
    private void newblueResourcProduction()
    {
        for (int i = 0; i <= 10; i++)
        {
            if (isDone && _newResources !=10)
            {
                _newResources++;
            }
            else
            {
                blueResourc =0;
                Invoke("ProductionResourc",10f);
                TakeResourc(_newResources);
                isDone=false;
              
            }
             
        }
       
    }
}
