using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMenu : MonoBehaviour
{
    public void changeMenu()
    {
        SceneManager.LoadScene("DunyaScene");
    }
    public void changeElementInfo()
    {
        SceneManager.LoadScene("DunyaElementsInfo");
    }
    public void changeToAhiret()
    {
        SceneManager.LoadScene("SiratKoprusu");
    }
    public void changeToAhiretInfo()
    {
        SceneManager.LoadScene("AhiretInfo");
    }

    public void changeToDevam()
    {
        SceneManager.LoadScene("DevamScene");
    }
    public void changeToInfo()
    {
        SceneManager.LoadScene("DunyaInfo");
    }
    public void changeToBeginning()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void changeToBilgi()
    {
        SceneManager.LoadScene("BilgiScene");
    }
}
