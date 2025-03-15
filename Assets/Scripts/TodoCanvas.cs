using System;
using UnityEngine;

public class TodoCanvas : MonoBehaviour
{
    private DateTime lastCheckDate;
    [SerializeField] GameObject ToDo;
    [SerializeField] GameObject Dayry;
    private void Start()
    {
        ToDo.SetActive(true);
        Dayry.SetActive(false);
        lastCheckDate = DateTime.Today;
        //�Â����t�ƈ�v���Ȃ���΃`�F�b�N�{�b�N�X��Key�����Z�b�g
        if (DateTime.Today.ToString() != PlayerPrefs.GetString("OldDay", "none"))
        {
            PlayerPrefs.DeleteKey("Key0");
            PlayerPrefs.DeleteKey("Key1");
            PlayerPrefs.DeleteKey("Key2");
            PlayerPrefs.DeleteKey("Key3");
            PlayerPrefs.DeleteKey("Key4");
        }
        //�Â����t
        PlayerPrefs.SetString("OldDay", lastCheckDate.ToString());

    }
    public void SerectToDoTab()
    {
        ToDo.SetActive(true);
        Dayry.SetActive(false);
    }
    public void SerectDayryTab()
    {
        ToDo.SetActive(false);
        Dayry.SetActive(true);
    }

}
