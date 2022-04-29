using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class YellowTower : ResourcesTower
{
   
    [SerializeField] protected int YellowResourc;
    [SerializeField] private Text YellowResourcText;
    [SerializeField] private Text BlueResourcText;

    
     

    bool isDone = false;

    void Start ()
    {
        YellowResourcText.text = "Не хвотает сырья BlueResourc для производство YellowResourc";
        BlueResourcText.text = "Не хвотает сырья BlueResourc";
        isDone = true;
        if(isDone)
        {
            Invoke("newYellowResourcProduction", 3f);
            Invoke("ProductionResourc",1f);

        }
    }

//ПРАИЗВОТСТВА РЕСУРСА ОТ сырья
    protected override void ProductionResourc()
    {
        for (int i = 0; i <= 2; i++)
        {
            if(maxResources !=0 && YellowResourc !=5)
            {
                maxResources -= SpeedProduction;
                YellowResourc +=5;
                YellowResourcText.text = YellowResourc.ToString();
                BlueResourcText.text = "Не хвотает сырья BlueResourc";
            }
            else
            {
                stopProduction();
                isDone = true;
            
            }
        }
        
    }
//ПЕРЕДАЧА ГОТОВОГО РЕСУРСА ИГРАКУ
    public void giveYellowResourc(ref int giveYellowRes)
    {
        if (YellowResourc >= 5 )
        {
            
            giveYellowRes +=YellowResourc;
            YellowResourc = 0;
            YellowResourcText.text = "Не хвотает сырья BlueResourc для производство YellowResourc";
            if (isDone)
            {
                Invoke("newYellowResourcProduction", 10f);
                
            }
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
