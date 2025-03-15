using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardSmallImage : ExtendPrefs, IPointerClickHandler
{
    public GameObject imagePrefab;
    [SerializeField]public Image motogazou;
    [SerializeField] public Sprite reward;
    [SerializeField] public Sprite hatena;
    [SerializeField] GameObject tmp;
    //private int bunkatu = 4;

    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
        isActive = GetBool(reward.name,false);
        Debug.Log(reward.name);
        Destroy(tmp);//iranai
        /*
        TextMeshProUGUI tmpC = tmp.GetComponent<TextMeshProUGUI>();

        int count=0;
        for(int i = 1; i <= bunkatu; i++)
        {
            if (RewardsData[i] == 1) { count++; }
        }
        string chengetext = string.Format("{0}/{1}",count,bunkatu);
        tmpC.text = chengetext;
        if (count == bunkatu)
        {
            Destroy(tmp);
            isActive = true;
        }
        */
        if ((isActive) == false) motogazou.sprite = hatena;
    }

    // Update is called once per frame

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive == true) {
            // 画面の中央に画像を表示するための位置を計算する
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Vector3 worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);

            // 画像を生成して画面の中央に配置する
            GameObject newImage = Instantiate(imagePrefab, worldCenter, Quaternion.identity);
            // 生成した画像をCanvasの子要素にする
            newImage.transform.SetParent(GameObject.Find("RewardCanvas_Page1").transform, false);
        }
        else{
            Debug.Log("tarinai");
        }
    }
}
