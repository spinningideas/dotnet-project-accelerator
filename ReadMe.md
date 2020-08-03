Dot Net Project Accelerator was conceived to aid starting .net core 3.x projects and provide a reference implementation for bootstrapping projects.

The project uses React JS for front end that is bootstrapped from [create react app](https://reactjs.org/docs/create-a-new-react-app.html) and uses [react material ui](https://material-ui.com/) for its UX.

The project aims to include most of the basic things one needs and includes:

- fullstack architecture include presentation, API, and backend database management and setup via MS SSDT.
- REST API via .net core web application
- API documentation via OpenApi and Swashbuckle
- Business layer to encapsulate logic
- Data layer via repository pattern powered by EF and pluggable DI based implementation
- Presentation layer via React JS SPA that uses services and HttpClient to communicate Rest API
- localization via services based approach using hooks to manage state.
- use of sass
- forms and validation via [formik](https://jaredpalmer.com/formik/) and [formik-material-ui](https://stackworx.github.io/formik-material-ui/)

## Get Started

### Prerequesites

1. Visual Studio - Can use Free Community Edition available here: https://visualstudio.microsoft.com/downloads/

2. SQL Server - Can use Free Express or Developer Edition available here: https://www.microsoft.com/en-us/sql-server/sql-server-downloads

2.1) Install SQL Server and set yourself as 'sa'
2.2) Create an empty local database with same name "DNPA.Database" as that in the DNPA.API project appsettings.json file for setting ConnectionStrings or edit the value in connection string to match your name

### Clone Repo

Create a folder for this project locally and clone the repo into it

### Build, Install, Run

1.  Load solution in Visual Studio - you can use Visual Code if you are familiar with using it to build .net code [See More Info](https://code.visualstudio.com/docs/languages/dotnet)

2.  Build solution to get the Nuget packages

3.  Setup database - run publish to push the database schema and data to "DNPA.Database"

    1.  Right click on "DNPA.Database" project and run publish with connection pointed to "DNPA.Database"

4.  Install npm packages in DNPA.Presentation

    In the project DNPA.Presentation directory open a console for npm and run:

    4.1 Install npm packages needed by front end React JS application

    `npm install`

5.  Launch the API project (its set to run on port 5001)

    5.1 To start the API press the green arrow (Start button) on the main Visual Studio toolbar, or press F5 or Ctrl+F5
    5.2. Optionally load the postman collection in the "postman" folder and test the API using that if you are only interested in the API

6.  Launch the Presentation project - standard React JS application startup

    6.1 Start and run the application (its set to run on port 5000)

    `npm start`

    Runs the app in the development mode and launches browser to http://localhost:5000

    The page will reload if you make edits.

### `npm run build`

Builds the app for production to the `build` folder.<br />
It correctly bundles React in production mode and optimizes the build for the best performance.

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

# More Info

## Architecture

- https://github.com/spinningideas/architecture/blob/master/ApplicationArchitecture-MediumLevel.pdf

## Database

### Database Project

- https://visualstudio.microsoft.com/vs/features/ssdt/

### Repositories

There is a core system concern of getting and setting data that is encapsulated by the interfaces present in the repositories

In this example the sole repository is a relational database with concrete implementation provided by Entity Framework

#### Entity Framework - Dot Net Core

- https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

#### Entity Framework - Generic Repository

- https://github.com/threenine/Threenine.Data/tree/master/src
- https://garywoodfine.com/generic-repository-pattern-net-core/
- https://codingblast.com/entity-framework-core-generic-repository/
- https://www.growthaccelerationpartners.com/tech/implement-repository-pattern-net-core/
- https://medium.com/@chathuranga94/generic-repository-pattern-for-asp-net-core-9e3e230e20cb
- https://github.com/WolfgangOfner/.NetCoreRepositoryAndUnitOfWorkPattern
- https://www.programmingwithwolfgang.com/repository-pattern-net-core/

- [Cons](https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/)

#### LINQKit

Enhances Entity Framework query building and creating criteria for finding data more dynamically

- https://github.com/scottksmith95/LINQKit
- https://github.com/scottksmith95/LINQKit#predicatebuilder

## Business Layer

The business layer is responsible for encapsulating logic for the application and its set of business rules

It also contains mapping capabilities to convert repository models to ones exposed by the API so that this level does not get exposed to the Presentation Layer

### Mapping - via AutoMapper

- https://medium.com/@nicky2983/how-to-using-automapper-on-asp-net-core-3-0-via-dependencyinjection-a5d25bd33e5b

## API/Services Layer

The API layer exposes getting and setting data via http to the Presentation client (can be web or mobile or both including external systems or partners)

The API layer in this project accelerator utilizes .net Core 3.1 which provides cross platform support for both development and hosting

- https://dotnet.microsoft.com/download/dotnet-core/3.1
- https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1

## Presentation Layer

The front end is enabled in this case by React JS and uses an HttpClient (fetch based)
against services present in API to get/set data along with libraries below to enhance the UX

### Diagram

- https://github.com/spinningideas/architecture/blob/master/ApplicationArchitecture-PresentationLayer.pdf

### React Material UI

- [Usage](https://material-ui.com/getting-started/usage/)
- [Responsive UX](https://material-ui.com/guides/responsive-ui/)

### React Forms

- [formik](https://jaredpalmer.com/formik/)
- [formik-material-ui](https://stackworx.github.io/formik-material-ui/)

## Model Types

For the purposes of this project accelerator the following definitions of models and their type may help clarify the opinions in the project

### API Model or Data Transfer Object (DTO)

This is an object to transfer data to and from an API and can contain additional datapoints for this that are not persisted (eg page size needed or response codes). One purpose of separating DTOs from Entity models is to prevent exposing the database model directly to clients so that you can refactor and change the backend without affecting the front end. These models can be more than a flat structure if use cases justify it (eg a [PagedList](https://github.com/spinningideas/resources/wiki/PagedList) containing data payload and pagination data points)

### Entity Object

This is an object used to transfer data to the database or repository and should not contain business logic but can represent a formal object in the domain if the database tables closely mirror the domain objects (eg Person or User). This object should have a flat structure containing
only simple type properties/fields (strings, numbers, datetimes, booleans)

### Domain Object

This is an object that represents some business object (real world object in the problem domain) and can be subject of some validation logic. There are no examples of this type in this project as it is purposefully simple however you can have various flavors of this if your domain is complex enough. See [What it is](https://stackoverflow.com/questions/1863537/what-is-a-domain-model/53559615) and [relevant search](https://www.google.com/search?q=domain+driven+design+domain+model)
