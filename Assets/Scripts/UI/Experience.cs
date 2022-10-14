using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Experience : MonoBehaviour
{
    public int experience;
    public int level;
    public int expPerLevel = 5;

    public Slider expSlider;
    public TextMeshProUGUI expText;
    void Start()
    {
        experience = 0;
        level = 1;
        expSlider.value = 0;
        expText.text = "Nivel 1";
    }

    
    public void UpdateExp(int value) {
        experience += value;
        while(experience >= expPerLevel)
        {
            experience -= expPerLevel;
            level++;
        }
        expSlider.value = experience;
        expText.text = level.ToString();
    }

}
