using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainManager : MonoBehaviour
{
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private TilemapManager tilemapManager;
    private FieldManager fieldManager;
    private TimeManager timeManager;


    private void Start()
    {
        InitManagers();
        InitCallback();
    }

    private void InitCallback()
    {
        uIManager.AddSeemEvent += UIManager_AddSeem;
        fieldManager.FieldLevelApp += FieldManager_FieldLevelApp;
        uIManager.AddWeekEvent += UIManager_AddWeekEvent;
        uIManager.HarvestEvent += UIManager_HarvestEvent;
        uIManager.ClosePanelEvent += UIManager_ClosePanelEvent;
        inputSystem.ClickPosEvent += InputSystem_ClickPosEvent;
    }

    private void OnDestroy()
    {
        uIManager.AddSeemEvent -= UIManager_AddSeem;
        fieldManager.FieldLevelApp -= FieldManager_FieldLevelApp;
        uIManager.AddWeekEvent -= UIManager_AddWeekEvent;
        uIManager.HarvestEvent -= UIManager_HarvestEvent;
        uIManager.ClosePanelEvent -= UIManager_ClosePanelEvent;
        inputSystem.ClickPosEvent -= InputSystem_ClickPosEvent;
    }

    private void InitManagers()
    {
        timeManager = new TimeManager();
        fieldManager = new FieldManager();
        tilemapManager.Init();        
        fieldManager.Init();
        timeManager.Init();
        uIManager.Init(timeManager.dateTime);
    }

    #region Callbacks
    private void InputSystem_ClickPosEvent(Vector3 clickPos)
    {
        Vector3Int sellPosition = tilemapManager.GetSellPosition(clickPos);
        if (tilemapManager.CheckTile(sellPosition) && uIManager.panelNotOpen)
        {
            inputSystem.SetCameraStaticBehevior();
            int currentField = tilemapManager.GetField(sellPosition);
            var fieldData = fieldManager.GetFieldData(currentField);
            uIManager.ShowFieldPanel(fieldData);
        }
    }

    private void UIManager_ClosePanelEvent()
    {
        inputSystem.SetCameraMoveBehevior();
    }

    private void UIManager_HarvestEvent(int numberOfField)
    {
        tilemapManager.ReplaceTile(numberOfField, GroundTileType.Ground);
        fieldManager.Harvest(numberOfField);
    }

    private void UIManager_AddWeekEvent()
    {
        timeManager.AddWeek();
        fieldManager.AddAllFieldExperience(100);
        uIManager.SetDate(timeManager.dateTime);
    }

    private void FieldManager_FieldLevelApp(FieldData fieldData)
    {
        tilemapManager.ReplaceTile(fieldData.numberOfField, (GroundTileType)fieldData.level);
    }

    private void UIManager_AddSeem(int numberOfField)
    {
        fieldManager.AddFieldExperience(numberOfField, 100);
        tilemapManager.ReplaceTile(numberOfField, GroundTileType.GroundWithSeem);
    }
    #endregion

}
