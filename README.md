```markdown
# Atera Alerts Cleaner

## Overview

This project provides a utility for fetching and processing alerts from the Atera API. Specifically, it retrieves all alerts for a given account/tenant (requires Atera API) and deletes alerts (clean up the mess, since Atera offers no smart wait to delete thousands of alerts using the UI/Web Application) associated with a specific customer ID.

## Features

- Fetches alerts from the Atera API using the provided API key.
- Processes each alert and outputs relevant information to the console.
- Deletes alerts that belong to a customer with a specific `CustomerID` (default is `8`).
- Automatically handles pagination to ensure all alerts are processed.

## Prerequisites

- .NET Core SDK
- An active Atera API key

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/AteraAlertsCleaner.git
cd AteraAlertsCleaner
```

### 2. Set Up the Environment

Ensure that your Atera API key is available as an environment variable:

```bash
export AteraApiKey=your_api_key_here
```

Alternatively, you will be prompted to enter your API key when running the program.

### 3. Run the Program

You can run the program using the .NET CLI:

```bash
dotnet run
```

### 4. Alerts Processing

The program will fetch alerts in batches (if paginated) and display the following information for each alert:

- Alert ID
- Code
- Source
- Title
- Severity
- Created Date
- Additional Information
- Device Name
- Customer Name

Alerts with `CustomerID` 8 will be automatically deleted.

## Customization

If you need to change the `CustomerID` that triggers the deletion of alerts, modify the following line in the `Program.cs` file:

```csharp
if (alert.CustomerID == 8)
```

Replace `8` with the desired `CustomerID`.

## Error Handling

The application includes basic error handling for network and API issues. In case of an error, the details will be printed to the console.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue.

### Steps to Contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [Atera](https://www.atera.com/) for providing the API and platform used in this project.
```

### Key Sections:
- **Overview**: Describes what the project does.
- **Features**: Highlights the main functionalities.
- **Prerequisites**: Lists the requirements to run the project.
- **Getting Started**: Steps to set up and run the application.
- **Customization**: Instructions on how to modify the behavior.
- **Error Handling**: Briefly explains how errors are managed.
- **Contributing**: Encourages contributions with steps to do so.
- **License**: Mentions the license under which the project is distributed.
- **Acknowledgements**: Credits any third-party resources or inspirations. 

Feel free to customize this `README.md` to better suit your project and any additional features or instructions you may have.
