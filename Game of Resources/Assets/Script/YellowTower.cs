using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class YellowTower : ResourcesTower
{
   
    [SerializeField] protected int YellowResourc;
    [SerializeField] private Text YellowResourcText;
    [SerializeField] private Text BlueResourcText;
    [SerializeField] private Transform spawnerPoint;
     [SerializeField] private Transform _endPoint ;
     
    
    [SerializeField] private GameObject SpawnerYellowResources;
     private Stack<GameObject> _newYellowResourceses  = new Stack<GameObject>();

    bool isDone = false;

    void Start ()
    {
        YellowResourcText.text = "Не хвотает сырья BlueResourc для производство YellowResourc";
        BlueResourcText.text = "Не хвотает сырья BlueResourc";
        isDone = true;
        
    }

//ПРАИЗВОТСТВА РЕСУРСА ОТ сырья
    protected override void ProductionResourc()
    {
            if( YellowResourc <=5)
            {
                maxResources -= SpeedProduction;
                YellowResourc ++;
                YellowResourcText.text = YellowResourc.ToString();
                BlueResourcText.text = "Не хвотает сырья BlueResourc";
                Vector3 newSpawnerPosition = (_endPoint == null) ? spawnerPoint.position:_endPoint.Find("_EndPoint").position;
                GameObject newYellowResourc = Instantiate(SpawnerYellowResources,newSpawnerPosition, Quaternion.identity,spawnerPoint);
                _endPoint = newYellowResourc.transform;
                _newYellowResourceses.Push(newYellowResourc);
                isDone = true;
            }
            else
            {
                stopProduction();
                
            
            }
      
        
    }
//ПЕРЕДАЧА ГОТОВОГО РЕСУРСА ИГРАКУ
    public void giveYellowResourc(ref int giveYellowRes)
    {
        if (giveYellowRes <=1 )
        {
            giveYellowRes ++;
            YellowResourc -= 1;
            if (YellowResourc!=0)
            {
                YellowResourcText.text = YellowResourc.ToString();
            }
            else
            {
                YellowResourcText.text = "Не хвотает сырья BlueResourc для производство YellowResourc";
            }
             Destroy ( _newYellowResourceses.Pop());
             if(_newYellowResourceses.Count != 0)
            {
                GameObject lastRes = _newYellowResourceses.Peek();
                _endPoint = lastRes.transform;
            }
            isDone = true;
            
        }
    }
// ПРАИЗВОДСТВА НОВОГО РЕСУРСА   
    public void newYellowResourcProduction(int _newResources)
    {
            if (isDone)
            {
                Invoke("ProductionResourc",10f);
                TakeResourc(_newResources);
                isDone=false;
                
            }
    }
}
