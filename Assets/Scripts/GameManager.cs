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
        // ここに追加の処理を記述します。例えば：アチーブメントのチェック、UIの更新、イベントのトリガーなど
        PlayerPrefs.SetInt("Money", newMoney); // 整数値を保存
        UpdateMoneyUI(newMoney.ToString());
    }
    private void UpdateMoneyUI(string newText)
    {
        // UIを更新する処理をここに書く
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
        //メインのシーンを読み込む
        SceneManager.LoadScene("ToDoScene");
    } 
    public void bottan2()
    {
        Debug.Log("Pressed butten2");
        //リワードのシーンを読み込む
        SceneManager.LoadScene("RewardScene");
    }
    public void bottan3()
    {
        Debug.Log("Pressed butten3");
        //店のシーンを読み込む
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
