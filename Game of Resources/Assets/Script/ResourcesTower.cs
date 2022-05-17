using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ResourcesTower : MonoBehaviour
{
    [SerializeField] protected int maxResources;
    
    [SerializeField] protected int SpeedProduction = 5;

    bool isResources = false;

//ПЕРЕВОЗКА НОВОГО СЫРЯ В СКЛАД СЫРЯ
    public void TakeResourc(int resourc)
    {
        if(maxResources == 0 && isResources == false)
        {
            maxResources += resourc;
            if (maxResources ==10)
            {
                isResources = true;
            }
        }
    }

//ОСТАНОВКА ПРАИЗВОДСТВА ИЗ ЗА НЕ ХВАТКЫ СЫРЯ
    public void stopProduction()
    {
        isResources = false;
        print("stopProduction()  ");
    }
 
    protected abstract void ProductionResourc();

    
}
