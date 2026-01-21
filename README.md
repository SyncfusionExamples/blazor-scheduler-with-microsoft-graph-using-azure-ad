<!--
  howto.md
  A step-by-step guide to integrate Blazor Scheduler with Microsoft Graph using Azure AD
-->
# How to Integrate integrate Blazor Scheduler with Microsoft Graph using Azure AD

This repository contains a sample full-stack application demonstrating how to synchronize events between Microsoft Outlook and the Blazor Scheduler Component with Microsoft Graph API using Azure AD.

## Prerequisites
- dotnet (>= 9.0)
- Microsoft.Graph (>= 5.8)
- Syncfusion.Blazor (>= 30.1)
- Microsoft.Identity.Web.UI(>= 4.0)

## Project Structure
```
├── README.md                  # This guide
├── components                 # All Blazor UI Components
│   ├── Layout                 # UI Layout Components
│   │   ├── LoginDisplay.razor
│   │   ├── MainLayout.razor
│   │   ├── MainLayout.razor.css
│   │   ├── NavMenu.razor
│   ├── Pages                  # Application Pages
│   │   ├── AddEvent.razor     # UI Page for create a new event
│   │   ├── DeleteEVent.razor  # UI page for deleting an event
│   │   ├── Error.razor        # Global Error Page
│   │   ├── GetEvents.razor    # UI page to fetch all events
│   │   ├── Home.razor         # Application Home page
│   │   ├── ListEvents.razor   # UI Page for all events
│   │   ├── UpdateEvent.razor  # UI page to update an event
│   ├── Imports.razor          
│   ├── App.razor              # Blazor Root Component
│   ├── Routes.razor  
├── Properties
│   ├── launchSettings.json
├── appsettings.Development.json
├── appsettings.json
├── BlazorSchedulerWithMSGraph.csproj
└── Program.cs                 # Application Startup file
```
## Setup

### Cloning the repository
    
- Clone the repository to your local machine

### Change key configuration in the appsettings.json file.

- Replace **Domain** , **TenantId** , **ClientId** and **ClientSecret** in the appsettings.json with your generated in AzureAD to integrate your outlook calender events to the Blazor scheduler.

### Available Endpoints

| Method | URL                          | Description                         |
| ------ | ---------------------------- | ----------------------------------- |
| GET    | `/getevents`    | get a event|
| GET    | `/listevents`    | List events in the given time range |
| POST   | `/addevent`                | Add a new event                  |
| PUT    | `/updateevent`            | Update an existing event            |
| DELETE | `/deleteevent`            | Delete an event 

## Running the Application
1. Rebuild the solution to restore Packages: 
    ```bash
    dotnet build
    ```
2. Start the application:
    ```bash
    dotnet run
    ```
3. Navigate to [`http://localhost:5074`](http://localhost:5074) in your browser.

4. Log in with the Microsoft account to display outlook calender events on the scheduler.

5. You can perform CRUD operation on the scheduler that will be reflected in the Outlook Calender

## Output Preview
![Frontend Preview](./Output/Frontend.png)
*Image illustrating the Syncfusion React Scheduler* 

# Troubleshooting
- **401 Unauthorized**: Check Domain, TenantId, CliendId and ClientSecret in appsettings.json.
- **Page Not Found**: Ensure to Enter the correct credentials to avoid bad request.