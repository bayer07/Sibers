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
To star work with data base need to change SQL host name. I use "Bair-PC" and you should replace for your own. Connection string is in Chat.Persistance and Chat.UnitTests and Chat projects, you should replace it all.

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Built With
* [Bootstrap](https://v4-alpha.getbootstrap.com/) - The web CSS framework to make prety layout
* [CastleWindsor](http://www.castleproject.org/projects/windsor/) - Dependency Management
* [EntityFramework](https://docs.microsoft.com/en-us/ef/) - Used to acced to data base and bind to classes
* [JQuery] (https://jquery.com/) - Used for HTML DOM managment
* [JQueryUI] (https://jqueryui.com/) - Used to create Dialogs
* [NUnit] (http://nunit.org/) - Used for writing unit tests
* [Web API] (https://www.asp.net/web-api) - API for access to HTTP protocol