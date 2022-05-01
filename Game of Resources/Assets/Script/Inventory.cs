using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Inventory 
{
   public int BlueResourc{get;set;}
   public int YellowResourc{get;set;}
    
     
    public void newBlueInventar ( int resourc)
    {
        BlueResourc = resourc;
        resourc =0;
        
    }
    public void newYellowInventar ( int resourc)
    {
        YellowResourc = resourc;
        resourc =0;
        
    }
    public string getBlueResourcCount()
    {
        return BlueResourc.ToString();
    }

    public string getemptyBlueResourcCount()
    {
        BlueResourc = 0;
        return BlueResourc.ToString();
    }

    public string getYellowResourcCount()
    {
        return YellowResourc.ToString();
    }

    public string getemptyYellowResourcCount()
    {
        YellowResourc = 0;
        return YellowResourc.ToString();
    }
}
