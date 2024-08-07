using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupShop : MonoBehaviour
{
    public Button btnShop;
    public Button btnShopExit;
    public Button btnUse;
    public Button btnLeft;
    public Button btnRight;
    public GameObject popupShop;
    public Image space;
    private int index;
    private Shop shopDataConfig;
    public Text txtUsing;
    private ShopInfor currentShopInfor;

    private void Awake()
    {
        shopDataConfig = Resources.Load<Shop>("data_csv/Shop");
    }


    void Start()
    {
        btnShopExit.onClick.AddListener(OnClickBtnShopExit);
        btnUse.onClick.AddListener(OnClickBtnUse);
        btnLeft.onClick.AddListener(OnClickBtnLeft);
        btnRight.onClick.AddListener(OnClickBtnRight);

        
        if(DataAccountPlayer.PlayerInfor.shipPlayerUse == 0)
        {
            currentShopInfor = GetShopInfor(1);
            index = 1;
        }
        else
        {
            currentShopInfor = GetShopInfor(DataAccountPlayer.PlayerInfor.shipPlayerUse);
            index = DataAccountPlayer.PlayerInfor.shipPlayerUse;
        }
        space.sprite = Resources.Load<Sprite>($"ship_image/{currentShopInfor.image}");
        
        
    }
    private void Update()
    {
        if (index <= 1)
        {
            btnLeft.gameObject.SetActive(false);
        }
        else
        {
            btnLeft.gameObject.SetActive(true);
        }
        if (index >= shopDataConfig.shopInfors.Length)
        {
            btnRight.gameObject.SetActive(false);
        }
        else
        {
            btnRight.gameObject.SetActive(true);
        }
        if (index == DataAccountPlayer.PlayerInfor.shipPlayerUse)
        {
            txtUsing.text = $"Using";
        }
        else
        {
            txtUsing.text = $"Use";
        }
    }
    
    private void OnClickBtnShopExit()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        popupShop.SetActive(false);
    }
    private void OnClickBtnUse()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        popupShop.SetActive(false);

        DataAccountPlayer.PlayerInfor.ChangeShipPlayer(currentShopInfor.id);
        
    }
    private void OnClickBtnLeft()
    {

        if(index> 0)
        {
            index--;

            currentShopInfor = GetShopInfor(index);
            space.sprite = Resources.Load<Sprite>($"ship_image/{currentShopInfor.image}");
            SoundService.Instance.PlaySound(SoundType.sound_click);
        }
    }
    private void OnClickBtnRight()
    {
        if (index < (shopDataConfig.shopInfors.Length))
        {
            index++;
            currentShopInfor = GetShopInfor(index);
            space.sprite = Resources.Load<Sprite>($"ship_image/{currentShopInfor.image}");
            SoundService.Instance.PlaySound(SoundType.sound_click);
        }
    }

    private ShopInfor GetShopInfor(int index)
    {
        var shopInfors = shopDataConfig.shopInfors;

        foreach (var shop in shopInfors)
        {
            if (shop.id == index)
            {
                return shop;
            }
        }

        return default;
    }
}
