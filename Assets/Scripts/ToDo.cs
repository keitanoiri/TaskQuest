using System;
using UnityEngine;
using TMPro;

public class ToDo : ExtendPrefs
{
    private DateTime lastCheckDate;
    private GameManager managecs;
    public bool CheckBox;
    [SerializeField] int ToDoNum;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject CheckImage;
    string key;
    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        managecs = manager.GetComponent<GameManager>();
        key = string.Format("Key{0}", ToDoNum);
        CheckBox = GetBool(key, false);
        inputField.text = PlayerPrefs.GetString(key, "");//文字を切り替え

        if (CheckBox == true) CheckImage.SetActive(true);
    }

    public void OnEndEdit()
    {
        Debug.Log("Input completed with text: " + inputField.text);
        // ここに入力完了時の処理を追加
        PlayerPrefs.SetString(key, inputField.text);
    }

    public void PresedCheckBox()
    {
        //お金を増やす
        if (CheckBox == false)
        {
            Debug.Log("You Did It");
            managecs.Money += managecs.getmoney;
            CheckBox = true;
            //boolを保存しておく
            SaveBool(key, CheckBox);
            CheckImage.SetActive(true);
        }
    }

    public void PresedCheckBoxOne()
    {
        //お金を増やす
        if (CheckBox == false)
        {
            Debug.Log("You Did It");
            managecs.Money += managecs.getmoneyToDo;
            CheckBox = true;
            //boolを保存しておく
            CheckImage.SetActive(true);
            PlayerPrefs.SetString(key, "");//文字を切り替え
            Invoke("hideCheck", 3f);//三秒後にチェックマークを消す
        }
    }

    void hideCheck()
    {
        CheckImage.SetActive(false);
        CheckBox = false;
        inputField.text = "";
    }
}
