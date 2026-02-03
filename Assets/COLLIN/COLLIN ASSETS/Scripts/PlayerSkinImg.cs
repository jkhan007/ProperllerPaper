using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSkinImg : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerSkinNameTxt;
    [SerializeField]
    private Image playerSkinSpriteImg;
    [SerializeField]
    private GameObject selectedPlayerSkinLayerGO;
    [SerializeField]
    private TextMeshProUGUI coinsBuyAmountTxt;
    [SerializeField]
    private Button coinsBuyBtn;
    [SerializeField]
    private GameObject coinsBuyInfoContainerGO;
    [SerializeField]
    private TextMeshProUGUI inAppPlayerSkinBuyAmountTxt;
    [SerializeField]
    private Button inAppPlayerSkinBuyBtn;
    [SerializeField]
    private GameObject inAppPlayerSkinBuyInfoContainerGO;

    private int playerSkinImgIndex;

    public TextMeshProUGUI PlayerSkinNameTxt => playerSkinNameTxt;
    public Image PlayerSkinSpriteImg => playerSkinSpriteImg;
    public GameObject SelectedPlayerSkinLayerGO => selectedPlayerSkinLayerGO;
    public TextMeshProUGUI CoinsBuyAmountTxt => coinsBuyAmountTxt;
    public Button CoinsBuyBtn => coinsBuyBtn;
    public GameObject CoinsBuyInfoContainerGO => coinsBuyInfoContainerGO; 
    public TextMeshProUGUI InAppPlayerSkinBuyAmountTxt => inAppPlayerSkinBuyAmountTxt;
    public Button InAppPlayerSkinBuyBtn => inAppPlayerSkinBuyBtn;
    public GameObject InAppPlayerSkinBuyInfoContainerGO => inAppPlayerSkinBuyInfoContainerGO;

    public int PlayerSkinImgIndex
    {
        get { return playerSkinImgIndex; }
        set
        {
            playerSkinImgIndex = value;
        }
    }
}
