using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    private int _money;
    public int getmoney;
    public int getmoneyToDo;
    TextMeshProUGUI moneytext;
    [SerializeField]public int contents_number;
    [SerializeField] GameObject moneyobj;


    public int Money
    {
        get { return _money; }
        set
        {
            _money = value;
            OnMoneyChanged(_money);
            
        }
    }

    private void OnMoneyChanged(int newMoney)
    {
        // �����ɒǉ��̏������L�q���܂��B�Ⴆ�΁F�A�`�[�u�����g�̃`�F�b�N�AUI�̍X�V�A�C�x���g�̃g���K�[�Ȃ�
        PlayerPrefs.SetInt("Money", newMoney); // �����l��ۑ�
        UpdateMoneyUI(newMoney.ToString());
    }
    private void UpdateMoneyUI(string newText)
    {
        // UI���X�V���鏈���������ɏ���
        moneytext.text = newText;
    }

    private void Start()
    {
        moneytext = moneyobj.GetComponent<TextMeshProUGUI>();
        Money = PlayerPrefs.GetInt("Money", 0);
    }

    public void bottan1()
    {
        Debug.Log("Presed butten1");
        //���C���̃V�[����ǂݍ���
        SceneManager.LoadScene("ToDoScene");
    } 
    public void bottan2()
    {
        Debug.Log("Pressed butten2");
        //�����[�h�̃V�[����ǂݍ���
        SceneManager.LoadScene("RewardScene");
    }
    public void bottan3()
    {
        Debug.Log("Pressed butten3");
        //�X�̃V�[����ǂݍ���
        SceneManager.LoadScene("ShopScene");
    }

    public static bool[] ConvertToBinaryBoolArray(int number)
    {
        bool[] binaryArray = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            binaryArray[3 - i] = (number & (1 << i)) != 0;
        }
        return binaryArray;
    }

}
