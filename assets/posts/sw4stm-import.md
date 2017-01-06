### Importing generated code into SW4STM32 ###
1. Use [these instructions](http://www.openstm32.org/Importing+a+STCubeMX+generated+project) as a base steps.
1. After Step 4 (Import the STM32CubeMX generated project as following) you may face an issue when project imported with only one build configuration ('Default'). This won't compile the project.
  1. RMB Click on project
  1. Select: Build Configurations >> Manage
  1. Press "New" button, input Name and activate "Import predefined" option
  1. Select "Executable > Ac6 STM32 MCU GCC > Debug" or "... > Release"
  1. Create two Build Configurations: Debug and Release
1. Fix Build Errors (if any ;)
