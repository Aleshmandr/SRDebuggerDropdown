# SRDebugger Dropdown
<img width="570" alt="Screenshot 2024-03-11 at 18 23 09" src="https://github.com/Aleshmandr/SRDebuggerDropdown/assets/11294931/2c6f48f0-34ae-4ea7-a1d3-80dceea06fe7">

## Installation
Download files and place them in SRDebugger plugin hierarchy
## Example
```csharp
public class SROptions {
   
    [Category("Levels")]
    public SRDropDownData LevelsList { get; set; }
    
    public SROptions()
    {
        int currentLevelIndex = 2;
        var levelsList = new object[]
        {
            "Level_1", "Level_2", "Level_3", "Level_4", "Level_5"
        };
        LevelsList = new SRDropDownData(currentLevelIndex, levelsList);
        LevelsList.SelectionChanged += HandleLevelChange;
    }

    private void HandleLevelChange(int levelIndex)
    {
        Debug.Log($"Load level {LevelsList.Options[levelIndex]}");
    }
}
```
## Known Issues
Editor window dropdown is not supported
