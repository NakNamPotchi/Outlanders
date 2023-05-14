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

    [Header("Books Panel")]
    [SerializeField] private GameObject[] Folktales;
    [SerializeField] private GameObject[] Riddles;
    [SerializeField] private GameObject[] Legends;
    
    [Header("Encyclopedia Panel")]
    [SerializeField] private GameObject[] Humans;
    [SerializeField] private GameObject[] Tores;
    [SerializeField] private GameObject[] Mooltos;

    private int [] FolktalesReadAlready = new int[12];
    private int [] RiddlesReadAlready = new int[14];
    private int [] LegendsReadAlready = new int[10];
    private int [] HumansReadAlready = new int[3];
    private int [] ToresReadAlready = new int[5];
    private int [] MooltosReadAlready = new int[6];

    private int[] FolktalesBook = new int[12];
    private int[] RiddlesBook = new int[14];
    private int[] LegendsBook = new int[10];
    private int[] HumansBook = new int[3];
    private int[] ToresBook = new int[5];
    private int[] MooltosBook = new int[6];
    
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

        for (int i = 0; i <= 11; i++)
        {
            FolktalesBook[i] = PlayerPrefs.GetInt("Folktales" + i);
            FolktalesReadAlready[i] = PlayerPrefs.GetInt("FolktalesReadAlready" + i);
            if (FolktalesBook[i] != 0 && FolktalesReadAlready[i] == 0)
            {
                Folktales[i].SetActive(true);
            }
        }

        for (int i = 0; i <= 13; i++)
        {
            RiddlesBook[i] = PlayerPrefs.GetInt("Riddles" + i);
            RiddlesReadAlready[i] = PlayerPrefs.GetInt("RiddlesReadAlready" + i);
            if (RiddlesBook[i] != 0 && RiddlesReadAlready[i] == 0)
            {
                Riddles[i].SetActive(true);
            }
        }

        for (int i = 0; i <= 9; i++)
        {
            LegendsBook[i] = PlayerPrefs.GetInt("Legends" + i);
            LegendsReadAlready[i] = PlayerPrefs.GetInt("LegendsReadAlready" + i);
            if (LegendsBook[i] != 0 && LegendsReadAlready[i] == 0)
            {
                Legends[i].SetActive(true);
            }
        }

        for (int i = 0; i <= 2; i++)
        {
            HumansBook[i] = PlayerPrefs.GetInt("Humans" + i);
            HumansReadAlready[i] = PlayerPrefs.GetInt("HumansReadAlready" + i);
            if (HumansBook[i] != 0 && HumansReadAlready[i] == 0)
            {
                Humans[i].SetActive(true);
            }
        }

        for (int i = 0; i <= 4; i++)
        {
            ToresBook[i] = PlayerPrefs.GetInt("Tores" + i);
            ToresReadAlready[i] = PlayerPrefs.GetInt("ToresReadAlready" + i);
            if (ToresBook[i] != 0 && ToresReadAlready[i] == 0)
            {
                Tores[i].SetActive(true);
            }
        }

        for (int i = 0; i <= 5; i++)
        {
            MooltosBook[i] = PlayerPrefs.GetInt("Mooltos" + i);
            MooltosReadAlready[i] = PlayerPrefs.GetInt("MooltosReadAlready" + i);
            if (MooltosBook[i] != 0 && MooltosReadAlready[i] == 0)
            {
                Mooltos[i].SetActive(true);
            }
        }
    }

    public void RemoveFolktalesBookNotification(int bookNum)
    {
        Folktales[bookNum].SetActive(false);
        PlayerPrefs.SetInt("Folktales" + bookNum, 0);
        PlayerPrefs.SetInt("FolktalesReadAlready" + bookNum, 1);
    }

    public void RemoveRiddlesBookNotification(int bookNum)
    {
        Riddles[bookNum].SetActive(false);
        PlayerPrefs.SetInt("Riddles" + bookNum, 0);
        PlayerPrefs.SetInt("RiddlesReadAlready" + bookNum, 1);
    }

    public void RemoveLegendsBookNotification(int bookNum)
    {
        Legends[bookNum].SetActive(false);
        PlayerPrefs.SetInt("Legends" + bookNum, 0);
        PlayerPrefs.SetInt("LegendsReadAlready" + bookNum, 1);
    }

    public void RemoveHumansBookNotification(int bookNum)
    {
        Humans[bookNum].SetActive(false);
        PlayerPrefs.SetInt("Humans" + bookNum, 0);
        PlayerPrefs.SetInt("HumansReadAlready" + bookNum, 1);
    }

    public void RemoveToresBookNotification(int bookNum)
    {
        Tores[bookNum].SetActive(false);
        PlayerPrefs.SetInt("Tores" + bookNum, 0);
        PlayerPrefs.SetInt("ToresReadAlready" + bookNum, 1);
    }

    public void RemoveMooltosBookNotification(int bookNum)
    {
        Mooltos[bookNum].SetActive(false);
        PlayerPrefs.SetInt("Mooltos" + bookNum, 0);
        PlayerPrefs.SetInt("MooltosReadAlready" + bookNum, 1);
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
        bool remainingUnread = false;
        for (int bookNum = 0; bookNum < 3; bookNum++)
        {
            HumansBook[bookNum] = PlayerPrefs.GetInt("Humans" + bookNum);
            if (HumansBook[bookNum] == 1)
            {
                remainingUnread = true;
            }
        }

        if (remainingUnread == false)
        {
            HumanNotification.SetActive(false);
            PlayerPrefs.SetInt("HumanNewReward", 0);
        }
    }

    public void RemoveToresNotification()
    {
        bool remainingUnread = false;
        for (int bookNum = 0; bookNum < 3; bookNum++)
        {
            ToresBook[bookNum] = PlayerPrefs.GetInt("Tores" + bookNum);
            if (ToresBook[bookNum] == 1)
            {
                remainingUnread = true;
            }
        }

        if (remainingUnread == false)
        {
            ToresNotification.SetActive(false);
            PlayerPrefs.SetInt("ToresNewReward", 0);
        }
    }

    public void RemoveMooltosNotification()
    {
        bool remainingUnread = false;
        for (int bookNum = 0; bookNum < 3; bookNum++)
        {
            MooltosBook[bookNum] = PlayerPrefs.GetInt("Mooltos" + bookNum);
            if (MooltosBook[bookNum] == 1)
            {
                remainingUnread = true;
            }
        }

        if (remainingUnread == false)
        {
            MooltosNotification.SetActive(false);
            PlayerPrefs.SetInt("MooltosNewReward", 0);
        }
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
        bool remainingUnread = false;
        for (int bookNum = 0; bookNum < 3; bookNum++)
        {
            FolktalesBook[bookNum] = PlayerPrefs.GetInt("Folktales" + bookNum);
            if (FolktalesBook[bookNum] == 1)
            {
                remainingUnread = true;
            }
        }

        if (remainingUnread == false)
        {
            FolktalesNotification.SetActive(false);
            PlayerPrefs.SetInt("FolktaleNewReward", 0);
        }
    }

    public void RemoveRiddlesNotification()
    {
        bool remainingUnread = false;
        for (int bookNum = 0; bookNum < 3; bookNum++)
        {
            RiddlesBook[bookNum] = PlayerPrefs.GetInt("Riddles" + bookNum);
            if (RiddlesBook[bookNum] == 1)
            {
                remainingUnread = true;
            }
        }

        if (remainingUnread == false)
        {
            RiddlesNotification.SetActive(false);
            PlayerPrefs.SetInt("RiddleNewReward", 0);
        }
    }

    public void RemoveLegendsNotification()
    {
        bool remainingUnread = false;
        for (int bookNum = 0; bookNum < 3; bookNum++)
        {
            LegendsBook[bookNum] = PlayerPrefs.GetInt("Legends" + bookNum);
            if (LegendsBook[bookNum] == 1)
            {
                remainingUnread = true;
            }
        }

        if (remainingUnread == false)
        {
            LegendsNotification.SetActive(false);
            PlayerPrefs.SetInt("LegendNewReward", 0);
        }
    }
}
