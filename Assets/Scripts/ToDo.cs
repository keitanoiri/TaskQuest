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
        inputField.text = PlayerPrefs.GetString(key, "");//������؂�ւ�

        if (CheckBox == true) CheckImage.SetActive(true);
    }

    public void OnEndEdit()
    {
        Debug.Log("Input completed with text: " + inputField.text);
        // �����ɓ��͊������̏�����ǉ�
        PlayerPrefs.SetString(key, inputField.text);
    }

    public void PresedCheckBox()
    {
        //�����𑝂₷
        if (CheckBox == false)
        {
            Debug.Log("You Did It");
            managecs.Money += managecs.getmoney;
            CheckBox = true;
            //bool��ۑ����Ă���
            SaveBool(key, CheckBox);
            CheckImage.SetActive(true);
        }
    }

    public void PresedCheckBoxOne()
    {
        //�����𑝂₷
        if (CheckBox == false)
        {
            Debug.Log("You Did It");
            managecs.Money += managecs.getmoneyToDo;
            CheckBox = true;
            //bool��ۑ����Ă���
            CheckImage.SetActive(true);
            PlayerPrefs.SetString(key, "");//������؂�ւ�
            Invoke("hideCheck", 3f);//�O�b��Ƀ`�F�b�N�}�[�N������
        }
    }

    void hideCheck()
    {
        CheckImage.SetActive(false);
        CheckBox = false;
        inputField.text = "";
    }
}
