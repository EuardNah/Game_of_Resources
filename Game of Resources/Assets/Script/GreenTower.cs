using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GreenTower : ResourcesTower
{
    

    [SerializeField] protected int GreenResourc;
    
    [SerializeField] protected int _newGreenResourc;
    [SerializeField] private Text ScoreText;
     [SerializeField] private Text YellowResourcText;
    [SerializeField] private Text BlueResourcText;

    private AudioSource audioSource;
     

    bool isDone = false;

    void Start ()
    {   

        audioSource = GetComponent<AudioSource>();
        YellowResourcText.text = "Не хвотает сырья YellowResourc";
        BlueResourcText.text = "Не хвотает сырья BlueResourc";
        ScoreText.text =  _newGreenResourc.ToString();
        
        isDone = true;
    }

//ПРАИЗВОТСТВА РЕСУРСА ОТ СЫРЯ
    protected override void ProductionResourc()
    {
       
            if(GreenResourc != 0)
            {

               
                giveGreenResourc( GreenResourc);
                GreenResourc=0;

            }
            else
            {
                stopProduction();
                 isDone = true;
            
            }
        
        
    }
//ПЕРЕДАЧА ГОТОВОГО РЕСУРСА ИГРАКУ
    public void giveGreenResourc( int giveGreenResScore)
    {
        if (giveGreenResScore!=0)
        {
            _newGreenResourc += giveGreenResScore;
            ScoreText.text = _newGreenResourc.ToString();
            YellowResourcText.text = "Не хвотает сырья YellowResourc";
            BlueResourcText.text = "Не хвотает сырья BlueResourc";
            giveGreenResScore = 0;
            if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }else
                {
                    audioSource.Pause();
                }
            isDone = true;
            if (isDone)
            {
                Invoke("newGreenResourcProduction", 10f);
                
            }
        }
    }
// ПРАИЗВОДСТВА НОВОГО РЕСУРСА   
    public void newGreenResourcProduction(int _newResources)
    {
        
            if (isDone)
            {
                Invoke("ProductionResourc",10f);
                GreenResourc += _newResources;

                isDone=false;
                
                _newResources = 0;
            }
            
             
    }
}
