# SnipeAgent

## Overview

SnipeAgent is a System Tray App for Windows. On  First run it takes data from the local machine to create a uniqe asset in your Snipe-IT instance. It interacts with your Snipe-IT instance via the API provided by the Snipe-IT Server. 


![Agent Working](github/res/Agent-Working.png)

## Features

- Creates Asset automatically on first run
- Is able to update the asset it is associated with in the database
- Defaults to default asset model if no corresponding product number of your device is found in database
- Assigns the asset to the user that is currently logged in while running the program, if the user is not found it will default to the "assigned" state

### Prerequisites

- **A Running Snipe-IT instance**
- **A Valid API Key**
- **Every SnipeAgent capable Asset Model has to use a fieldset with the fields MAC and UUID**
    - MAC Custom field is a simple Unique Textbox
    - UUID Custom field is of the format "ALPHA-DASH" which also has to be Uniqe as SnipeAgent uses the UUID to identify its created assets

![Agent Working](github/res/necessary-custom-fields.png)

### Build

```git clone https://github.com/DarkZoneSD/SnipeAgent.git```

Edit the variables declared in the solution Resources

```Dotnet Build```

### To Do
Add a light mode, selectable in the settings

create a  deployment script  for the application
