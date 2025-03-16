# Week Number Tray Application
This is a C# Windows Forms application that displays the current ISO week number in the system tray. The application runs in the background and updates the week number every minute. It is lightweight, easy to use, and completely hidden from the taskbar.

## Features
- System Tray Icon: Displays the current week number as an icon in the system tray.

- Auto-Update: The week number updates automatically every minute.

- Lightweight: Runs in the background with minimal resource usage.

- Easy Exit: Right-click the tray icon and select "Exit" to close the application.

## How It Works
The application uses the NotifyIcon class to create a system tray icon. The week number is calculated using the ISO 8601 standard and displayed as an icon. The icon is dynamically generated using the System.Drawing namespace.

## Key Components
  Tray Icon:

- The NotifyIcon class is used to create and manage the system tray icon.

- The icon is updated every minute with the current week number.

## Week Number Calculation:

The GetWeekNumber method calculates the ISO week number using the Calendar.GetWeekOfYear method.

## Dynamic Icon Generation:

The GenerateIcon method creates a 32x32 pixel icon with the week number displayed in the center.

## Context Menu:

A right-click menu allows the user to exit the application.

## Usage
### Prerequisites
- .NET Framework or .NET Core installed on your machine.

- Visual Studio or another C# IDE (optional).

## Steps to Run
Clone the Repository:
```sh
git clone https://github.com/your-username/week-number-tray.git
cd week-number-tray
```
## Build the Application:

- Open the project in Visual Studio.

- Build the solution (Ctrl + Shift + B).

## Run the Application:

Run the executable file (WeekNumberTray.exe) located in the bin/Release or bin/Debug folder.

## Use the Application:

The week number will appear as an icon in the system tray.

Right-click the icon and select "Exit" to close the application.

## Example
When running the application:

The system tray will display an icon with the current week number (e.g., 42).

The icon updates automatically every minute.

## Code Overview
### Main Components
- Form Initialization:

The form is hidden (Visible = false) and removed from the taskbar (ShowInTaskbar = false).

The NotifyIcon is initialized and displayed in the system tray.

1. Timer:

A Timer updates the week number every minute.

2. Icon Generation:

The GenerateIcon method creates a bitmap with the week number and converts it into an icon.

3. Exit Functionality:

The OnExit method stops the timer, disposes of resources, and closes the application.

## License
This project is open-source and available under the MIT License.

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## Screenshot

![Screenshot 2025-03-16 215342](https://github.com/user-attachments/assets/95b139b7-712b-47fc-bbd6-424a7e9c7011)

Example of the system tray icon displaying the week number.
