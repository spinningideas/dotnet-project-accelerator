Dot Net Project Accelerator was conceived to aid starting .net core 3.x projects and provide a reference implementation for bootstrapping projects. 

The project uses React JS for front end that is bootstrapped from [create react app](https://reactjs.org/docs/create-a-new-react-app.html) and uses [react material ui](https://material-ui.com/) for its UX.

The project aims to include most of the basic things one needs and includes:

- fullstack architecture include database management and setup via MS SSDT.
- REST API via .net core web application
- API documentation via OpenApi and Swashbuckle
- Business layer to encapsulate logic
- Data layer via repository pattern powered by EF and pluggable DI based implementation
- Presentation layer via React JS SPA that uses services and HttpClientto communicate Rest API
- localization and authorization via services based approach using hooks to manage state.
- use of sass
- forms and validation via [formik](https://jaredpalmer.com/formik/) and [formik-material-ui](https://stackworx.github.io/formik-material-ui/)


## Get Started

### Prerequesites

1) Visual Studio - Can use Free Community Edition available here: https://visualstudio.microsoft.com/downloads/

2) SQL Server - Can use Free Express or Developer Edition available here: https://www.microsoft.com/en-us/sql-server/sql-server-downloads

### Clone Repo

Create a folder for this project locally and clone the repo into it

### Build, Install, Run

1) Load solution

2) Build solution to get the Nuget packages

3) Install npm packages

In the project DNPA.Web under the "ClientApp" directory, you can run:

1. Install packages

`npm install`

2. Start and run the application

`npm start`

Runs the app in the development mode and launches browser to http://localhost:3000/react-project-accelerator

The page will reload if you make edits.

### `npm test`

Launches the test runner in the interactive watch mode.<br />
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.<br />
It correctly bundles React in production mode and optimizes the build for the best performance.

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

## More Info

### Database Project

### Entity Framework - Dot Net Core

- https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

### Entity Framework - Generic Repository

- https://github.com/threenine/Threenine.Data/tree/master/src 
- https://garywoodfine.com/generic-repository-pattern-net-core/
- https://codingblast.com/entity-framework-core-generic-repository/
- https://www.growthaccelerationpartners.com/tech/implement-repository-pattern-net-core/
- https://medium.com/@chathuranga94/generic-repository-pattern-for-asp-net-core-9e3e230e20cb
- [Cons](https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/)

### LINQKit

- https://github.com/scottksmith95/LINQKit
- https://github.com/scottksmith95/LINQKit#predicatebuilder

### React Material UI

- [Usage](https://material-ui.com/getting-started/usage/)
- [Responsive UX](https://material-ui.com/guides/responsive-ui/)

### React Forms

- [formik](https://jaredpalmer.com/formik/)
- [formik-material-ui](https://stackworx.github.io/formik-material-ui/)

