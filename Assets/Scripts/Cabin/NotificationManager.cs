using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    [Header("Panel")] 
    [SerializeField] private GameObject EncycopediaNotification;
    [SerializeField] private GameObject HumanNotification;
    [SerializeField] private GameObject ToresNotification;
    [SerializeField] private GameObject MooltosNotification;
    [SerializeField] private GameObject BookshelfNotification;
    [SerializeField] private GameObject FolktalesNotification;
    [SerializeField] private GameObject RiddlesNotification;
    [SerializeField] private GameObject LegendsNotification;
    
    public void Start()
    {
        int FolktaleNewReward = PlayerPrefs.GetInt("FolktaleNewReward");
        int RiddleNewReward = PlayerPrefs.GetInt("RiddleNewReward");
        int LegendNewReward = PlayerPrefs.GetInt("LegendNewReward");
        int HumanNewReward = PlayerPrefs.GetInt("HumanNewReward");
        int ToresNewReward = PlayerPrefs.GetInt("ToresNewReward");
        int MooltosNewReward = PlayerPrefs.GetInt("MooltosNewReward");
        int EncyclopediaNewReward = PlayerPrefs.GetInt("EncyclopediaNewReward");
        int BookshelfNewReward = PlayerPrefs.GetInt("BookshelfNewReward");

        if (FolktaleNewReward == 1)
            FolktalesNotification.SetActive(true);
        if (RiddleNewReward == 1)
            RiddlesNotification.SetActive(true);
        if (LegendNewReward == 1)
            LegendsNotification.SetActive(true);
        if (BookshelfNewReward == 1)
            BookshelfNotification.SetActive(true);
        if (HumanNewReward == 1)
            HumanNotification.SetActive(true);
        if (ToresNewReward == 1)
            ToresNotification.SetActive(true);
        if (MooltosNewReward == 1)
            MooltosNotification.SetActive(true);
        if (EncyclopediaNewReward == 1)
            EncycopediaNotification.SetActive(true);
    }

    public void RemoveEncyclopediaNotification()
    {
        int HumanNewReward = PlayerPrefs.GetInt("HumanNewReward");
        int ToresNewReward = PlayerPrefs.GetInt("ToresNewReward");
        int MooltosNewReward = PlayerPrefs.GetInt("MooltosNewReward");

        if (HumanNewReward != 1 && ToresNewReward != 1 && MooltosNewReward != 1)
        {
            EncycopediaNotification.SetActive(false);
            PlayerPrefs.SetInt("EncyclopediaNewReward", 0);
        }
    }

    public void RemoveHumanNotification()
    {
        HumanNotification.SetActive(false);
        PlayerPrefs.SetInt("HumanNewReward", 0);
    }

    public void RemoveToresNotification()
    {
        ToresNotification.SetActive(false);
        PlayerPrefs.SetInt("ToresNewReward", 0);
    }

    public void RemoveMooltosNotification()
    {
        MooltosNotification.SetActive(false);
        PlayerPrefs.SetInt("MooltosNewReward", 0);
    }

    public void RemoveBookshelfNotification()
    {   
        int FolktaleNewReward = PlayerPrefs.GetInt("FolktaleNewReward");
        int RiddleNewReward = PlayerPrefs.GetInt("RiddleNewReward");
        int LegendNewReward = PlayerPrefs.GetInt("LegendNewReward");

        if (FolktaleNewReward != 1 && RiddleNewReward != 1 && LegendNewReward != 1)
        {
            BookshelfNotification.SetActive(false);
            PlayerPrefs.SetInt("BookshelfNewReward", 0);
        }
    }

    public void RemoveFolktalesNotification()
    {
        FolktalesNotification.SetActive(false);
        PlayerPrefs.SetInt("FolktaleNewReward", 0);
    }

    public void RemoveRiddlesNotification()
    {
        RiddlesNotification.SetActive(false);
        PlayerPrefs.SetInt("RiddleNewReward", 0);
    }

    public void RemoveLegendsNotification()
    {
        LegendsNotification.SetActive(false);
        PlayerPrefs.SetInt("LegendNewReward", 0);
    }
}
