# Blazor Scheduler with Microsoft Graph using Azure AD

A solution demonstrating integration of Office 365 Outlook events with a Blazor calendar application using Microsoft Graph API and Azure AD authentication.

## Project Overview

This project integrates Microsoft Office 365 Outlook with Blazor applications, leveraging Microsoft Graph API to fetch calendar events and display them in a Syncfusion Blazor Scheduler component, secured through Azure AD authentication.

## Key Features

* Azure AD Authentication for secure access
* Microsoft Graph Integration with Office 365 Outlook
* Interactive Syncfusion Blazor Scheduler component
* Create, update, and delete calendar events
* Server-side Blazor rendering for dynamic processing

## Technologies Used

* Blazor (.NET 9.0) - Interactive web framework
* Microsoft Graph API - Office 365 services access
* Azure Active Directory - Authentication
* Syncfusion Blazor Components - UI components
* ASP.NET Core - Backend framework

## Prerequisites

* Visual Studio 2022
* .NET 9.0 SDK or later
* Azure AD tenant with registered application
* Microsoft 365 subscription with Office 365 access

## How to Run the Project

1. Checkout this project to your local disk
2. Open the solution file using Visual Studio 2022
3. Restore NuGet packages by rebuilding the solution
4. Configure Azure AD settings in `appsettings.json`
5. Update Microsoft Graph API permissions as needed
6. Run the project

## Configuration

Update the following in `appsettings.json`:
* Azure AD tenant ID and client ID
* Microsoft Graph API scopes and permissions
* Redirect URIs for Azure AD authentication

## Documentation

For more information, refer to:

* **Blazor Introduction**: https://blazor.syncfusion.com/documentation/introduction
* **Blazor Schedule Component**: https://blazor.syncfusion.com/documentation/schedule/getting-started
* **Microsoft Graph API**: https://docs.microsoft.com/en-us/graph
* **Azure AD Documentation**: https://docs.microsoft.com/en-us/azure/active-directory

## Support

For issues or questions, please refer to the official documentation or submit an issue in the repository.
