<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://www.useorigin.com/join-us">
    <img src="https://assets-global.website-files.com/5fc46a8c6532b70b61e49a29/5fc46a8c6532b7ebb5e49a87_origin_logo_dark.svg" alt="Logo" width="150" height="150">
  </a>

<h3 align="center">Insurance API</h3>

  <p align="center">
    This is an API to calculate financial risk for defining types of insurance
    <br />
    <br />
    <a href="https://github.com/pedrohenriquerissato/InsuranceAPI/issues">Report Bug</a>
    ·
    <a href="https://github.com/pedrohenriquerissato/InsuranceAPI/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About The Project

<div align="center">
  <a href="https://www.useorigin.com/join-us">
    <img src="https://i.imgur.com/7YTR3PC.png" alt="Image of API online documentation">
  </a>

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

- [NET](https://dotnet.microsoft.com/en-us/)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

First, you need to install [ASP.NET Core Runtime >= 6.0.2](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

### Running

1. Clone the repo
   ```sh
   git clone https://github.com/pedrohenriquerissato/InsuranceAPI.git
   ```
2. Get into projects root folder (where .sln file is located) and build the project
   ```sh
   dotnet build
   ```
3. Start the API by running
   ```sh
   dotnet run --project Insurance.API/Insurance.API.csproj
   ```

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->

## Usage

The available endpoints can be viewed accessing the API builtin documentation at:

```sh
https://host:port/swagger/index.html
```

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- TECHNICAL DECISIONS -->

## Technical Decisions

1. Usage of .NET Framework  
   Due to the time I develop professionally using technology.
2. .NET Version Choice  
   .NET Core 3.1 is the most widely used version. However, besides having no professional experience with .NET 6,
   it is the logical choice as it is a Long Term Supported version by November 8th, 2024.
   [Source](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core#lifecycle).
   Usually, this decision should not be taken by only one developer. The whole team involved opinions and company
   mandates should be observed.
3. Domain-Driven Design (DDD)  
   DDD is the design pattern of the moment when we talk about API construction nowadays. Its flexibility and
   separation of business/project layers makes a project highly scalable and manageable over time.
   [Read More](https://martinfowler.com/bliki/DomainDrivenDesign.html). This design pattern consists of four layers,
   which may vary depending on the implementation, but in theory, they are: Presentation, Application, Domain and
   Infrastructure. In this project, Presentation is the API layer. I like to add another layer called
   Persistence that may be responsible for Database contexts and interactions. Finally, I like to rename Infrastructure
   layer as Integration, which will be responsible for interaction with external services and other APIs.
4. Fail Fast "pattern/principle/approach"  
   [Fail Fast](https://www.martinfowler.com/ieeeSoftware/failFast.pdf) is a growing practice nowadays that recommends
   that errors related to application conditions should be triggered/displayed as soon as possible to the user. I
   achieve this implementation with a brilliant library called [Fluent Validation](https://fluentvalidation.net/).
   With this library, DDD layer separation, and a bit of [CQRS architecture](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs),
   those rules are kept inside a folder called "Validators", inside Application layer, under business product/rule
   named folder. Usually, these validators will contain a lot of technical rules, ie. Age >= 0, and a few business rules,
   like, a House can exist or not. This validation is fired as soon as a call hits the Controller endpoint and won't
   get any further if one or more conditions are broken.
5. Mediator Pattern  
   There are many ways of calling "backend" business rules from the Controller. Two of the most common are with Repository
   pattern and [Mediator](https://refactoring.guru/design-patterns/mediator) pattern. In a Repository pattern, usually, an
   interface class will provide all the available contracts methods and another class will implement those contracts.
   Ex.: IRiskAnalysisRepository and RiskAnalysisRepository. It's a great pattern and has its own perks, but, on the downside, you'll need to prepare the input model on the Controller
   class, or create another class for this task. Prepare on Controller class, will generate a lot of code and compromise
   Controller's readability. Create another class, will be more elegant. However, in a Repository pattern, that's all we
   get and its purpose ends right there. With the Mediator pattern, we will have initially less code,
   since only an intermediate class and a handler are needed to handle a calling to that Domain rules "solver".
   Besides that, with the Mediator pattern, it's possible to even implement some sort of Event-Driven solution
   (integrating with Amazon SNS, Kafka, etc.). The Mediator controls all the flows between calls and publishes a message
   for every listener awaiting to catch that message and proceed with another call. But one does not exclude the other,
   in fact, repository pattern [it's recommended either with DDD](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
   and can be implemented together with Mediator.
6. Problem Details  
   Problem Details became an [RFC](https://en.wikipedia.org/wiki/Request_for_Comments) ([RFC7807](https://datatracker.ietf.org/doc/html/rfc7807))
   and nowadays is becoming more present in API implementations. Problem Details is a standard for defining an API
   error response object. The implementation in this project will convert any exception from the API (ProblemDetailsException)
   into a Problem Details object, including 500 errors. This standard is really useful for keeping API response consistency
   among any kind of errors thrown. This is especially great for frontends that can implement interceptors and receive
   the same object, independently of the HTTP error code generated.
7. Rules Pattern  
   Professionally, I've been using technical decisions 1 to 6 more than a year so far, but this is the first time
   implementing [Rules Pattern](https://www.michael-whelan.net/rules-design-pattern/), which, in my opinion, was a
   perfect fit for this kind of problem where we would have a lot of IF-ELSE or SWITCH statements. In our API flow, a
   request comes to a Controller, which will fire a Validator, just by getting an InputModel object, since FluentValidation
   is linked with that object. If the model has any condition violation, an error 400 is thrown and all conditions violated
   are reported, otherwise, the Controller will send a Mediator request and the respective Command and CommandHandler
   will answer it. CommandHandler is the core class that will apply all the business rules related. Rules Pattern

<!-- ROADMAP -->

## Roadmap

- [x] MVP
- [ ] Next endpoints defined by Business Owners

See the [open issues](https://github.com/pedrohenriquerissato/InsuranteAPI/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".  
Don't forget to give the project a star! Thanks again!

###Requirements  
To contribuite with this project you should:

- Install .NET 6.0 Software Development Kit (SDK) >= 6.0.2 available [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Use preferably [Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) or any other IDE with .NET support feature, like [Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet) or [Rider](https://www.jetbrains.com/rider/)

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distribuited under same license as [Assignment](https://github.com/OriginFinancial/origin-backend-take-home-assignment)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

Pedro Henrique Rissato - pedro_giberti@hotmail.com

Project Link: [https://github.com/pedrohenriquerissato/InsuranceAPI](https://github.com/pedrohenriquerissato/InsuranceAPI)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->

## Acknowledgments

- [Origin](https://www.useorigin.com/)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/pedrohenriquerissato/InsuranceAPI.svg?style=for-the-badge
[contributors-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/pedrohenriquerissato/InsuranceAPI.svg?style=for-the-badge
[forks-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/network/members
[stars-shield]: https://img.shields.io/github/stars/pedrohenriquerissato/InsuranceAPI.svg?style=for-the-badge
[stars-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/stargazers
[issues-shield]: https://img.shields.io/github/issues/pedrohenriquerissato/InsuranceAPI.svg?style=for-the-badge
[issues-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/issues
[license-shield]: https://img.shields.io/github/license/pedrohenriquerissato/InsuranceAPI.svg?style=for-the-badge
[license-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/phdev
[product-screenshot]: https://i.imgur.com/7YTR3PC.png
