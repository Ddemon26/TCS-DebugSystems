# TCS DebugSystems

![GitHub release (latest by date)](https://img.shields.io/github/v/release/Ddemon26/TCS-DebugSystems)
![GitHub issues](https://img.shields.io/github/issues/Ddemon26/TCS-DebugSystems)
![GitHub pull requests](https://img.shields.io/github/issues-pr/Ddemon26/TCS-DebugSystems)
![GitHub](https://img.shields.io/github/license/Ddemon26/TCS-DebugSystems)

## Overview

**TCS DebugSystems** is an advanced debugging toolkit specifically crafted for Unity, designed to optimize and streamline the debugging workflow within both the Unity Editor environment and during runtime. This package delivers a comprehensive suite of features and utilities, empowering developers to efficiently identify, diagnose, and resolve issues throughout their projects. It includes tools for runtime diagnostics visualization, automated build processes, and custom in-editor functionality, all engineered to facilitate a highly productive development experience.

## Features

- **Debug Information Display**: A sophisticated mechanism for configuring and visualizing diagnostic information directly on-screen during gameplay, providing real-time insights into application behavior.
- **Screenshot Utility**: A robust utility to capture runtime screenshots, facilitating the documentation of game states, issues, or emergent bugs during testing.
- **DragWindow Utility**: Provides functionality for incorporating draggable UI elements, thereby enhancing flexibility and customization capabilities during runtime testing.
- **Error Detector Prefab**: A specialized prefab designed to detect and highlight runtime errors, simplifying the identification and remediation of critical issues.
- **Editor Build Tools**: Tools engineered to automate packaging and build-related workflows, reducing manual overhead and enhancing overall efficiency in the development cycle.

## Installation

1. Clone or download the repository from GitHub.
2. Copy the `TCS DebugSystems` folder into the `Assets` directory of your Unity project.
3. Verify the presence of all necessary dependencies as outlined in the `package.json` file.

## Getting Started

1. **Debug Information Display**: To incorporate the Debug Information Display into your scene, navigate to the `Runtime/Debug-Info-Display` directory and locate the `InfoDisplayPanel` prefab. Drag this prefab into your desired scene to enable its functionality.

2. **Screenshot Utility**: Use the `TakeScreenShot.cs` script to capture the current gameplay state as needed. Hotkeys can be configured to suit specific testing requirements.

## Project Structure

- `TCS DebugSystems/Editor`: Contains scripts that extend the Unity Editor's native capabilities, providing bespoke functionality such as automated packaging (`PackageAutoMover.cs`) and build process management (`TCDebugPlayerBuildProcessor.cs`).
- `TCS DebugSystems/Runtime`: Includes runtime scripts designed to facilitate debugging, such as tools for displaying diagnostic information (`Debug-Info-Display`) and draggable UI elements to improve runtime interface manipulation.
- `Plugins/Prefabs`: Contains prefabricated assets such as the `ErrorDetector` prefab, which is integral for straightforward runtime error detection and integration into various project components.

## Requirements

- Unity version 2021.1 or newer
- .NET Framework version 4.x

## Contributing

We highly encourage contributions aimed at extending and refining the functionality of TCS DebugSystems. To contribute, please follow these steps:

1. Fork the repository to your GitHub account.
2. Create a new branch for your feature (`git checkout -b feature-branch-name`).
3. Implement and commit your changes (`git commit -m 'Add new feature'`).
4. Push your changes to the newly created branch (`git push origin feature-branch-name`).
5. Open a pull request to initiate the review process.

## License

This project is distributed under the MIT License. For detailed terms, refer to the [LICENSE](LICENSE) file.

## Contact

For inquiries or technical support, please feel free to open an issue on the repository or contact the maintainers via the issue tracker.
