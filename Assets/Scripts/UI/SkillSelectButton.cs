using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{
    public SkillName skillName;
    public Button button;
    public Image skillIcon;
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI skillLevelText;
    private Skill skill;

    private void Awake()
    {
        button.onClick.AddListener(LevelUp);    
    }

    private void OnEnable()
    {
        if (SkillManager.Instance.skillQueueDictionary[skillName].Count > 0)
        {
            skill = SkillManager.Instance.skillQueueDictionary[skillName].Peek();
            skillIcon.sprite = skill.skillIcon;
            skillNameText.text = skill.nameInKor;
            descriptionText.text = skill.description;
            skillLevelText.text = $"���� {skill.level}";
        }
    }

    private void LevelUp()
    {
        SkillManager.Instance.LevelUp(skillName);
    }
}
