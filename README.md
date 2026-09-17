# GreenGrow-IoT-Monitor
A C# WPF IoT Monitoring application that retrieves environmental data from the Open-Meteo API and demonstrates Stack-based LIFO temperature history management

## Overview

GreenGrow IoT Monitor is a C# WPF desktop application developed as an IoT environmental monitoring prototype for a greenhouse environment.

The application retrieves real-time environmental data from the Open-Meteo Weather API and presents the information through a graphical WPF interface. The system displays temperature, relative humidity, wind speed, and soil moisture for a selected location in South Africa.

The application also maintains a history of temperature readings using the C# Stack data structure. This demonstrates the Last-In, First-Out (LIFO) principle by allowing the most recently stored temperature reading to be viewed or removed first.

## Features

- WPF desktop user interface
- Real-time environmental data retrieval
- Open-Meteo REST API integration
- JSON response processing
- Temperature monitoring
- Relative humidity monitoring
- Wind speed monitoring
- Soil moisture monitoring
- Temperature history management
- Stack-based LIFO implementation
- View latest stored temperature reading
- Remove latest stored temperature reading
- Number of stored readings
- Empty Stack validation
- Object-oriented C# design
- API connection status display

## Technologies Used

- C#
- .NET 10
- WPF
- XAML
- REST API
- JSON
- System.Text.Json
- HttpClient
- Generic Stack data structure

## API

The application uses the Open-Meteo Forecast API.

Open-Meteo provides weather information through a JSON-based REST API. The application sends geographical coordinates and requests the environmental variables required by the monitoring system.

The application uses Pretoria, South Africa as the monitored location.

Latitude:
-25.7479

Longitude:
28.2293

The application requests the following environmental variables:

- Temperature at 2 metres
- Relative humidity at 2 metres
- Wind speed at 10 metres
- Soil moisture at 0 to 1 centimetre

The API request is made using an HTTP GET request and the returned JSON data is deserialized into C# objects.

Open-Meteo does not require an API key for the free non-commercial API.

API documentation:

https://open-meteo.com/en/docs

## Application Architecture

The application uses a simple class-based structure appropriate for a WPF desktop application.

### Models

The Models folder contains classes used to represent data returned by the API and sensor information.

#### SensorReading

The SensorReading class represents a sensor reading and contains properties for:

- Sensor name
- Sensor value
- Unit
- Status

The class is instantiated when a new temperature reading is retrieved from the API.

#### WeatherResponse

The WeatherResponse class represents the JSON response received from Open-Meteo.

It contains the current weather information required by the application.

### Services

#### WeatherApiService

The WeatherApiService class manages communication with the Open-Meteo API.

It is responsible for:

1. Constructing the API request.
2. Sending the HTTP GET request.
3. Receiving the JSON response.
4. Deserializing the JSON data.
5. Returning the weather information to the WPF application.

### Main Window

MainWindow.xaml provides the graphical user interface.

MainWindow.xaml.cs handles user interactions and manages the temperature history Stack.

## Data Flow

The application follows the following data flow:

API request
      ↓
Open-Meteo REST API
      ↓
JSON response
      ↓
WeatherResponse C# object
      ↓
SensorReading object
      ↓
Stack<SensorReading>
      ↓
WPF interface

The API provides the environmental data, the JSON response is converted into C# objects, and the temperature reading is stored in the Stack for historical access.

## Stack and LIFO Implementation

The application uses a generic C# Stack:

Stack < SensorReading >  

## Error handling

The application includes error handling for API communication faliures.

If the application cannot communicate with the Open-Meteo API, the system status changes to OFFLINE and an error message is displayed to the user.

The application also prevents invalid Stack operations when no readings are stored.

For example, attempting to use Peek() or Pop() on an empty Stack displays an appropriate message instead of performing an invalid operation.

## User Interface

The WPF interface contains the following sections:

#### Application Header

Displays the application name and monitored location.

#### Environmental Readings

Displays:

- Current temperature
- Relative humidity
- Wind speed
- Soil moisture
- System Status

Displays whether the application is currently connected to the API.

#### Temperature History

Displays:

- Latest stored reading
- Number of stored readings
- Retrieve New Data
- View Latest Reading
- Remove Latest Reading

## Running the Application
#### Requirements
- Windows
- Visual Studio 2026 or a compatible version of Visual Studio
- .NET 10 SDK
- Internet connection for Open-Meteo API access
#### Steps
1. Clone the repository.
2. Open the solution file in Visual Studio.
3. Restore the project dependencies if required.
4. Build the solution.
5. Run the application.
6. Select Retrieve New Data to request the latest environmental information.
7. Use View Latest Reading to retrieve the latest temperature from the Stack without removing it.
8. Use Remove Latest Reading to remove the latest temperature reading.

   
## API Data and Attribution

Weather data is provided by Open-Meteo.

Open-Meteo data is provided under the Creative Commons Attribution 4.0 International licence (CC BY 4.0).

Attribution is required when using the data.

Open-Meteo:

https://open-meteo.com/

API Documentation:

https://open-meteo.com/en/docs

## Purpose

The purpose of this project is to demonstrate the integration of a REST API with a C# WPF desktop application while applying object-oriented programming and data structure concepts.

The project demonstrates how external environmental data can be retrieved, processed, represented using C# objects, displayed through a graphical interface, and stored using a Stack for LIFO-based history management.

## Author

Developed by Siyabonga Nkomazana.

This project was developed as part of Programming 3B coursework and is also maintained as a portfolio demonstration of C#, WPF, REST API integration, JSON processing, object-oriented programming, and data structures.
