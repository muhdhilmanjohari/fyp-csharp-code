using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    private bool lineToggle = false;
    private int currentFloor = 0;

    // Start is called before the first frame update
    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    // Update is called once per frame
    private void Update()
    {
        if(lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            Vector3[] calculatedPathAndOffset = AddLineOffset();
            line.SetPositions(calculatedPathAndOffset);
        }
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if(currentTarget != null)
        {
            if (!line.enabled){
                ToggleVisibility();
            }
            targetPosition = currentTarget.PositionObject.transform.position;
        }
    }

    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber)
    {
        currentFloor = floorNumber;
        SetNavigationTargetDropDownOptions(currentFloor);
    }

    private Vector3[] AddLineOffset()
    {
        if(navigationYOffset.value == 0)
        {
            return path.corners;
        }

        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for(int i = 0; i<path.corners.Length; i++)
        {
            calculatedLine[i] = path.corners[i] + new Vector3(0, navigationYOffset.value, 0);
        }
        return calculatedLine;
    }

    private void SetNavigationTargetDropDownOptions(int floorNumber)
    {
        navigationTargetDropDown.ClearOptions();
        navigationTargetDropDown.value = 0;

        if (line.enabled)
        {
            ToggleVisibility();
        }

        if(floorNumber == 0)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK7"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK5"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Bilik Persediaan"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Makmal Fizik"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK6"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Lift and Stair"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Gamma Office"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Lecturer Office"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ATM"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Surau"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK8"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Makmal Kimia"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Toilet"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Shop"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Auditorium"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Smart Class Room"));




        }

        if (floorNumber == 1)
        { 
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("test"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Lecturer Office A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Gamma Office A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK10"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK11"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK12"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Auditorium A"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK13-BK14"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Toilet and BK15"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK16"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK17"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("BK18"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Stair and Lift A"));

        }
    }
}
