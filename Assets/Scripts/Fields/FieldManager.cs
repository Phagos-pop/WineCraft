using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldManager
{
    private Dictionary<int, FieldData> fieldDict;
    public event Action<FieldData> FieldLevelApp;

    public void Init()
    {
        InitFieldData();
    }

    private void InitFieldData()
    {
        fieldDict = new Dictionary<int, FieldData>()
        {
            {1,new FieldData(1) },
            {2,new FieldData(2) }
        };
    }

    public FieldData GetFieldData(int numberOfField)
    {
        return fieldDict[numberOfField];
    }

    public void AddFieldExperience(int numberOfField, int experience)
    {
        fieldDict[numberOfField].experience += experience;
        CheckForFieldUpdate(fieldDict[numberOfField]);
    }
    public void AddAllFieldExperience(int experience)
    {
        foreach (var item in fieldDict)
        {
            if (item.Value.level > 0)
            {
                AddFieldExperience(item.Value.numberOfField, experience);
            }
        }
    }

    public void CheckForFieldUpdate(FieldData fieldData)
    {
        if (fieldData.experience > 500)
        {
            fieldData.level = 3;
            FieldLevelApp?.Invoke(fieldData);
        }
        else if (fieldData.experience > 300)
        {
            fieldData.level = 2;
            FieldLevelApp?.Invoke(fieldData);
        }
        else if (fieldData.experience > 90)
        {
            fieldData.level = 1;
        }
    }

    public void Harvest(int numberOfField)
    {
        fieldDict[numberOfField].experience = 0;
        fieldDict[numberOfField].level = 0;
    }
}
