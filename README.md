# Sibers Chat application
The application is example of my code for ASP.NET development

## Getting Started

### Prerequisites
WebSockets - there are a few requirements for using WebSockets. It must be supported by both the browser and the web server. The WebSocket protocol is currently supported in Chrome, Firefox, and Safari and will be supported in the upcoming Internet Explorer 10 release. On server side you must install WebSockets feature like in an article: https://docs.microsoft.com/en-us/iis/configuration/system.webserver/websocket

### Installing
Now once you’ve met the requirements, you’ll need to enable support for WebSockets on IIS. You can do so by going through Control Panel > Programs > Turn Windows features on or off. You’ll then need to make sure the following boxes are checked:
Internet Information Services > World Wide Web Services > Application Development Features > ASP.NET 4.5
Internet Information Services > World Wide Web Services > Application Development Features > WebSocket Protocol
.NET Framework 4.5 Advanced Services > ASP.NET 4.5

## Running the tests
Explain how to run the automated tests for this system

### Break down into end to end tests
Explain what these tests test and why
```
Give an example
```

### And coding style tests
Explain what these tests test and why
```
Give an example

## Deployment

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Built With
* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds
