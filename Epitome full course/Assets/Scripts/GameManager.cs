using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance !=null) //????????? ???? ?? ??? ???? ???? ??????? ?? ????? ? ??????? ???
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // ?????????, ????? GameManager ??? ????? 1
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }
    //Resourses
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public Weapon weapon...
    public FloatingTextManager floatingTextManager;

    //Logic
    public int pesos;
    public int experience;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //SaveState
    /*
        int preferSkin;
        int pesos;
        int experience;
        int weaponLevel;

    */
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("SaveState");
    }
    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))// ???? ???? ?????????? - ?? ????? ???????? ?????????
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change the weapon

        Debug.Log("LoadState");
        
    }
}
