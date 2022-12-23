using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Text dateText;
    [SerializeField] private Text grapeCountText;
    [SerializeField] private GameObject fieldPanel;
    [SerializeField] private Button addSeemButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button nextWeekButton;
    [SerializeField] private Button harvestButton;

    private int grapeCount;

    private FieldData currentFieldData;

    public event Action ClosePanelEvent;
    public event Action<int> AddSeemEvent;
    public event Action AddWeekEvent;
    public event Action<int> HarvestEvent;

    public void Init(DateTime dateTime)
    {
        dateText.text = "Date " + dateTime.ToShortDateString();
        grapeCountText.text = "grape count " + grapeCount;
    }

    public void ShowFieldPanel(FieldData fieldData)
    {
        Debug.Log("fieldData.numberOfField" + fieldData.numberOfField);
        if (fieldData.level > 0)
        {
            addSeemButton.gameObject.SetActive(false);
        }
        else
        {
            addSeemButton.gameObject.SetActive(true);
        }

        if (fieldData.level == 3)
        {
            harvestButton.gameObject.SetActive(true);
        }
        else
        {
            harvestButton.gameObject.SetActive(false);
        }
        nextWeekButton.gameObject.SetActive(false);
        fieldPanel.SetActive(true);
        levelText.text = "Level of Field " + fieldData.level;
        currentFieldData = fieldData;
    }
    public void UpdateFieldPanel()
    {
        levelText.text = "Level of Field " + currentFieldData.level;
    }

    public void AddExpi()
    {
        addSeemButton.gameObject.SetActive(false);
        AddSeemEvent?.Invoke(currentFieldData.numberOfField);
        UpdateFieldPanel();
    }

    public void ClosePanel()
    {
        fieldPanel.gameObject.SetActive(false);
        nextWeekButton.gameObject.SetActive(true);
        ClosePanelEvent?.Invoke();
    }

    public void AddWeek()
    {
        AddWeekEvent?.Invoke();
    }

    public void SetDate(DateTime dateTime)
    {
        dateText.text = "Date " + dateTime.ToShortDateString();
    }

    public void Harvest()
    {
        harvestButton.gameObject.SetActive(false);
        grapeCount += 60;
        grapeCountText.text = "Grape count " + grapeCount;
        HarvestEvent?.Invoke(currentFieldData.numberOfField);
    }
}
