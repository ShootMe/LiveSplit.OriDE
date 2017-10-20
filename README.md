# LiveSplit.OriDE
Autosplitter for the game Ori and the Blind Forest DE

## Setting up the autosplitter in LiveSplit
- Go to the [releases](https://github.com/ShootMe/LiveSplit.OriDE/releases) section in this repository.
- Download the latest LiveSplit.OriDE.dll
- Place the LiveSplit.OriDE.dll inside the Components folder
- Open LiveSplit, edit your layout, add Control -> Ori DE Autosplitter
- Then set it up to match the splits you want to split on

## Development

* Open the `LiveSplit.OriDE.sln` in Visual Studio
* Add `LiveSplit.Core.dll` and `UpdateManager.dll` (from your LiveSplit directory) as references to the `LiveSplit.OriDE` project.
	* **Visual Studio 2017**: Right click `LiveSplit.OriDE` in Solution Explorer, `Add -> Reference...`, `Browse...`
