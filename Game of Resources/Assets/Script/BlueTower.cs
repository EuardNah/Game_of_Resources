using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlueTower : ResourcesTower
{
    [SerializeField] protected int blueResourc;
     [SerializeField] protected int _newResources;

     [SerializeField] private Text BlueResourcText;

    bool isDone = false;

    void Start ()
    {
        BlueResourcText.text = "Нет готового сырья  BlueResourc";

        isDone = true;
        if(isDone)
        {
            Invoke("newblueResourcProduction", 3f);
            Invoke("ProductionResourc",1f);

        }
    }

//ПРАИЗВОТСТВА РЕСУРСА ОТ СЫРЯ
    protected override void ProductionResourc()
    {
        for (int i = 0; i <= 2; i++)
        {
            if(maxResources !=0 && blueResourc !=5)
            {
                maxResources -= SpeedProduction;
                blueResourc +=5;
                BlueResourcText.text = blueResourc.ToString();
            }
            else
            {
                stopProduction();
                isDone = true;
            
            }
        }
        
    }
//ПЕРЕДАЧА ГОТОВОГО РЕСУРСА ИГРАКУ
    public void giveBlueResourc(ref int giveBlueRes)
    {
        if (blueResourc >= 5 )
        {
            
            giveBlueRes +=blueResourc;
            blueResourc = 0;
            BlueResourcText.text = "Нет готового сырья  BlueResourc";
            if (isDone)
            {
                Invoke("newblueResourcProduction", 10f);
                
            }
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
            }else
            {
                Invoke("ProductionResourc",10f);
                TakeResourc(_newResources);
                isDone=false;
            }
             
        }
       
    }
}
