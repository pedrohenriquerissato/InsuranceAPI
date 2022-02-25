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

<!-- ABOUT THE PROJECT -->

## About The Project

<div align="center">
  <a href="https://www.useorigin.com/join-us">
    <img src="https://i.imgur.com/7YTR3PC.png" alt="Image of API online documentation">
  </a>
</div>

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This project was built with [NET](https://dotnet.microsoft.com/en-us/).

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

The available endpoints can be viewed accessing the API built-in documentation at:

### Documentation

```sh
https://host:port/swagger/index.html
```

### API Calls

An API request can be made using your favorite API Client or with curl:

```sh
curl -k -X POST -H "Content-Type: application/json" \
    -d '{"age": 35, "dependents": 2, "house": {"ownership_status": "owned"}, "income": 0, "marital_status": "married", "risk_questions": [0, 1, 0], "vehicle": { "year": 2018 }}' \
    https://localhost:7002/risks/analysis
```

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- TECHNICAL DECISIONS -->

## Technical Decisions

1. Usage of .NET Framework  
   Due to the time I develop professionally using this technology.
2. .NET Version Choice  
   .NET Core 3.1 is the most widely used version. However, besides having no professional experience with .NET 6,
   it is the logical choice as it is a [Long Term Supported](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core#lifecycle)
   version by November 8th, 2024. Usually, this decision should not be taken by only one developer. The whole team
   involved opinions and company mandates should be observed.
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
   get any further if one or more conditions are broken. Please refer to comment section below for more info.
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
   and can be implemented along with Mediator.
6. Problem Details  
   Problem Details became an [RFC](https://en.wikipedia.org/wiki/Request_for_Comments) ([RFC7807](https://datatracker.ietf.org/doc/html/rfc7807))
   and nowadays is becoming more present in API implementations. Problem Details is a standard for defining an API
   error response object. The implementation in this project will convert any exception from the API (ProblemDetailsException)
   into a Problem Details object, including 500 errors. This standard is really useful for keeping API response consistency
   among any kind of errors thrown. This is especially great for frontends that can implement interceptors and receive
   the same object, independently of the HTTP error code generated.
7. Rules Pattern  
   Professionally, I've been using technical decisions 1 to 6 more than a year so far, but this is the first time implementing [Rules Pattern](https://www.michael-whelan.net/rules-design-pattern/), which, in my opinion, was a perfect fit for this kind of problem where we would have a lot of IF-ELSE or SWITCH statements. In our API flow, a request comes to a Controller, which will fire a Validator, just by getting an InputModel object, since FluentValidation is linked with that object. If the model has any condition violation, an error 400 is thrown and all conditions violated are reported, otherwise, the Controller will send a Mediator request and the respective Command and CommandHandler will answer it. CommandHandler is the core class that will apply all the business rules related. This pattern is highly scalable as rules can be added or removed from the rules list:

<div align="center">
  <a href="https://www.useorigin.com/join-us">
    <img src="https://i.imgur.com/B8Vgs3N.png" alt="Image of part of API's C# code">
  </a>
</div>

Each rule should be the minimum unit for accomplishing a rule objectively. That's why on Origins problem description we have
8 rules, and in this implementation, we will find 11 rules. No Income, House, and Vehicle rules were split into three
individual rules. This pattern can be a little bit intimidating for newcomers, as a lot of files are generated for
each rule, but, of course, the benefits super pass this downside. I named each rule beginning with the attribute name
that generated it, which is not in pattern definition, but made sense to find the individual rule on a DDD based project
since on a discussion about some rules, Age/House/Income will be nominated:

<div align="center">
  <a href="https://www.useorigin.com/join-us">
    <img src="https://i.imgur.com/aFbaWXF.png" alt="Image of part of API's C# code">
  </a>
</div>

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- COMMENTS -->

## Comments

1. More About Validators
   Usually validating an InputModel converges into validating some of the Business Rules, which must have been discussed
   extensively in the refinement phase of the respective story/feature. For the brevity of this exercise, I took some
   business decisions for validating some of the input model attributes. Some of the attributes are "decision free" to
   have some rules established, ie. the Age attribute, there is no Age below zero. Others, like car year minimum and
   maximum, could have been discussed to have boundaries. As said, I usually don't make these decisions by myself. I
   tend to involve PO to think together. Of course, I will bring some ideas on how to solve some of the "problems" or
   to help make better decisions. Like on Vehicle Year, it should not be below zero or even 0, more than that, it
   should be equal or greater than the [first car ever made](https://www.motorbiscuit.com/oldest-cars-in-the-world/)
   (1769) and the maximum year could be current year + 1, as new models won't be younger than this. It may seem very
   detailed, but the data can be used in the future to build predictive models, and having vehicle years like 0 or
   3450 doesn't make sense and can get in the way or generate more cost in the data cleaning phase. I did the same for
   the Age attribute, most users won't be older than the oldest [human being registered](https://en.wikipedia.org/wiki/List_of_the_verified_oldest_people). This rule won't correct all typos but can avoid a user typo who intends to enter
   59 and hits 3 with entering on numpad and gets 593, if this would be possible, this user would have been affected by
   Rule #2 and won't be eligible for disability and life insurance.
2. Lower Snake Case  
   C# uses PascalCase as a standard naming rule. Origin's input and output models use lower snake case. We set up in
   Program.cs a configuration for all Controllers on how to handle all JSON exchanges (input and output). Before .NET Core 3.1
   this was not a problem, as the library of choice Newtonsoft.Json had a NamingPolicy for converting
   from lower_snake_case to PascalCase in & out. However, fortunately, Microsoft was getting rid of Newtonsoft.Json in
   .NET 3.1 and after, and the new library, System.Text.Json, do not have an implementation for lower_snake_case NamingPolicy
   (as we can see below), just the CamelCase one. Dotnet team and community are [working](https://github.com/dotnet/runtime/issues/782)
   hard to put this on, was previously planned for version 6.0, but, last year was postponed to version 7.0. So, for supplying
   this need, I use SnakeCaseNamingPolicy.cs and StringUtils.cs to achieve this type of naming policy. SnakeCaseNamingPolicy
   is under Configurations as its an API (server) specific conf and StringUtils is under Application/Common namespace as
   it is a string method conversion and it is used on ProblemDetailsException to convert errors key values to lower case
   either, since Application can be referenced by API project, but the opposite violates DDD layer separation concept.

<div align="center">
  <a href="https://www.useorigin.com/join-us">
    <img src="https://i.imgur.com/O267tuI.png" alt="Image of part of API's C# code">
  </a>
</div>

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ROADMAP -->

## Roadmap

- [x] MVP
- [ ] Next endpoints defined by Business Owners

See the [open issues](https://github.com/pedrohenriquerissato/InsuranteAPI/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create.
Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also
simply open an issue with the tag "enhancement".  
Don't forget to give the project a star! Thanks again!

### Requirements

To contribuite with this project you should:

- Install .NET 6.0 Software Development Kit (SDK) >= 6.0.2 available [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Use preferably [Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) or any other IDE with .NET support feature, like [Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet) or [Rider](https://www.jetbrains.com/rider/)

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>

## Unit Testing

For every code on the Application, the corresponding unit test should be made to
ensure business rules are being kept valid. For running current unit tests do:

```sh
dotnet test Insurance.Tests/Insurance.Tests.csproj
```

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
- [othneildrew](https://github.com/othneildrew/Best-README-Template)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/graphs/contributors
[forks-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/network/members
[stars-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/stargazers
[issues-url]: https://github.com/pedrohenriquerissato/InsuranceAPI/issues
[product-screenshot]: https://i.imgur.com/7YTR3PC.png
