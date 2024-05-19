using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSprite_Unit : MonoBehaviour
{
    public Image[] imageSlots; // 4개의 이미지 슬롯 
    public Sprite[] sprites; // 스프라이트를 저장할 배열

    public static RandomSprite_Unit instance;

    [SerializeField] private int level = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        level = Exp.instance.level;
    }

    public void RandomSprite()
    {
        if (GameManager.instance.gold >= 2)
        {
            GameManager.instance.gold -= 2;
            for (int i = 0; i < imageSlots.Length; i++)
            {
                int randomIndex = 0;
                if (level == 1)
                {
                    randomIndex = Random.Range(0, 105);
                }

                else if (level == 2)
                {
                    float randomValue = Random.Range(0, 10);
                    if (randomValue < 8.5f)
                    {
                        randomIndex = Random.Range(0, 105);
                    }
                    else
                    {
                        randomIndex = Random.Range(105, 153);
                    }
                }

                else if (level == 3)
                {
                    float randomValue = Random.Range(0, 10);
                    if (randomValue < 6f)
                    {
                        randomIndex = Random.Range(0, 105);
                    }
                    else
                    {
                        randomIndex = Random.Range(105, 153);
                    }
                }

                else if (level == 4)
                {
                    float randomValue = Random.Range(0, 10);
                    if (randomValue < 4.5f)
                    {
                        randomIndex = Random.Range(0, 105);
                    }
                    else if (randomValue < 9)
                    {
                        randomIndex = Random.Range(105, 153);
                    }
                    else
                    {
                        randomIndex = Random.Range(153, 183);
                    }
                }

                else if (level == 5)
                {
                    float randomValue = Random.Range(0, 10);
                    if (randomValue < 2.5f)
                    {
                        randomIndex = Random.Range(0, 105);
                    }
                    else if (randomValue < 4)
                    {
                        randomIndex = Random.Range(105, 153);
                    }
                    else if (randomValue < 9f)
                    {
                        randomIndex = Random.Range(153, 183);
                    }
                    else
                    {
                        randomIndex = Random.Range(183, 192);
                    }
                }

                else if (level == 6)
                {
                    float randomValue = Random.Range(0, 10);
                    if (randomValue < 1)
                    {
                        randomIndex = Random.Range(0, 105);
                    }
                    else if (randomValue < 3)
                    {
                        randomIndex = Random.Range(105, 153);
                    }
                    else if (randomValue < 7)
                    {
                        randomIndex = Random.Range(153, 183);
                    }
                    else
                    {
                        randomIndex = Random.Range(183, 192);
                    }
                }
                else //예외 처리
                {
                    randomIndex = Random.Range(0, 105);
                }
                // 선택된 스프라이트를 해당 이미지 슬롯에 적용
                imageSlots[i].sprite = sprites[randomIndex];
            }
        }
    }

    public void RoundRandomSprite()
    {
        for (int i = 0; i < imageSlots.Length; i++)
        {
            int randomIndex = 0;
            if (level == 1)
            {
                randomIndex = Random.Range(0, 105);
            }

            else if (level == 2)
            {
                float randomValue = Random.Range(0, 10);
                if (randomValue < 8.5f)
                {
                    randomIndex = Random.Range(0, 105);
                }
                else
                {
                    randomIndex = Random.Range(105, 153);
                }
            }

            else if (level == 3)
            {
                float randomValue = Random.Range(0, 10);
                if (randomValue < 6f)
                {
                    randomIndex = Random.Range(0, 105);
                }
                else
                {
                    randomIndex = Random.Range(105, 153);
                }
            }

            else if (level == 4)
            {
                float randomValue = Random.Range(0, 10);
                if (randomValue < 4.5f)
                {
                    randomIndex = Random.Range(0, 105);
                }
                else if (randomValue < 9)
                {
                    randomIndex = Random.Range(105, 153);
                }
                else
                {
                    randomIndex = Random.Range(153, 183);
                }
            }

            else if (level == 5)
            {
                float randomValue = Random.Range(0, 10);
                if (randomValue < 2.5f)
                {
                    randomIndex = Random.Range(0, 105);
                }
                else if (randomValue < 4)
                {
                    randomIndex = Random.Range(105, 153);
                }
                else if (randomValue < 9f)
                {
                    randomIndex = Random.Range(153, 183);
                }
                else
                {
                    randomIndex = Random.Range(183, 192);
                }
            }

            else if (level == 6)
            {
                float randomValue = Random.Range(0, 10);
                if (randomValue < 1)
                {
                    randomIndex = Random.Range(0, 105);
                }
                else if (randomValue < 3)
                {
                    randomIndex = Random.Range(105, 153);
                }
                else if (randomValue < 7)
                {
                    randomIndex = Random.Range(153, 183);
                }
                else
                {
                    randomIndex = Random.Range(183, 192);
                }
            }
            else //예외 처리
            {
                randomIndex = Random.Range(0, 105);
            }
            // 선택된 스프라이트를 해당 이미지 슬롯에 적용
            imageSlots[i].sprite = sprites[randomIndex];
        }
    }
}
