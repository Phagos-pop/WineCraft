using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData
{
    public int numberOfField;
    public int level;
    public int experience;
    public FieldData(int _numberOfField)
    {
        numberOfField = _numberOfField;
        experience = 0;
        level = 0;
    }
}
