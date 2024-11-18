using System;
using System.Linq;
using Kuhpik;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace _Source.Code.Systems
{
    public class ShopSystem : GameSystemWithScreen<ShopScreen>
    {
        private int _currentSkinIndex;
            
        public override void OnInit()
        {
            screen.BackButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Menu));
            screen.BuyButton.onClick.AddListener(BuySkin);

            for (int i = 0; i < screen.ShopButton.Length; i++)
            {
                var i1 = i;
                screen.ShopButton[i].onClick.AddListener(()=>ChoseSkin(i1));

                screen.ShopButton[i].image.sprite = config.ShopItemDatas[i].Icon;
            }
            
        }

        public override void OnUpdate()
        {
            screen.CoinsText.SetText($"COINS: {player.Coins}");
        }

        private void ChoseSkin(int i)
        {
            var countToShift = (i+_currentSkinIndex) - _currentSkinIndex;

            
            for (int j = 0; j < config.ShopItemDatas.Length; j++)
            {
                var data = config.ShopItemDatas[j];

                if (data.SkinIndex == i)
                {
                    _currentSkinIndex = i;
                }
            }
            
            for (int j = 0; j < countToShift; j++)
            {
                ShiftArrayLeft();
            }
            
            RedrawButtons();
        }

        private void RedrawButtons()
        {
            for (int i = 0; i < screen.ShopButton.Length; i++)
            {
                screen.ShopButton[i].image.sprite = config.ShopItemDatas[i].Icon;
            }
            
            screen.PriceText.SetText($"PRICE: {config.ShopItemDatas[0].Price}");
            screen.EnergyBar.fillAmount = ((float)config.ShopItemDatas[0].Energy/4);
            screen.DamageBar.fillAmount =  ((float)config.ShopItemDatas[0].Damage/5);

            if (player.BoughtSkinsIndexes.Contains(config.ShopItemDatas[0].SkinIndex))
            {
                screen.PriceText.gameObject.SetActive(false);
                screen.BuyButton.image.sprite = screen.UseSprite;
            }
            else
            {
                screen.PriceText.gameObject.SetActive(true);
                screen.BuyButton.image.sprite = screen.BuySprite;
            }
        }

        public override void OnStateExit()
        {
            Bootstrap.Instance.SaveGame();
        }

        private void BuySkin()
        {
            if (player.BoughtSkinsIndexes.Contains(_currentSkinIndex))
            {
                player.CurrentSkinIndex = _currentSkinIndex;
            }
            else
            {
                if(player.Coins<config.ShopItemDatas[0].Price) return;

                player.Coins -= config.ShopItemDatas[0].Price;
                
                player.BoughtSkinsIndexes.Add(_currentSkinIndex);
            }
        }
        

        [Button]
        public void ShiftArrayLeft()
        {
            if (config.ShopItemDatas == null || config.ShopItemDatas.Length == 0)
                return;

            var firstElement = config.ShopItemDatas[0];

            for (int i = 0; i < config.ShopItemDatas.Length - 1; i++)
            {
                config.ShopItemDatas[i] = config.ShopItemDatas[i + 1];
            }

            config.ShopItemDatas[config.ShopItemDatas.Length - 1] = firstElement;
        }
    }

    [Serializable]
    public class ShopItemData
    {
        public Sprite Icon;
        public int Energy;
        public int Damage;
        public int Price;
        public int SkinIndex;
    }
}