using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DN : MonoBehaviour
{

    public GameObject LoginPanel;

    public GameObject GamePanel;

    public Button LoginBtn;

    public Button BegainBtn;

    public GameObject Xiazhu;

    public Button Xz100Btn;
    public Button Xz1000Btn;
    public Button Xz5000Btn;
    public Button Xz10000Btn;

    private int XiaZhuNum;

    public GameObject XiaZhuGe;

    public Text XiaZhuNumText;

    public Sprite[] Heads;

    public Image[] PlayerHeads;

    public int zhuangNum = 99999999;
    public Text zhuangNumText;
    public int myNum = 8888888;
    public Text myNumText;


    public Sprite[] heitao;
    public Sprite[] hongtao;
    public Sprite[] meihua;
    public Sprite[] fangkuai;


    public Image[] kpzhuang;
    public Image[] kpxian;


    public Sprite paiBG;

    public Button Exit;

    public GameObject Tips;

    public Text TipsText;

    public float TipsTime = 1.0f;

    private float tipsTimeCount = 0;
    // Use this for initialization
    void Start()
    {
        LoginBtn.onClick.AddListener(LoginBtnOnClick);
        BegainBtn.onClick.AddListener(BegainBtnOnClick);
        Xz100Btn.onClick.AddListener(Xz100BtnOnClick);
        Xz1000Btn.onClick.AddListener(Xz1000BtnOnClick);
        Xz5000Btn.onClick.AddListener(Xz5000BtnOnClick);
        Xz10000Btn.onClick.AddListener(Xz10000BtnOnClick);
        Exit.onClick.AddListener(ExitBtnOnClick);

        InitHeads();

        RefreshPai();
        RefreshGoldText();
    }

    private void RefreshTips(string content)
    {
        TipsText.text = content;
        Tips.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Tips.activeSelf)
        {
            tipsTimeCount = tipsTimeCount + Time.deltaTime;
            if (tipsTimeCount >= 1)
            {
                tipsTimeCount = 0;
                Tips.SetActive(false);
            }
        }
    }

    private void ExitBtnOnClick()
    {
        Application.Quit();
    }

    private void InitHeads()
    {
        for (int i = 0; i < PlayerHeads.Length; i++)
        {
            PlayerHeads[i].sprite = Heads[Random.Range(0, Heads.Length - 1)];
        }
    }

    private void LoginBtnOnClick()
    {
        LoginPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    int[] paiIndex;
    private void BegainBtnOnClick()
    {
        if (XiaZhuNum == 0)
        {
            Debug.LogError("请先下注");
            RefreshTips("请先下注");
            return;
        }
        // BegainBtn.gameObject.SetActive(false);
        paiIndex = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        int zhuang;
        int xian;
        while (true)
        {
            int temp = Random.Range(0, 51);

            for (int i = 0; i < paiIndex.Length; i++)
            {
                if (paiIndex[i] == -1)
                {
                    paiIndex[i] = temp;
                    break;
                }
                else
                {
                    if (paiIndex[i] == temp)
                    {
                        break;
                    }
                }
            }
            if (paiIndex[paiIndex.Length - 1] != -1)
            {
                break;
            }
        }
        int[] xianpai = new int[5];
        for (int i = 0; i < kpxian.Length; i++)
        {
            int bigIndex = paiIndex[i] / 13;
            int smallIndex = paiIndex[i] % 13;
            switch (bigIndex)
            {
                case 0:
                    kpxian[i].sprite = heitao[smallIndex];
                    break;
                case 1:
                    kpxian[i].sprite = hongtao[smallIndex];
                    break;
                case 2:
                    kpxian[i].sprite = meihua[smallIndex];
                    break;
                case 3:
                    kpxian[i].sprite = fangkuai[smallIndex];
                    break;
            }
            if (smallIndex == 0)
            {
                // smallIndex = 13;
            }
            xianpai[i] = smallIndex + 1;
        }

        Debug.LogError("闲牛：" + getCow(xianpai));
        BubbleSort(xianpai);
        xian = getCow(xianpai);

        int[] zhuangpai = new int[5];
        for (int i = 0; i < kpzhuang.Length; i++)
        {
            int bigIndex = paiIndex[i + 5] / 13;
            int smallIndex = paiIndex[i + 5] % 13;
            switch (bigIndex)
            {
                case 0:
                    kpzhuang[i].sprite = heitao[smallIndex];
                    break;
                case 1:
                    kpzhuang[i].sprite = hongtao[smallIndex];
                    break;
                case 2:
                    kpzhuang[i].sprite = meihua[smallIndex];
                    break;
                case 3:
                    kpzhuang[i].sprite = fangkuai[smallIndex];
                    break;
            }
            if (smallIndex == 0)
            {
                //  smallIndex = 13;
            }
            zhuangpai[i] = smallIndex + 1;

            // zhuangpai = new int[] { 9, 8, 7, 1 ,1 };

        }
        Debug.LogError("装牛：" + getCow(zhuangpai));
        BubbleSort(zhuangpai);
        zhuang = getCow(zhuangpai);
        if (zhuang == 0)
        {
            zhuang = 10;
        }

        if (xian == 0)
        {
            xian = 10;
        }
        if (zhuang > xian)
        {
            Debug.LogError("装ying");
            RefreshTips("庄赢");
            myNum = myNum - XiaZhuNum;
            zhuangNum = zhuangNum + XiaZhuNum;
            RefreshGoldText();
        }
        else if (zhuang < xian)
        {
            Debug.LogError("xian ying");
            RefreshTips("闲赢");
            myNum = myNum +XiaZhuNum;
            zhuangNum = zhuangNum - XiaZhuNum;
            RefreshGoldText();
        }
        else
        {
            for (int i = 0; i < zhuangpai.Length; i++)
            {
                if (zhuangpai[i] > xianpai[i])
                {
                    Debug.LogError("装ying");
                    RefreshTips("庄赢");
                    myNum = myNum - XiaZhuNum;
                    zhuangNum = zhuangNum + XiaZhuNum;
                    RefreshGoldText();
                    break;
                }
                else if (zhuangpai[i] < xianpai[i])
                {
                    RefreshTips("闲赢");
                    myNum = myNum + XiaZhuNum;
                    zhuangNum = zhuangNum - XiaZhuNum;
                    RefreshGoldText();
                    break;
                }

            }
        }

        XiaZhuNum = 0;
        RefreshXiaZhuText();
        
    }

    private void Xz100BtnOnClick()
    {
        if (myNum < XiaZhuNum + 100)
        {
            Debug.LogError("金币不够");
            RefreshTips("金币不够");
            return;
        }
        RefreshPai();
        XiaZhuNum = XiaZhuNum + 100;
        RefreshXiaZhuText();
    }
    private void Xz1000BtnOnClick()
    {
        if (myNum < XiaZhuNum + 1000)
        {
            Debug.LogError("金币不够");
            RefreshTips("金币不够");
            return;
        }
        RefreshPai();
        XiaZhuNum = XiaZhuNum + 1000;
        RefreshXiaZhuText();
    }
    private void Xz5000BtnOnClick()
    {
        if (myNum < XiaZhuNum + 5000)
        {
            Debug.LogError("金币不够");
            RefreshTips("金币不够");
            return;
        }
        RefreshPai();
        XiaZhuNum = XiaZhuNum + 5000;
        RefreshXiaZhuText();
    }
    private void Xz10000BtnOnClick()
    {
        if (myNum < XiaZhuNum + 10000)
        {
            Debug.LogError("金币不够");
            RefreshTips("金币不够");
            return;
        }
        RefreshPai();
        XiaZhuNum = XiaZhuNum + 10000;
        RefreshXiaZhuText();
    }

    private void RefreshXiaZhuText()
    {
        XiaZhuNumText.text = XiaZhuNum.ToString();
        myNumText.text = myNum - XiaZhuNum + "";
    }

    private void RefreshGoldText()
    {
        myNumText.text = myNum+ "";
        zhuangNumText.text = zhuangNum + "";
    }

    private void  RefreshPai()
    {
        for (int i = 0; i < 5; i++)
        {
            kpxian[i].sprite = paiBG;
            kpzhuang[i].sprite = paiBG;
        }
    }

    private void Kaipai()
    {

    }


    //冒泡排序
    public void BubbleSort(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = data.Length - 1; j > i; j--)
            {
                if (data[j] > data[j - 1])
                {
                    data[j] = data[j] + data[j - 1];
                    data[j - 1] = data[j] - data[j - 1];
                    data[j] = data[j] - data[j - 1];
                }
            }
        }
    }



    private int temp, n, cardsTotal;//n表示jqk 10的个数，cow表示牛，cardsTotal表示牌总和
    private int cow = -1;//默认没有牛
    string content;
    private int getCow(int[] card)
    {
       // BubbleSort(card);
        n = 0;
        cardsTotal = 0;
        content = "";
        cow = -1;
        for (int i = 0; i < card.Length; i++)
        {

            if (card[i] >= 10)
            {
                cardsTotal += 10;
                n++;
            }
            else
            {
                cardsTotal += card[i];
            }

            content = content + " " + card[i];
        }
        //根据jqk10个数分情况讨论
        switch (n)
        {
            case 0://一张都没用
                for (int i = 0; i < 5; i++)
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        for (int m = j + 1; m < 5; m++)
                        {
                            if ((card[i] + card[j] + card[m]) % 10 == 0)
                            {
                                Debug.LogError("i = " + i + ",j = " + j + ",m = " + m);
                                cow = cardsTotal % 10;
                                return cow;
                            }
                        }
                    }
                }
                return cow;
            case 1://有一张jqk10的情况
                for (int i = 1; i < 5; i++)
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        for (int m = j + 1; m < 5; m++)
                        {
                            if ((card[i] + card[j] + card[m]) % 10 == 0)
                            {
                                cow = cardsTotal % 10;
                                return cow;
                            }
                        }
                    }
                }

                for (int i = 1; i < 5; i++)
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        if ((card[i] + card[j]) % 10 == 0)
                        {
                            cow = cardsTotal % 10;
                            return cow;
                        }
                    }
                }
                return cow;

            case 2://有2张jqk10的情况,剩余3张中有2张之和等于10或者剩余3张之和为10
                for (int i = 3; i < 5; i++)
                {
                    if ((card[2] + card[i]) % 10 == 0)
                    {
                        cow = cardsTotal % 10;
                        return cow;
                    }

                }

                if ((card[2] + card[3] + card[4]) % 10 == 0)
                {
                    cow = cardsTotal % 10;
                    return cow;
                }

                if ((card[3] + card[4]) % 10 == 0)
                {
                    cow = cardsTotal % 10;
                    return cow;
                }
                return cow;
            default://有3,4,5张jqk10的情况
                cow = cardsTotal % 10;
                return cow;
        }
    }

}
