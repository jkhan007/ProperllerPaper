using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatSkinImg : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI catSkinNameTxt;
    [SerializeField]
    private Image catSkinSpriteImg;
    [SerializeField]
    private GameObject selectedCatSkinLayerGO;
    [SerializeField]
    private TextMeshProUGUI coinsBuyAmountTxt;
    [SerializeField]
    private Button coinsBuyBtn;
    [SerializeField]
    private GameObject coinsBuyInfoContainerGO;
    [SerializeField]
    private TextMeshProUGUI inAppCatSkinBuyAmountTxt;
    [SerializeField]
    private Button inAppCatSkinBuyBtn;
    [SerializeField]
    private GameObject inAppCatSkinBuyInfoContainerGO;

    private int catSkinImgIndex;

    public TextMeshProUGUI CatSkinNameTxt => catSkinNameTxt;
    public Image CatSkinSpriteImg => catSkinSpriteImg;
    public GameObject SelectedCatSkinLayerGO => selectedCatSkinLayerGO;
    public TextMeshProUGUI CoinsBuyAmountTxt => coinsBuyAmountTxt;
    public Button CoinsBuyBtn => coinsBuyBtn;
    public GameObject CoinsBuyInfoContainerGO => coinsBuyInfoContainerGO;
    public TextMeshProUGUI InAppCatSkinBuyAmountTxt => inAppCatSkinBuyAmountTxt;
    public Button InAppCatSkinBuyBtn => inAppCatSkinBuyBtn;
    public GameObject InAppCatSkinBuyInfoContainerGO => inAppCatSkinBuyInfoContainerGO;


    public int CatSkinImgIndex
    {
        get {  return catSkinImgIndex; }
        set
        {
            catSkinImgIndex = value;
        }
    }

}
